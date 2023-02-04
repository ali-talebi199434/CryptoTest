using Microsoft.AspNetCore.Mvc;
using ViewModel.Home;

namespace CryptoTest.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration configuration;
        public HomeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        public IActionResult Index()
        {            
            var model = new HomeViewModel();
            configuration.GetSection("Markets").Bind(model.Markets);
            return View(model);
        }
    }
}
