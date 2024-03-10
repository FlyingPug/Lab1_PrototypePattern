using Lab1_DnD_Creator.Models;
using Lab1_DnD_Creator.Models.Characters;
using Lab1_DnD_Creator.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab1_DnD_Creator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICharacterService _characterService;

        public HomeController(ILogger<HomeController> logger, ICharacterService characterService)
        {
            _logger = logger;
            _characterService = characterService;
        }

        [HttpGet]
        public IActionResult GetCharacter(string parameter)
        {
            Character character = _characterService.GetCharacterByClassName(parameter);
            return View("Character", character);
        }

        public IActionResult Index()
        {
            return View();
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