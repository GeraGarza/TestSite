using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestSite.Models
{
    public class App
    {


        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Application's Name")]  //in SQL Server Object Explorer, you see the properties
        [StringLength(255)]  //overwritting defeault contstraints - data annotations
        public string Name { get; set; }


        //   [ForeignKey("AppTypeId")]
        
        public AppType AppType { get; set; }

        public DateTime DateAdded { get; set; }

        
        [Display(Name = "Application Owner")]
        public string AppOwner { get; set; }


        [Display(Name = "Product Type")]
        public int AppTypeId { get; set; } //forign key

    }
}