using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestSite.Models
{
    public class Min18YearsIfUser : ValidationAttribute
    {


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            


            var customer = (Customer)validationContext.ObjectInstance;
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            if(age >100 || age < 1) {
                return new ValidationResult("Invalid Age( Range: 1 - 100)");
            }

            if (customer.MembershipTypeId == MembershipType.Unknown 
                || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.Birthdate == null)
            {
                return new ValidationResult("Birthday is required");
            }

           

            return (age > 17) ? ValidationResult.Success : new ValidationResult("Not 18+");


        }

    }
}