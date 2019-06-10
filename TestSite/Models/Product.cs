using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestSite.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }


        public ProductType ProductType { get; set; }

        public DateTime DateAdded { get; set; }

        public string AppOwner { get; set; }


        [Display(Name = "Product Type")]
        public byte ProductTypeId { get; set; }  //forign key


    }
}