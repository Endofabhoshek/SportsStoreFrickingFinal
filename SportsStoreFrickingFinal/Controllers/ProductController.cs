using SportsStoreFrickingFinal.Domain.Abstract;
using SportsStoreFrickingFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStoreFrickingFinal.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository { get; set; }
        public int pageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List(string category, int page = 1)
        {

            ProducstListViewModel productListViewModel = new ProducstListViewModel()
            {
                Products = repository.Products
                    .Where(x => x.Category == null? true : x.Category == category)
                    .OrderBy(x => x.Name)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                ,
                PagingInfoObject = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.Products.Count()
                },
                CurrentCategory = category
            };
            return View(productListViewModel);
        }
    }
}