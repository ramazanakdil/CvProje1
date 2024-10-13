using CvProje1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProje1.Controllers
{
    public class EducationController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult EducationList()
        {
            var values = context.Education.ToList();
            return View(values);
        }
        public ActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateEducation(Education education)
        {
            context.Education.Add(education);
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }

        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var value = context.Education.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateEducation(Education education)
        {
            var value = context.Education.Find(education.EducationId);

            value.LongDescription = education.LongDescription;
            value.Description = education.Description;
            value.Title = education.Title;
            value.SubTitle = education.SubTitle;

            context.SaveChanges();
            return RedirectToAction("EducationList");
        }

        public ActionResult DeleteEducation(int id)
        {
            var values = context.Education.Find(id);
            context.Education.Remove(values);
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }
    }
}