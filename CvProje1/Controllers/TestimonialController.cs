using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvProje1.Models;

namespace CvProje1.Controllers
{
    public class TestimonialController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult TestimonialList()
        {
            var values = context.Testimonial.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTestimonial(Testimonial testimonial)
        {
            var values = context.Testimonial.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var values = context.Testimonial.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            var values = context.Testimonial.Find(testimonial.ID);
            values.ImageUrl = testimonial.ImageUrl;
            values.Description = testimonial.Description;
            values.City = testimonial.City;
            values.Stars = testimonial.Stars;
            values.Name = testimonial.Name;
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var values = context.Testimonial.Find(id);
            context.Testimonial.Remove(values);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

    }


}