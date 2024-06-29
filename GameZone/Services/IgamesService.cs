using GameZone.Models;
using GameZone.ViewModels;

namespace GameZone.Services
{
	public interface IgamesService
	{
		Game? GetById(int id);
        Task<Game?> Update(EditGameFormViewModel model);
        bool Delete(int id);


        Task Create(CreateGameFormViewModel viewModel);
		IEnumerable<Game> GetAll();
	}
}
