using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvProje1.Models;

namespace CvProje1.Controllers
{
    public class AboutController : Controller
    {
        DbMyPortfolioNightEntities db = new DbMyPortfolioNightEntities();
        public ActionResult AboutList()
        {
            var values = db.Profile.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {

            var value = db.Profile.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateAbout(Profile profile)
        {
            var values = db.Profile.Find(profile.ProfileId);
            values.Email = profile.Email;
            values.Phone = profile.Phone;
            values.Github = profile.Github;
            values.Address = profile.Address;
            values.Title = profile.Title;
            values.Description = profile.Description;
            values.ImageUrl = profile.ImageUrl;

            ViewBag.ıd = db.Profile.Select(x => x.ProfileId).FirstOrDefault();
            db.SaveChanges();
            return RedirectToAction("AboutList");

        }
        public ActionResult ContactList()
        {
            var values = db.Profile.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var value = db.Profile.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateContact(Profile profile)
        {
            var values = db.Profile.Find(profile.ProfileId);
            values.Email = profile.Email;
            values.Phone = profile.Phone;
            values.Address = profile.Address;
            db.SaveChanges();
            return RedirectToAction("ContactList");

        }
    }
}