using CvProje1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProje1.Controllers
{
    public class ServicesController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult ServicesList()
        {
            var values = context.Service.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateService(Service service)
        {
            context.Service.Add(service);
            context.SaveChanges();
            return RedirectToAction("ServicesList");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var values = context.Service.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            var values = context.Service.Find(service.ServiceId);
            values.Title = service.Title;
            values.Description = service.Description;
            values.Article1 = service.Article1;
            values.Article2 = service.Article2;
            values.Article3 = service.Article3;
            values.Icon = service.Icon;
            context.SaveChanges();
            return RedirectToAction("ServicesList");
        }

        public ActionResult DeleteService(int id)
        {
            var values = context.Service.Find(id);
            context.Service.Remove(values);
            context.SaveChanges();
            return RedirectToAction("ServicesList");
        }
    }
}