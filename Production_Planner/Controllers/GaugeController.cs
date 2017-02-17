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
    public class GaugeController : Controller
    {
        private ProductionPlannerEntities db = new ProductionPlannerEntities();

        // GET: /Gauge/
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var gauge = db.MER_GAUGE.OrderBy(x => x.GAUGECD);
            return View(gauge.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Gauge/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MER_GAUGE mer_gauge = db.MER_GAUGE.Find(id);
            if (mer_gauge == null)
            {
                return HttpNotFound();
            }
            return View(mer_gauge);
        }

        // GET: /Gauge/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Gauge/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="GAUGECD,GAUGENM,INSERTBY,INSERTDT,UPDATEBY,UPDATEDT")] MER_GAUGE mer_gauge)
        {
            if (ModelState.IsValid)
            {
                db.MER_GAUGE.Add(mer_gauge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mer_gauge);
        }

        // GET: /Gauge/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MER_GAUGE mer_gauge = db.MER_GAUGE.Find(id);
            if (mer_gauge == null)
            {
                return HttpNotFound();
            }
            return View(mer_gauge);
        }

        // POST: /Gauge/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="GAUGECD,GAUGENM,INSERTBY,INSERTDT,UPDATEBY,UPDATEDT")] MER_GAUGE mer_gauge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mer_gauge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mer_gauge);
        }

        // GET: /Gauge/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MER_GAUGE mer_gauge = db.MER_GAUGE.Find(id);
            if (mer_gauge == null)
            {
                return HttpNotFound();
            }
            return View(mer_gauge);
        }

        // POST: /Gauge/Delete/5

       // [HttpPost, ActionName("Delete")]
       // [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            MER_GAUGE mer_gauge = db.MER_GAUGE.Find(id);
            db.MER_GAUGE.Remove(mer_gauge);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('Deleted Gauge Information Succesfully !!');</script>";
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
