using Class_Liberary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_MVC_EF.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerRepository con;
        public CustomerController(ICustomerRepository cus)
        {
            con = cus;
        }
        // GET: CustomerController
        public ActionResult List()
        {
            var Result = con.GetCustomers();
            return View("List",Result);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(long id)
        {
            var result = con.GetCustomerID(id);
            return View("Details",result);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            
            return View("Create",new Customer());
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer collection)
        {
            try
            {
                 con.InsertCustomer(collection );
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(long CustomerID)
        {
           var Edit = con.GetCustomerID(CustomerID);
            return View("Edit",Edit);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer cus)
        {
            try
            {
                con.UpdateCustomer(cus);
                return RedirectToAction(nameof(List));
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(long id)
        {
            var DeleteValue = con.GetCustomerID(id);
            return View("Delete",DeleteValue);
        }

        // POST: CustomerController/Delete/5
        [HttpPost("DeleteId")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteId(long id)
        {
            try
            {
                con.DeleteCustomer(id);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
    }
}
