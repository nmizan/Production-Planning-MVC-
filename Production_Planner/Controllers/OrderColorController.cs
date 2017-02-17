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
    public class OrderColorController : Controller
    {
        private ProductionPlannerEntities db = new ProductionPlannerEntities();

        // GET: /OrderColor/
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var orderColor = db.MER_ORDERCOLOR.OrderBy(a => a.ORDCOLCD);
            return View(orderColor.ToPagedList(pageNumber,pageSize));
        }

        // GET: /OrderColor/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MER_ORDERCOLOR mer_ordercolor = db.MER_ORDERCOLOR.Find(id);
            if (mer_ordercolor == null)
            {
                return HttpNotFound();
            }
            return View(mer_ordercolor);
        }

        // GET: /OrderColor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /OrderColor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ORDCOLCD,ORDCOLNM,INSERTBY,INSERTDT,UPDATEBY,UPDATEDT")] MER_ORDERCOLOR mer_ordercolor)
        {
            if (ModelState.IsValid)
            {
                db.MER_ORDERCOLOR.Add(mer_ordercolor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mer_ordercolor);
        }

        // GET: /OrderColor/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MER_ORDERCOLOR mer_ordercolor = db.MER_ORDERCOLOR.Find(id);
            if (mer_ordercolor == null)
            {
                return HttpNotFound();
            }
            return View(mer_ordercolor);
        }

        // POST: /OrderColor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ORDCOLCD,ORDCOLNM,INSERTBY,INSERTDT,UPDATEBY,UPDATEDT")] MER_ORDERCOLOR mer_ordercolor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mer_ordercolor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mer_ordercolor);
        }

        // GET: /OrderColor/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MER_ORDERCOLOR mer_ordercolor = db.MER_ORDERCOLOR.Find(id);
            if (mer_ordercolor == null)
            {
                return HttpNotFound();
            }
            return View(mer_ordercolor);
        }

        // POST: /OrderColor/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            MER_ORDERCOLOR mer_ordercolor = db.MER_ORDERCOLOR.Find(id);
            db.MER_ORDERCOLOR.Remove(mer_ordercolor);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('Deleted Order Color Information Succesfully !!');</script>";
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
