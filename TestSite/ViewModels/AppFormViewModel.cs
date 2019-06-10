using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestSite.Models;

namespace TestSite.ViewModels
{
    public class AppFormViewModel
    {

        public App App { get; set; }
        public IEnumerable<AppType> AppTypes { get; set; }


    }
}