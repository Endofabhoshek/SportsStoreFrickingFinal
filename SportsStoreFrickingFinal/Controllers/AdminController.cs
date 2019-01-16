using SportsStoreFrickingFinal.Domain.Abstract;
using SportsStoreFrickingFinal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStoreFrickingFinal.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository productRepository;
        public AdminController(IProductRepository repo)
        {
            this.productRepository = repo;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(productRepository.Products);
        }

        public ViewResult Edit(int productId)
        {
            Product product = productRepository.Products.Where(x => x.ProductId == productId).FirstOrDefault();
            return View(product);
        }
    }
}