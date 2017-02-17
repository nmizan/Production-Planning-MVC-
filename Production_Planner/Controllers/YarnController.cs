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
    public class YarnController : Controller
    {
        private ProductionPlannerEntities db = new ProductionPlannerEntities();

        // GET: /Yarn/
        public ActionResult Index(int ? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var mer_yarninfo = db.MER_YARNINFO.Include(m => m.MER_UNIT).OrderBy(m=>m.YARNCD);
            return View(mer_yarninfo.ToPagedList(pageNumber,pageSize));
        }

        // GET: /Yarn/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MER_YARNINFO mer_yarninfo = db.MER_YARNINFO.Find(id);
            if (mer_yarninfo == null)
            {
                return HttpNotFound();
            }
            return View(mer_yarninfo);
        }

        // GET: /Yarn/Create
        public ActionResult Create()
        {
            ViewBag.UNITCD = new SelectList(db.MER_UNIT, "UNITCD", "UNITNM");
            return View();
        }

        // POST: /Yarn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="YARNCD,YARNDESC,UNITCD,INSERTBY,INSERTDT,UPDATEBY,UPDATEDT")] MER_YARNINFO mer_yarninfo)
        {
            if (ModelState.IsValid)
            {
                db.MER_YARNINFO.Add(mer_yarninfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UNITCD = new SelectList(db.MER_UNIT, "UNITCD", "UNITNM", mer_yarninfo.UNITCD);
            return View(mer_yarninfo);
        }

        // GET: /Yarn/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MER_YARNINFO mer_yarninfo = db.MER_YARNINFO.Find(id);
            if (mer_yarninfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.UNITCD = new SelectList(db.MER_UNIT, "UNITCD", "UNITNM", mer_yarninfo.UNITCD);
            return View(mer_yarninfo);
        }

        // POST: /Yarn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="YARNCD,YARNDESC,UNITCD,INSERTBY,INSERTDT,UPDATEBY,UPDATEDT")] MER_YARNINFO mer_yarninfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mer_yarninfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UNITCD = new SelectList(db.MER_UNIT, "UNITCD", "UNITNM", mer_yarninfo.UNITCD);
            return View(mer_yarninfo);
        }

        // GET: /Yarn/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MER_YARNINFO mer_yarninfo = db.MER_YARNINFO.Find(id);
            if (mer_yarninfo == null)
            {
                return HttpNotFound();
            }
            return View(mer_yarninfo);
        }

        // POST: /Yarn/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            MER_YARNINFO mer_yarninfo = db.MER_YARNINFO.Find(id);
            db.MER_YARNINFO.Remove(mer_yarninfo);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('Deleted Yarn Information Succesfully !!');</script>";
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
