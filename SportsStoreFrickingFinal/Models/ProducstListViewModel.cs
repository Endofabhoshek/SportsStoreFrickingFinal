using SportsStoreFrickingFinal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStoreFrickingFinal.Models
{
    public class ProducstListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfoObject { get; set; }
        public string CurrentCategory { get; set; }
    }
}