using CvProje1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProje1.Controllers
{
    public class SocialMediaController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult SocialMediaList()
        {
            var values = context.SocialMedia.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSocialMedia(SocialMedia socialmedia)
        {
            context.SocialMedia.Add(socialmedia);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var value = context.SocialMedia.Find(id);
            context.SocialMedia.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value = context.SocialMedia.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia socialmedia)
        {
            var value = context.SocialMedia.Find(socialmedia.SocialMediaId);
            value.Title = socialmedia.Title;
            value.Url = socialmedia.Url;
            value.Icon = socialmedia.Icon;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult ToTrue(int id)
        {
            var value = context.SocialMedia.Find(id);
            value.Status = true;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult ToFalse(int id)
        {
            var value = context.SocialMedia.Find(id);
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

    }
}