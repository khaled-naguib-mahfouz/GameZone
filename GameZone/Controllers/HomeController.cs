using System.Diagnostics;
using GameZone.Models;
using GameZone.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers
{
	public class HomeController : Controller
	{

		private readonly IgamesService igamesService;

        public HomeController(IgamesService gamesService)
        {
            this.igamesService = gamesService;
        }

        public IActionResult Index()
		{
			var games= igamesService.GetAll();
			return View(games);
		}

		

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
