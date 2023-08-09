using ANKSuperMarket.Data;
using ANKSuperMarket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ANKSuperMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MarketDbContext db;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public HomeController(MarketDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {

            return View(db.Urunler.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Urun Urunler)
        {

            if (ModelState.IsValid)
            {
                if (db.Urunler.Contains(Urunler))
                    db.Urunler.Update(Urunler);
                else
                {
                    db.Urunler.Add(Urunler);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpPost]
        public IActionResult List()
        {
            
                List<Urun> Urunler = db.Urunler.ToList();
                return View(Urunler);
            
        }
        public IActionResult Sil(int id)
        {
            var girdi = db.Urunler.FirstOrDefault(x => x.Id == id);
            if (girdi == null)
            {
                return NotFound();
            }
            return View(girdi);
        }
        [ActionName("Sil")]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SilOnay(int id)
        {
            var girdi = db.Urunler.FirstOrDefault(x => x.Id == id);
            if (girdi == null)
            {
                return NotFound();
            }
            db.Urunler.Remove(girdi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Stoktami()
        {
            return View(db.Urunler.ToList());
        }
        public IActionResult Duzenle(int id)
        {
            var girdi = db.Urunler.FirstOrDefault(x => x.Id == id);
            if (girdi == null)
            {
                return NotFound();
            }
            return View(girdi);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}