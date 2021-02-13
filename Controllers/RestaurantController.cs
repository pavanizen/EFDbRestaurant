using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFirstApproachRestaurant.Models;

namespace EFDbFirstApproachRestaurant.Controllers
{
    public class RestaurantController : Controller
    {
        WFA3DotNetEntities db = new WFA3DotNetEntities();
        // GET: Restaurant

        public ActionResult Index(string search="")
        {
            //var res=db.RestTabs.ToList();
            ViewBag.Search = search;
            var res = db.RestTabs.Where(r => r.RestName.Contains(search)).ToList();
            return View(res);
        }
        public ActionResult Details(int id)
        {
           var restTab = db.RestTabs.Where(r => r.RestId == id).FirstOrDefault();
            return View(restTab);
        }
        public ActionResult AddRest()
        {
            //var rests = db.RestTabs.ToList();
            //if (rests != null)
            //{
            //    ViewBag.data = rests;
            //}
            return View();
        }

        [HttpPost]
        public ActionResult AddRest(RestTab restTab)
        {
            db.RestTabs.Add(restTab);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateRes(int id)
        {
            var resupadte=db.RestTabs.Where(r => r.RestId == id).FirstOrDefault();
            return View(resupadte);
        }
        [HttpPost]
        public ActionResult UpdateRes(RestTab restTab)
        {
            var updatedres = db.RestTabs.Where(e => e.RestId == restTab.RestId).FirstOrDefault();
            updatedres.RestName = restTab.RestName;
            updatedres.CusineType = restTab.CusineType;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteRes(int id)
        {
            var delres=db.RestTabs.Where(r => r.RestId == id).FirstOrDefault();
            return View(delres);
        }

        [HttpPost]
        public ActionResult DeleteRes(int id,RestTab restTab)
        {
            var delres = db.RestTabs.Where(e => e.RestId == id).FirstOrDefault();
            db.RestTabs.Remove(delres);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}