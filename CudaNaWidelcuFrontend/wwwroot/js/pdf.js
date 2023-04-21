const pdfButton = document.querySelector("#pdfButton");


pdfButton.addEventListener("click", () => {
    $.post("https://localhost:7236/Recipe/Pdf",
        {
            Name: RecipeName,
        },
        function (data, status) {
            setTimeout(
                function () {
                    let link = document.createElement("a");
                    link.download = RecipeName + ".pdf";
                    link.href = 'https://localhost:7236/pdf/' + RecipeName + ".pdf";
                    document.body.appendChild(link);
                    link.click();
                    document.body.removeChild(link);
                    delete link;
                }, 1000);
            
        }
    );
});