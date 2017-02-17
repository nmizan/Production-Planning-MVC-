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
    public class UnitController : Controller
    {
        private ProductionPlannerEntities db = new ProductionPlannerEntities();

        // GET: /Unit/
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var unit = db.MER_UNIT.OrderBy(x => x.UNITCD);  
            return View(unit.ToPagedList(pageNumber , pageSize));
        }

        // GET: /Unit/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MER_UNIT mer_unit = db.MER_UNIT.Find(id);
            if (mer_unit == null)
            {
                return HttpNotFound();
            }
            return View(mer_unit);
        }

        // GET: /Unit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Unit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="UNITCD,UNITNM,BASEFLAG,CONVUNITCD,CONVVALUE,INSERTBY,INSERTDT,UPDATEBY,UPDATEDT")] MER_UNIT mer_unit)
        {
            if (ModelState.IsValid)
            {
                db.MER_UNIT.Add(mer_unit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mer_unit);
        }

        // GET: /Unit/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MER_UNIT mer_unit = db.MER_UNIT.Find(id);
            if (mer_unit == null)
            {
                return HttpNotFound();
            }
            return View(mer_unit);
        }

        // POST: /Unit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="UNITCD,UNITNM,BASEFLAG,CONVUNITCD,CONVVALUE,INSERTBY,INSERTDT,UPDATEBY,UPDATEDT")] MER_UNIT mer_unit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mer_unit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mer_unit);
        }

        // GET: /Unit/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MER_UNIT mer_unit = db.MER_UNIT.Find(id);
            if (mer_unit == null)
            {
                return HttpNotFound();
            }
            return View(mer_unit);
        }

        // POST: /Unit/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            MER_UNIT mer_unit = db.MER_UNIT.Find(id);
            db.MER_UNIT.Remove(mer_unit);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('Deleted Unit Information Succesfully !!');</script>";
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
