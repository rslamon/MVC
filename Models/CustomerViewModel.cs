using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testsql2.Models
{
    public class CustomerViewModel
    {
        public IEnumerable<string> SelectedCustItems { get; set; }
        public IEnumerable<SelectListItem> CustItems{ get; set; }

        public IEnumerable<string> SelectedCity { get; set; }
        public IEnumerable<SelectListItem> City { get; set; }
    }
}