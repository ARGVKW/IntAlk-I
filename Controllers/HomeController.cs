using IntAlk_I.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Primitives;
using System.Diagnostics;

namespace IntAlk_I.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([Bind("Szam1,Szam2,Muvelet")] FormValues formValues)
        {
            double Szam1 = formValues.Szam1;
            double Szam2 = formValues.Szam2;
            string Muvelet = formValues.Muvelet;
            string Eredmeny = "";

            switch (Muvelet)
            {
                case "+": Eredmeny = Osszead(Szam1, Szam2).ToString(); break;
                case "-": Eredmeny = Kivon(Szam1, Szam2).ToString(); break;
                case "*": Eredmeny = Szoroz(Szam1, Szam2).ToString(); break;
                case "/": Eredmeny = Oszt(Szam1, Szam2).ToString(); break;
                case "%": Eredmeny = Modulo(Szam1, Szam2).ToString(); break;
            }

            FormViewModel model = new FormViewModel
            {
                FormValues = formValues,
                Eredmeny = Eredmeny
            };

            if (ModelState.IsValid)
            {
                return View(model);
            }

            return View();
        }

        private double Osszead(double szam1, double szam2)
        {
            return szam1 + szam2;
        }

        private double Kivon(double szam1, double szam2)
        {
            return szam1 - szam2;
        }


        private double Szoroz(double szam1, double szam2)
        {
            return szam1 * szam2;
        }

        private double Oszt(double szam1, double szam2)
        {
            if (szam2 == 0)
            {
                ModelState.AddModelError(string.Empty, "Hiba! Nullával osztás.");
            }
            return szam1 / szam2;
        }

        private double Modulo(double szam1, double szam2)
        {
            if (szam2 == 0)
            {
                ModelState.AddModelError(string.Empty, "Hiba! Modulo osztója nem lehet 0.");
            }
            return szam1 % szam2;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}