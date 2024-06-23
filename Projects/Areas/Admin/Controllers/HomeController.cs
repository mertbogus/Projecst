using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projects.Models;

namespace Projects.Areas.Admin.Controllers
{
	[Area("Admin")]
    [AdminAuthorize] // Burada kullanılırsa tüm metotlara uygulanır.
    public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
