using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestSite.Models;

namespace TestSite.ViewModels
{
    public class ProductFormViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<ProductType> ProductType { get; set; }



    }
}