using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using CvProje1.Models;

namespace CvProje1.Controllers
{
    public class StatisticsController : Controller
    {

        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        // GET: Statistics
        public ActionResult Index()
        {
            ViewBag.totalMessageCount = context.Contact.Count();
            ViewBag.messageIsReadTrueCount = context.Contact.Where(x => x.IsRead == true).Count();
            ViewBag.messageIsReadFalseCount = context.Contact.Where(x => x.IsRead == false).Count();
            ViewBag.skillRateCount = context.Skill.Count();
            ViewBag.skillRateSum = context.Skill.Sum(x => x.Rate);
            ViewBag.skillRateAvg = context.Skill.Average(x => x.Rate);

            var maxRate = context.Skill.Max(x => x.Rate);
            ViewBag.maxRateSkillName = context.Skill.Where(x => x.Rate == maxRate).Select(y => y.SkillName).FirstOrDefault();

            ViewBag.getMessageCountBySubjectRefernces = context.Contact.Where(x => x.Subject == "Referans").Count();

            ViewBag.getMessageCountByEmailContainHAndIsReadTrue = context.Contact.Where(x => x.IsRead == true && x.Email.Contains("h")).Count();

            ViewBag.getSkillNameByRate90 = context.Skill.Where(x => x.Rate == 90).Select(y => y.SkillName).FirstOrDefault();

            return View();
        }
    }
}