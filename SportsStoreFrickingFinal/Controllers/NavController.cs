using SportsStoreFrickingFinal.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStoreFrickingFinal.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav
        //public ActionResult Index()
        //{
        //    return View();
        //}
        private IProductRepository productRepository;
        public NavController(IProductRepository productRepo)
        {
            this.productRepository = productRepo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> cateogries = productRepository.Products.Select(x => x.Category).Distinct().OrderBy(x => x);
            return PartialView(cateogries);
        }
    }
}