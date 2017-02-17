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
    public class SectionController : Controller
    {
        private ProductionPlannerEntities db = new ProductionPlannerEntities();

        // GET: /Section/
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var section = db.HRP_SECTION.OrderBy(x => x.SECCODE);
            return View(section.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Section/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HRP_SECTION hrp_section = db.HRP_SECTION.Find(id);
            if (hrp_section == null)
            {
                return HttpNotFound();
            }
            return View(hrp_section);
        }

        // GET: /Section/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Section/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SECCODE,SECNAME,SECNMBG,SECFLOOR,PRSYMBOL,PSLNO,INSERTBY,INSERTDT,UPDATEBY,UPDATEDT,LAGGING_SLNO,LAGGING_HEADING")] HRP_SECTION hrp_section)
        {
            if (ModelState.IsValid)
            {
                db.HRP_SECTION.Add(hrp_section);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hrp_section);
        }

        // GET: /Section/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HRP_SECTION hrp_section = db.HRP_SECTION.Find(id);
            if (hrp_section == null)
            {
                return HttpNotFound();
            }
            return View(hrp_section);
        }

        // POST: /Section/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SECCODE,SECNAME,SECNMBG,SECFLOOR,PRSYMBOL,PSLNO,INSERTBY,INSERTDT,UPDATEBY,UPDATEDT,LAGGING_SLNO,LAGGING_HEADING")] HRP_SECTION hrp_section)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hrp_section).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hrp_section);
        }

        // GET: /Section/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HRP_SECTION hrp_section = db.HRP_SECTION.Find(id);
            if (hrp_section == null)
            {
                return HttpNotFound();
            }
            return View(hrp_section);
        }

        // POST: /Section/Delete/5
       
        //[HttpPost, ActionName("Delete")]
       // [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            HRP_SECTION hrp_section = db.HRP_SECTION.Find(id);
            db.HRP_SECTION.Remove(hrp_section);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('Deleted Section Information Succesfully !!');</script>";
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
