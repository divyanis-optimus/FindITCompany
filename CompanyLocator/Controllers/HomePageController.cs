using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static CompanyLocator.ResponseHandler;
using CompanyLocator.Models;

namespace CompanyLocator.Controllers
{
    public class HomePageController : Controller
    {

        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Home(string city)
        {
            ResponseHandler response = new ResponseHandler();
            var resultlist = response.getCompanies(city);
            //MAPPINMG
            var resultCompany = new List<Models.Company>();
            foreach (var item in resultlist)
            {
                var uicompany = new Models.Company
                {
                    Name = item.Name,
                    Address = item.Address
                };
                resultCompany.Add(uicompany);
            }
            return View(resultCompany);
        }


    }
}