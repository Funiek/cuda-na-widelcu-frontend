using CudaNaWidelcuFrontend.Models;
using Microsoft.AspNetCore.Mvc;
using RecipeReference;
using ServiceReference1;
using System.Diagnostics;
using System.IO;

namespace CudaNaWidelcuFrontend.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly RecipeServiceClient _recipeService;
        private readonly ImageServiceClient _imageService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RecipeController(ILogger<RecipeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _recipeService = new RecipeServiceClient();
            _imageService = new ImageServiceClient();
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var recipesResponse = await _recipeService.getRecipesAsync();
            var recipes = recipesResponse.@return;

            return View(recipes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var recipesResponse = await _recipeService.getRecipesAsync();

            var category = id switch
            {
                1 => Category.BREAKFAST,
                2 => Category.LUNCH,
                3 => Category.DINNER,
                _ => Category.BREAKFAST
            };

            var recipes = recipesResponse.@return.Where(e => e.category.Equals(category)).ToList();

            
            return View(recipes);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var recipeResponse = await _recipeService.getRecipeAsync(id);
            var recipe = recipeResponse.@return;
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "img", recipe.name + ".jpeg");
            
            if (recipe.image is null && recipe.name is not null && !System.IO.File.Exists(path))
            {
                var imageInBytesResponse = await _imageService.downloadImageAsync(recipe.name + ".jpeg");
                recipe.image = imageInBytesResponse.Body.@return;

                using (var ms = new MemoryStream(recipe.image))
                {
                    using (var fs = new FileStream(path, FileMode.Create))
                    {
                        ms.WriteTo(fs);
                    }
                }
            }

            return View(recipe);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}