using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestTalent.Models;

namespace TestTalent.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TestTalentContext db = new TestTalentContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var utilisateurs = db.Utilistaeurs.ToList();
            return View(utilisateurs);
        }

        public IActionResult Edit(int id)
        {
            var utilisateur = db.Utilistaeurs.FirstOrDefault(x => x.Id == id);
            return View(utilisateur);
        }

        [HttpPost]
        public IActionResult Save(Utilistaeur utilistaeur)
        {
            db.Update(utilistaeur);
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}