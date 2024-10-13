using CvProje1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.Json;

namespace CvProje1.Controllers
{
    public class ChartController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult ChartIndex()
        {
            var skills = context.Skill.ToList();
            var skillNames = context.Skill.Select(x => x.SkillName).ToList();
            var skillRates = context.Skill.Select(x => x.Rate).ToList();

            ViewBag.SkillNames = skillNames;
            ViewBag.SkillRates = skillRates;
            return View();
        }
    }
}