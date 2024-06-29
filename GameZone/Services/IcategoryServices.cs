using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services
{
	public interface IcategoryServices
	{
		public IEnumerable<SelectListItem> GetSelectList();

	}
}
