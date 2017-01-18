using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ForChepa.Models;

namespace ForChepa.Controllers
{
    public class HomeController : Controller
    {
        TopographyContext tc = new TopographyContext();
        public ActionResult Index()
        {
            IEnumerable<Cities> c = tc.Cities;
            return View(c.ToList());
        }
        [HttpGet]
        public ActionResult Edit(int ?id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            Cities c = tc.Cities.Find(id);
            if (c!=null)
            {
                return View(c);
            }
            return HttpNotFound();

        }
        [HttpPost]
        public ActionResult Edit(Cities c)
        {
            tc.Entry(c).State = EntityState.Modified;
            tc.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cities c)
        {
            tc.Cities.Add(c);
            tc.SaveChanges();
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Cities c = tc.Cities.Find(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            Cities c = tc.Cities.Find(id);
            
            if (c == null)
            {
                return HttpNotFound();
            }
            tc.Cities.Remove(c);
            tc.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }
            Cities ck = tc.Cities.Find(id);

            if (ck == null)
            {
                return HttpNotFound();
            }
            return View(ck);

        }
    }
}