using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Production_Planner.Models;
using PagedList;

namespace Production_Planner.Controllers
{
    public class CountryController : Controller
    {
        private ProductionPlannerEntities db = new ProductionPlannerEntities();

        // GET: /Country/
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var country = db.CMN_COUNTRY.OrderBy(x => x.CONCD);
            return View(country.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Country/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMN_COUNTRY cmn_country = db.CMN_COUNTRY.Find(id);
            if (cmn_country == null)
            {
                return HttpNotFound();
            }
            return View(cmn_country);
        }

        // GET: /Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Country/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CONCD,CONNM,COUNTRY_CODE,INSERTBY,INSERTDT,UPDATEBY,UPDATEDT")] CMN_COUNTRY cmn_country)
        {
            if (ModelState.IsValid)
            {
                db.CMN_COUNTRY.Add(cmn_country);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cmn_country);
        }

        // GET: /Country/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMN_COUNTRY cmn_country = db.CMN_COUNTRY.Find(id);
            if (cmn_country == null)
            {
                return HttpNotFound();
            }
            return View(cmn_country);
        }

        // POST: /Country/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CONCD,CONNM,COUNTRY_CODE,INSERTBY,INSERTDT,UPDATEBY,UPDATEDT")] CMN_COUNTRY cmn_country)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cmn_country).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cmn_country);
        }

        // GET: /Country/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMN_COUNTRY cmn_country = db.CMN_COUNTRY.Find(id);
            if (cmn_country == null)
            {
                return HttpNotFound();
            }
            return View(cmn_country);
        }

        // POST: /Country/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {

            CMN_COUNTRY cmn_country = db.CMN_COUNTRY.Find(id);
            db.CMN_COUNTRY.Remove(cmn_country);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('Deleted Country Information Succesfully !!');</script>";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
