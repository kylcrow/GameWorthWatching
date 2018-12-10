using GameWorthWatching.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameWorthWatching.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //NBAScoreboardModel scoreboardModel = new NBAScoreboardModel("12/02/2018");
            NBAScoreboardModel scoreboardModel = new NBAScoreboardModel(DateTime.Now.AddDays(-1));

            return View(scoreboardModel);
        }

        public ActionResult GetSchedule(string date)
        {
            NBAScoreboardModel scoreboardModel = new NBAScoreboardModel(date);

            return PartialView("_NBASchedule", scoreboardModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}