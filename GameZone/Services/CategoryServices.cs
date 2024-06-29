using GameZone.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services
{
	public class CategoryServices:IcategoryServices
	{
		

		 IEnumerable<SelectListItem> IcategoryServices.GetSelectList()
		{
			Context context = new Context();
			return context.Category.Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
			{ Value = c.Id.ToString(), Text = c.Name }).ToList();
		}
	}
}
