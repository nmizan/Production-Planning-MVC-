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
    public class FactoryInfoController : Controller
    {
        private ProductionPlannerEntities db = new ProductionPlannerEntities();

        // GET: /FactoryInfo/
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var factory = db.HRP_COMPUNIT.OrderBy(x => x.COMPCD);
            return View(factory.ToPagedList(pageNumber, pageSize));
        }
        public JsonResult GetAllFactoryInfo()
        {
            var factories = db.HRP_COMPUNIT.ToList();
            return Json(factories , JsonRequestBehavior.AllowGet);
        }
       
        // GET: /FactoryInfo/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HRP_COMPUNIT hrp_compunit = db.HRP_COMPUNIT.Find(id);
            if (hrp_compunit == null)
            {
                return HttpNotFound();
            }
            return View(hrp_compunit);
        }

        // GET: /FactoryInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /FactoryInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="COMPCD,COMPNM,SHORTNM,COMPNMB,ADDRS1,ADDRS2,ADDRSBG1,ADDRSBG2,PHONE,MOBILNO,FAX,EMAIL,WEB,LOGO_IMAGE,INSERTBY,INSERTDT,UPDATEBY,UPDATEDT")] HRP_COMPUNIT hrp_compunit)
        {
            if (ModelState.IsValid)
            {
                db.HRP_COMPUNIT.Add(hrp_compunit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hrp_compunit);
        }

        // GET: /FactoryInfo/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HRP_COMPUNIT hrp_compunit = db.HRP_COMPUNIT.Find(id);
            if (hrp_compunit == null)
            {
                return HttpNotFound();
            }
            return View(hrp_compunit);
        }

        // POST: /FactoryInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="COMPCD,COMPNM,SHORTNM,COMPNMB,ADDRS1,ADDRS2,ADDRSBG1,ADDRSBG2,PHONE,MOBILNO,FAX,EMAIL,WEB,LOGO_IMAGE,INSERTBY,INSERTDT,UPDATEBY,UPDATEDT")] HRP_COMPUNIT hrp_compunit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hrp_compunit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hrp_compunit);
        }

         //GET: /FactoryInfo/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HRP_COMPUNIT hrp_compunit = db.HRP_COMPUNIT.Find(id);
            if (hrp_compunit == null)
            {
                return HttpNotFound();
            }
            return View(hrp_compunit);
        }

        // POST: /FactoryInfo/Delete/5
        
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            HRP_COMPUNIT hrp_compunit = db.HRP_COMPUNIT.Find(id);
            db.HRP_COMPUNIT.Remove(hrp_compunit);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('Deleted Factory Information Succesfully !!');</script>";
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
