using Eticaret.Models;
using Eticaret.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Eticaret.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private readonly IComputerService _computerService;
        private readonly CartService _cartService;
        
        public HomeController(IComputerService computerService,CartService cartService)
        {
            _computerService = computerService;
            _cartService = cartService;

            
        } 
        public IActionResult Index()
        {
            ViewData["SepettekiUrunSayisi"] = _cartService.SepettekiUrunSayisi();
            var computer = _computerService.GetAll();
            return View(computer);
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        { 
            var computer = _computerService.GetById(id);
            if (computer != null)
            {
                _cartService.AddToCart(computer);
            }
            return RedirectToAction("Index");

        }
        /*Bu Sayfayý Sepet Sayfasý Kullanýcam*/
         public IActionResult Privacy()
        {
            ViewData["SepettekiUrunSayisi"] = _cartService.SepettekiUrunSayisi();
            var CartItems = _cartService.GetCart();
            return View(CartItems);
        }

        [HttpPost]
        public IActionResult UrunMiktariArttir(int ComputerId)
        {
            _cartService.UrunMiktariArttir(ComputerId);
            return RedirectToAction("Privacy");
        }

        [HttpGet]
        public IActionResult UrunMiktariAzalt(int ComputerId)
        {
            _cartService.UrunMiktariAzalt(ComputerId);
            return RedirectToAction("Privacy");
        }

        [HttpPost]
        public IActionResult SepettenCikar(int ComputerId)
        {
            _cartService.SepetiSil(ComputerId);
            return RedirectToAction("Privacy");
        }




        //[HttpPost]
        //public IActionResult DeleteToCart(int id)
        //{
        //    var computer = _computerService.GetById(id);
        //    if (computer != null)
        //    {
        //        _cartService.DeleteCart(computer);
        //    }
        //    return RedirectToAction("Index");

        //}




















        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
