using DoAnCoSo.DTOs;
using DoAnCoSo.Models;
using DoAnCoSo.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace DoAnCoSo.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index(string searchString)
        {
            var comic = _dbContext.Comics.ToList();

            var loginUser = User.Identity.GetUserId();
            ViewBag.LoginUser = loginUser;
            foreach (Comic i in comic)
            {
                Follow find = _dbContext.Follows.FirstOrDefault(f => f.FolloweeId == loginUser && f.ComicId == i.Id);
                if (find == null)
                {
                    i.isShowFollow = true;
                }
            }
            var comics = from l in _dbContext.Comics
                         select l;
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                comics = comics.Where(c => c.NameComic.ToLower().Contains(searchString));
            }

            return View(comics);
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