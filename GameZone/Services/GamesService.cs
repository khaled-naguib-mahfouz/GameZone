using GameZone.Models;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services
{
    public class GamesService : IgamesService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagePath;
        Context context = new Context();


        public GamesService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _imagePath = $"{_webHostEnvironment.WebRootPath}/Assets/GamesImage";

        }

        public async Task Create(CreateGameFormViewModel viewModel)
        {

            var coverName = await SaveCover(viewModel.Cover);

            Game game = new()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                CategoryId = viewModel.CategoryId,
                Cover = coverName,
                Devices = viewModel.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList()
            };
            context.Add(game);
            context.SaveChanges();
        }

        public IEnumerable<Game> GetAll()
        {
            var Games = context.Games.
                Include(G => G.Category).
                 Include(g => g.Devices)
                .ThenInclude(d => d.Device)
                .AsNoTracking().ToList();
            if (Games == null || Games.Count == 0)
            {
                return new List<Game>();
            }

            return (Games);
        }

        public Game? GetById(int id)
        {
            return context.Games
           .Include(g => g.Category)
           .Include(g => g.Devices)
           .ThenInclude(d => d.Device)
           .AsNoTracking()
           .SingleOrDefault(g => g.Id == id);
        }
        public async Task<Game?> Update(EditGameFormViewModel model)
        {
            var game = context.Games
                .Include(g => g.Devices)
                .SingleOrDefault(g => g.Id == model.Id);

            if (game is null)
                return null;

            var hasNewCover = model.Cover is not null;
            var oldCover = game.Cover;

            game.Name = model.Name;
            game.Description = model.Description;
            game.CategoryId = model.CategoryId;
            game.Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList();

            if (hasNewCover)
            {
                game.Cover = await SaveCover(model.Cover!);
            }

            var effectedRows = context.SaveChanges();

            if (effectedRows > 0)
            {
                if (hasNewCover)
                {
                    var cover = Path.Combine(_imagePath, oldCover);
                    File.Delete(cover);
                }

                return game;
            }
            else
            {
                var cover = Path.Combine(_imagePath, game.Cover);
                File.Delete(cover);

                return null;
            }
        }
        private async Task<string> SaveCover(IFormFile cover)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";

            var path = Path.Combine(_imagePath, coverName);

            using var stream = File.Create(path);
            await cover.CopyToAsync(stream);

            return coverName;
        }
        public bool Delete(int id)
        {
            var isDeleted = false;

            var game = context.Games.Find(id);

            if (game is null)
                return isDeleted;

            context.Remove(game);
            var effectedRows = context.SaveChanges();

            if (effectedRows > 0)
            {
                isDeleted = true;

                var cover = Path.Combine(_imagePath, game.Cover);
                File.Delete(cover);
            }
            return isDeleted;

        }
    }
}