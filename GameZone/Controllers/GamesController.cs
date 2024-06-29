using GameZone.Models;
using GameZone.Services;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        Context context = new Context(); 
        private readonly IcategoryServices _icategoryServices;
        private readonly IDevicesServices _devicesServices;
        private readonly IgamesService _igamesService;

		public GamesController(IcategoryServices icategoryServices, IDevicesServices devicesServices, IgamesService igamesService)
		{
			_igamesService = igamesService;
			_devicesServices = devicesServices;
			_icategoryServices = icategoryServices;

		}

        public IActionResult Details(int id)
        {
            var game = _igamesService.GetById(id);

            if (game is null)
                return NotFound();

            return View(game);
        }
        public IActionResult Index()
        {
            
           var games= _igamesService.GetAll();
            return View(games);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateGameFormViewModel viewModel = new()
            {
                Categories = _icategoryServices.GetSelectList(),

                Devices = _devicesServices.GetDevices()

			};
            return View(viewModel);
        }
        
        [HttpPost]
        public async Task <IActionResult> Create( CreateGameFormViewModel model ) 
        {


            if(!ModelState.IsValid)
            {
                 
                model.Categories = _icategoryServices.GetSelectList();
                model.Devices = _devicesServices.GetDevices();
                return View(model);
            }
            await _igamesService.Create(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var game = _igamesService.GetById(id);

            if (game is null)
                return NotFound();

            EditGameFormViewModel viewModel = new()
            {
                Id = id,
                Name = game.Name,
                Description = game.Description,
                CategoryId = game.CategoryId,
                SelectedDevices = game.Devices.Select(d => d.DeviceId).ToList(),
                Categories = _icategoryServices.GetSelectList(),
                Devices = _devicesServices.GetDevices(),
                CurrentCover = game.Cover
            };

            return View("Edit",viewModel);
        }
        [HttpPost]
        
        public async Task<IActionResult> Edit(EditGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _icategoryServices.GetSelectList();
                model.Devices = _devicesServices.GetDevices();
                return View(model);
            }

            var game = await _igamesService.Update(model);

            if (game is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted = _igamesService.Delete(id);

            return isDeleted ? Ok() : BadRequest();
        }
    }
    
}
