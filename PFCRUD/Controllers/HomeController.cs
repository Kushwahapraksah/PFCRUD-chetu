using PFCRUD.Models;
using PFCRUD.pcrud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PFCRUD.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Modcls obj)
        {
            Clx std = new Clx();
            pcrudEntities res = new pcrudEntities();
            std.Std_id = obj.Std_id;
            std.Std_name = obj.Std_name;
            std.Age = obj.Age;
            std.Fee = obj.Fee;
            std.City = obj.City;
            std.Percentage = obj.Percentage;

            if (obj.Std_id == 0)
            {
                res.Clxes.Add(std);
                res.SaveChanges();
            }
            else
            {
                res.Entry(std).State = System.Data.Entity.EntityState.Modified;
                res.SaveChanges();
            }

            return View();
        }

public ActionResult Edit(int id)
        {
            pcrudEntities res = new pcrudEntities();

            Modcls ed = new Modcls();
            var obj1 = res.Clxes.Where(m => m.Std_id == id).First();
            ed.Std_id = obj1.Std_id;
            ed.Std_name = obj1.Std_name;
            ed.Age = obj1.Age;
            ed.Fee = obj1.Fee;
            ed.City = obj1.City;
            ed.Percentage = obj1.Percentage;
            return View("index",ed);


        }




        public ActionResult Delete(int id)
        {

            pcrudEntities obj = new pcrudEntities();
            var deletedata = obj.Clxes.Where(m => m.Std_id == id).First();
            obj.Clxes.Remove(deletedata);
            obj.SaveChanges();
            return RedirectToAction("Index");

        }


        public ActionResult About()
        {
            pcrudEntities obj = new pcrudEntities();
            var obj1 = obj.Clxes.ToList();
            return View(obj1);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}