using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationAssignment.Models;

namespace WebApplicationAssignment.Controllers
{
    public class CustomerController : Controller
    {
        public static List<Customer> customer = new List<Customer>(); 
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            return View(customer);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Customer cust)
        {
            customer.Add(cust);
            return RedirectToAction("Get", customer);
        }

        [HttpGet]
        [Route("Edit")]
        public IActionResult Edit(int id)
        {
            Customer oCustomer = customer.Where(a => a.Id.Equals(id)).Select(s => s).FirstOrDefault();
            return View(oCustomer);
        }


        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(Customer cust)
        {
            Customer oCustomer = customer.Where(a => a.Id.Equals(cust.Id)).Select(s => s).FirstOrDefault();
            if(oCustomer!=null)
            {
                oCustomer.Name = cust.Name;
                oCustomer.Age = cust.Age;
            }
            return RedirectToAction("Get", oCustomer);
        }

        [HttpGet]
        [Route("Details")]
        public IActionResult Details(int id)
        {
            Customer cust = customer.Where(a => a.Id == id).Select(s => s).FirstOrDefault();
            return View(cust);
        }

        [Route("Delete")]
        public ActionResult Delete(int id)
        {
            Customer cust = customer.Find(c => c.Id == id);
            customer.Remove(cust);
            return RedirectToAction("Get");
        }
    }
}
