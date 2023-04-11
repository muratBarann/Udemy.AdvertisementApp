using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Business.Interfaces;

namespace Udemy.AdvertisementApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvidedService _providedService;

        public HomeController(IProvidedService providedService)
        {
            _providedService = providedService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _providedService.GetAllAsync();
            return View(response);
        }
    }
}
