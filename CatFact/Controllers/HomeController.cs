using CatFact.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatFact.Controllers
{
    public class HomeController : Controller
    {
        public readonly IFileService _fileService;
        public readonly IInfoGetterService _infoGetterService;

        public HomeController(IFileService fileService, IInfoGetterService infoGetterService)
        {
            _fileService = fileService;
            _infoGetterService = infoGetterService;
        }

        [HttpGet]
        public IActionResult Index(string line)
        {
            return View(line);
        }

        [HttpPost]
        public IActionResult GetLine()
        {
            string line = _infoGetterService.GetLineFromApi();
            _fileService.AddTextToFile(line);
            return View("Index", line);
        }
    }
}