using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testsql2.Models;
using System.Text;

namespace testsql2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            NorthwindEntities entites = new NorthwindEntities();
            return View(from Customer in entites.Customers.Take(10)
                        select Customer);
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Test()
        {
            NorthwindEntities1 db = new NorthwindEntities1();
            List<SelectListItem> listSelectListItems = new List<SelectListItem>();

            foreach(Region regions in db.Regions)
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = regions.RegionDescription.ToString(),
                    Value = regions.RegionID.ToString(),
                    Selected = false


                };
                listSelectListItems.Add(selectList);
            }
            RegionsViewModel regionViewModel = new RegionsViewModel()
            {
                Regions = listSelectListItems
            };
            return View(regionViewModel);
        }

        [HttpGet]
        public ActionResult Cust()
        {

            ViewBag.Message = "Your application description page.";

            return View();
            //    NorthwindEntities2 db = new NorthwindEntities2();
            //    List<SelectListItem> listSelectListItems = new List<SelectListItem>();
            //    List<SelectListItem> listSelectListItems2 = new List<SelectListItem>();

            //    foreach (Customer customer in db.Customers) {
            //        SelectListItem selectList = new SelectListItem()
            //        {
            //            Text = customer.ContactName.ToString(),
            //            Value = customer.CustomerID.ToString(),
            //            Selected = true

            //        };
            //        SelectListItem selectList2 = new SelectListItem()
            //        {
            //            Text = customer.City.ToString(),
            //            Value = customer.City.ToString(),
            //            Selected = false

            //        };
            //        listSelectListItems.Add(selectList);
            //        listSelectListItems2.Add(selectList2);

            //    }

            //    CustomerViewModel customerViewModel = new CustomerViewModel()
            //    {
            //        CustItems = listSelectListItems,
            //        City = listSelectListItems2
            //};
            //    return View(customerViewModel);
        }

        [HttpPost]
        public string Test(IEnumerable<string> selectedRegions)
        {
            if (selectedRegions == null)
            {
                return "No cities are selected";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("You selected – " + string.Join(",", selectedRegions));
                return sb.ToString();
            }
        }

        [HttpPost]
        public ActionResult Cust(IEnumerable<string> SelectedCity)
        {
            NorthwindEntities2 db = new NorthwindEntities2();
            List<SelectListItem> listSelectListItems = new List<SelectListItem>();
            List<SelectListItem> listSelectListItems2 = new List<SelectListItem>();

            foreach (Customer customer in db.Customers)
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = customer.ContactName.ToString(),
                    Value = customer.CustomerID.ToString(),
                    Selected = true

                };
                SelectListItem selectList2 = new SelectListItem()
                {
                    Text = customer.City.ToString(),
                    Value = customer.City.ToString(),
                    Selected = false

                };
                listSelectListItems.Add(selectList);
                listSelectListItems2.Add(selectList2);

            }

            CustomerViewModel customerViewModel = new CustomerViewModel()
            {
                CustItems = listSelectListItems,
                City = listSelectListItems2
            };
            return View(customerViewModel);



            //if (SelectedCity == null)
            //{
            //    return "No cities are selected";
            //}
            //else
            //{
            //    StringBuilder sb = new StringBuilder();
            //    sb.Append("You selected – " + string.Join(",", SelectedCity));
            //    return sb.ToString();
            //}
        }

    }
}