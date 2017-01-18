using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForChepa.Models;
using System.Data.Entity;
namespace ForChepa.Controllers
{
    public class CountriesController : Controller
    {
        TopographyContext tc = new TopographyContext();
        // GET: Countries
        public ActionResult Index()
        {
            IEnumerable<Countries> c = tc.Countries;
            return View(c.ToList());
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Countries ct = tc.Countries.Find(id);
            if (ct != null)
            {
                return View(ct);
            }
            return HttpNotFound();

        }
        [HttpPost]
        public ActionResult Edit(Countries ct)
        {
            tc.Entry(ct).State = EntityState.Modified;
            tc.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Countries ct)
        {
            tc.Countries.Add(ct);
            tc.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Countries ct = tc.Countries.Find(id);
            if (ct == null)
            {
                return HttpNotFound();
            }
            return View(ct);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            Countries ct = tc.Countries.Find(id);

            if (ct == null)
            {
                return HttpNotFound();
            }
            tc.Countries.Remove(ct);
            tc.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return HttpNotFound();
            }
            Countries ck = tc.Countries.Find(id);
           
            if (ck == null)
            {
                return HttpNotFound();
            }
            return View(ck);
        
    }
    }
}