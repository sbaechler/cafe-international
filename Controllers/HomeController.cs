using System.Linq;
using System.Web.Mvc;
using CafeInternational.DAL;
using CafeInternational.ViewModels;

namespace CafeInternational.Controllers
{
    public class HomeController : Controller
    {
        private CafeContext db = new CafeContext();

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            IndexViewModel viewModel = new IndexViewModel();
            var countries = db.Countries;
            var cups = db.Cups;
//            viewModel.CountriesSelect = new SelectList(countries, "ISO2", "Name", "CH");  // TODO: dynamic default.
            viewModel.SetCountries(countries.ToArray());
            viewModel.SetCups(cups.ToArray());
            return View(viewModel);
        }
    }
}