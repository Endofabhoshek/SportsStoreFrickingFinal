using SportsStoreFrickingFinal.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStoreFrickingFinal.Domain.Entities;

namespace SportsStoreFrickingFinal.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Product> Products
        {
            get
            {
                return context.Products;
            }
        }
    }
}
