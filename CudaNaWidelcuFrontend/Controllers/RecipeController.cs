using CudaNaWidelcuFrontend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using FileReference;
using RecipeReference;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CudaNaWidelcuFrontend.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly RecipeServiceClient _recipeService;
        private readonly FileServiceClient _fileService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly Dictionary<Category, string> _categoryNames;

        public class RecipeModelView
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Category { get; set; }
            public double Rating { get; set; }
            public string? Description { get; set; }
            public double CountVotes { get; set; }
            public Product[]? Products { get; set; }
        }

        public RecipeController(ILogger<RecipeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _recipeService = new RecipeServiceClient();
            _fileService = new FileServiceClient();
            _webHostEnvironment = webHostEnvironment;
            _categoryNames = new Dictionary<Category, string>
            {
                { Category.BREAKFAST, "Śniadanie" },
                { Category.LUNCH, "Obiad" },
                { Category.DINNER, "Kolacja" }
            };
        }

        public async Task<IActionResult> Index()
        {
            var recipesResponse = await _recipeService.getRecipesAsync();
            var recipes = recipesResponse.@return;
            var modelViews = new List<RecipeModelView>();

            foreach (var recipe in recipes)
            {
                modelViews.Add(new RecipeModelView
                {
                    Id = recipe.id, 
                    Name = recipe.name,
                    Category = _categoryNames[recipe.category],
                    Rating = recipe.rating,

                });
            }

            return View(modelViews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var category = id switch
            {
                1 => Category.BREAKFAST,
                2 => Category.LUNCH,
                3 => Category.DINNER,
                _ => Category.BREAKFAST
            };

            var recipesResponse = await _recipeService.getRecipesByCategoryAsync(category);
            var recipes = recipesResponse.@return;
            var modelViews = new List<RecipeModelView>();

            foreach (var recipe in recipes)
            {
                modelViews.Add(new RecipeModelView
                {
                    Id = recipe.id,
                    Name = recipe.name,
                    Category = _categoryNames[recipe.category],
                    Rating = recipe.rating,
                    CountVotes = recipe.countVotes,
                    Description = recipe.description,
                    Products = recipe.products
                });
            }

            return View(modelViews);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var recipeResponse = await _recipeService.getRecipeAsync(id);
            var recipe = recipeResponse.@return;
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "img", recipe.name + ".jpeg");
            
            if (recipe.image is null && recipe.name is not null && !System.IO.File.Exists(path))
            {
                var imageInBytesResponse = await _fileService.downloadImageAsync(recipe.name);
                recipe.image = imageInBytesResponse.@return;

                using (var ms = new MemoryStream(recipe.image))
                {
                    using (var fs = new FileStream(path, FileMode.Create))
                    {
                        ms.WriteTo(fs);
                    }
                }
            }

            var modelView = new RecipeModelView
            {
                Id = recipe.id,
                Name = recipe.name,
                Category = _categoryNames[recipe.category],
                Rating = recipe.rating,
                CountVotes = recipe.countVotes,
                Description = recipe.description,
                Products = recipe.products
            };

            return View(modelView);
        }

        [HttpPost]
        public void Rating(RatingData data)
        {
            _recipeService.rateRecipeAsync(data.RecipeId, data.Rating);
        }

        [HttpPost]
        public async Task Pdf(RecipeNameData data)
        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "pdf", data.Name + ".pdf");

            if (!System.IO.File.Exists(path))
            {
                var recipeResponse = await _recipeService.getRecipeByNameAsync(data.Name);
                var recipe = recipeResponse.@return;

                StringBuilder stringBuilder = new StringBuilder();

                foreach(var product in recipe.products)
                {
                    stringBuilder.Append($"{product.name}: {product.qty} {product.measure};");
                }

                stringBuilder.Remove(stringBuilder.Length - 1, 1);

                var pdfResponse = await _fileService.downloadRecipeProductsPdfAsync(recipe.name, stringBuilder.ToString());
                var pdfInBytes = pdfResponse.@return;

                using (var ms = new MemoryStream(pdfInBytes))
                {
                    using (var fs = new FileStream(path, FileMode.Create))
                    {
                        ms.WriteTo(fs);
                    }
                }
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}