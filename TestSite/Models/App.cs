using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestSite.Models
{
    public class App
    {


        public int Id { get; set; }
        public string Name { get; set; }


        public AppType AppType { get; set; }

        public DateTime DateAdded { get; set; }

        public string AppOwner { get; set; }


        [Display(Name = "Product Type")]
        public int AppTypeId { get; set; }  //forign key

    }
}