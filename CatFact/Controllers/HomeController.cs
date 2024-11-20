using CatFact.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatFact.Controllers
{
    public class HomeController : Controller
    {
        public readonly IFileService _fileService;

        public HomeController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetLine()
        {
            _fileService.AddTextToFile();
            return RedirectToAction("Index");
        }
    }
}