using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testsql2.Models
{
    public class RegionsViewModel
    {
        public IEnumerable<string> SelectedRegions { get; set; }
        public IEnumerable<SelectListItem> Regions { get; set; }
    }
}