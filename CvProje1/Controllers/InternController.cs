using CvProje1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace CvProje1.Controllers
{
    public class InternController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult InternList()
        {
            var values = context.Intern.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateIntern()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateIntern(Intern intern)
        {
            context.Intern.Add(intern);
            context.SaveChanges();
            return RedirectToAction("InternList");
        }

        [HttpGet]
        public ActionResult UpdateIntern(int id)
        {
            var values = context.Intern.Find(id);
            return View(values);

        }

        [HttpPost]
        public ActionResult UpdateIntern(Intern intern)
        {
            var value = context.Intern.Find(intern.Id);
            value.Department = value.Department;
            value.Years = value.Years;
            value.Company = value.Company;

            context.SaveChanges();
            return RedirectToAction("InternList");
        }

        public ActionResult DeleteIntern(int id)
        {
            var values = context.Intern.Find(id);
            context.Intern.Remove(values);
            context.SaveChanges();
            return RedirectToAction("InternList");
        }
    }
}