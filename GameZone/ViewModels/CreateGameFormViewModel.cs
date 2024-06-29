using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.ViewModels
{
    public class CreateGameFormViewModel:GameFormViewModel
    {

        public IFormFile Cover { get; set; } = default!;
    }
}
