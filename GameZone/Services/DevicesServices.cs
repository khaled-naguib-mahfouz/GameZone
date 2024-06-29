using GameZone.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services
{
	public class DevicesServices:IDevicesServices
	{
		

		IEnumerable<SelectListItem> IDevicesServices.GetDevices()
		{
			Context context = new Context();
			return context.Devices.Select(d => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
			{ Value = d.Id.ToString(), Text = d.Name }).ToList();
		}
	}
}
