using IntAlk_I.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index(double szam1, double szam2, string muvelet)
        {
            if (ModelState.IsValid)
            {

            }

            string result = "";
            switch (muvelet)
            {
                case "+": result = Osszead(szam1, szam2).ToString(); break;
                case "-": result = Kivon(szam1, szam2).ToString(); break;
                case "*": result = Szoroz(szam1, szam2).ToString(); break;
                case "/": result = Oszt(szam1, szam2).ToString(); break;
                case "%": result = Modulo(szam1, szam2).ToString(); break;
            }

            FormViewModel model = new FormViewModel { 
                FormValues = new FormValues
                {
                    Szam1 = szam1,
                    Szam2 = szam2,
                    Muvelet = muvelet
                },
                Eredmeny = result
            };
            
            return View(model);
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
            return szam1 / szam2;
        }

        private double Modulo(double szam1, double szam2)
        {
            return szam1 % szam2;
        }

        [HttpPost]
        [ActionName("Calc")]
        public IActionResult Calc()
        {
            if (ModelState.IsValid)
            {

            }
            return RedirectToAction("Index");
            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}