using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestSite.Models
{
    public class Customer
    {


        public int Id { get; set; }


        [Required]  //in SQL Server Object Explorer, you see the properties
        [StringLength(255)]  //overwritting defeault contstraints - data annotations
        public String Name { get; set; }

        public bool isMember { get; set; }

        public MembershipType MembershipType { get; set; }  //navigation property -> Customer -> membership type


        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }  //forign key

    
        [Display(Name ="Date of Birth")]
        public DateTime? Birthdate { get; set; }

    }
}