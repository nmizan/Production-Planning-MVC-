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
    public class BuyerInfoController : Controller
    {
        private ProductionPlannerEntities db = new ProductionPlannerEntities();
        BuyerDataModel bdmodel = new BuyerDataModel();

        // GET: /BuyerInfo/
        public ActionResult Index(int ? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var mer_compcode = db.MER_COMPCODE.Include(m => m.CMN_COUNTRY).Include(m => m.MER_COMPCODE2).OrderBy(m=>m.COMPCD);
            return View(mer_compcode.ToPagedList(pageNumber, pageSize));
        }

        // GET: /BuyerInfo/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MER_COMPCODE mer_compcode = db.MER_COMPCODE.Find(id);
            if (mer_compcode == null)
            {
                return HttpNotFound();
            }
            return View(mer_compcode);
        }

        // GET: /BuyerInfo/Create
        public ActionResult Create()
        {
            ViewBag.CONCD = new SelectList(db.CMN_COUNTRY, "CONCD", "CONNM");
            ViewBag.BHCD = new SelectList(db.MER_COMPCODE, "COMPCD", "COMPTYPE");
            ViewBag.Territory = new SelectList(bdmodel.TerritoryList, "Value", "Text");
            ViewBag.Status = new SelectList(bdmodel.StatusList, "Value", "Text");
            ViewBag.COMPTYPE = new SelectList(bdmodel.ComTypeList, "Value", "Text");
            return View();
        }

        // POST: /BuyerInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="COMPCD,COMPTYPE,COMPNM,SHORTNM,ADDRS1,ADDRS2,CONCD,POSTCODE,PHONE,FAX,EMAIL,CONPER,BHCD,STATUS,ATTN,CC,REF,TERRITORY,INSERTBY,INSERTDT,UPDATEBY,UPDATEDT")] MER_COMPCODE mer_compcode)
        {
            if (ModelState.IsValid)
            {
                db.MER_COMPCODE.Add(mer_compcode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CONCD = new SelectList(db.CMN_COUNTRY, "CONCD", "CONNM", mer_compcode.CONCD);
            ViewBag.BHCD = new SelectList(db.MER_COMPCODE, "COMPCD", "COMPTYPE", mer_compcode.BHCD);
            ViewBag.Territory = new SelectList(bdmodel.TerritoryList, "Value", "Text", mer_compcode.TERRITORY);
            ViewBag.Status = new SelectList(bdmodel.StatusList, "Value", "Text", mer_compcode.STATUS);
            ViewBag.COMPTYPE = new SelectList(bdmodel.ComTypeList, "Value", "Text", mer_compcode.COMPTYPE);
            return View(mer_compcode);
        }

        // GET: /BuyerInfo/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MER_COMPCODE mer_compcode = db.MER_COMPCODE.Find(id);
            if (mer_compcode == null)
            {
                return HttpNotFound();
            }
            ViewBag.CONCD = new SelectList(db.CMN_COUNTRY, "CONCD", "CONNM", mer_compcode.CONCD);
            ViewBag.BHCD = new SelectList(db.MER_COMPCODE, "COMPCD", "COMPTYPE", mer_compcode.BHCD);
            ViewBag.Territory = new SelectList(bdmodel.TerritoryList, "Value", "Text", mer_compcode.TERRITORY);
            ViewBag.Status = new SelectList(bdmodel.StatusList, "Value", "Text", mer_compcode.STATUS);
            ViewBag.COMPTYPE = new SelectList(bdmodel.ComTypeList, "Value", "Text", mer_compcode.COMPTYPE);
            return View(mer_compcode);
        }

        // POST: /BuyerInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="COMPCD,COMPTYPE,COMPNM,SHORTNM,ADDRS1,ADDRS2,CONCD,POSTCODE,PHONE,FAX,EMAIL,CONPER,BHCD,STATUS,ATTN,CC,REF,TERRITORY,INSERTBY,INSERTDT,UPDATEBY,UPDATEDT")] MER_COMPCODE mer_compcode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mer_compcode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CONCD = new SelectList(db.CMN_COUNTRY, "CONCD", "CONNM", mer_compcode.CONCD);
            ViewBag.BHCD = new SelectList(db.MER_COMPCODE, "COMPCD", "COMPTYPE", mer_compcode.BHCD);
            ViewBag.Territory = new SelectList(bdmodel.TerritoryList, "Value", "Text", mer_compcode.TERRITORY);
            ViewBag.Status = new SelectList(bdmodel.StatusList, "Value", "Text", mer_compcode.STATUS);
            ViewBag.COMPTYPE = new SelectList(bdmodel.ComTypeList, "Value", "Text", mer_compcode.COMPTYPE);
            return View(mer_compcode);
        }

        // GET: /BuyerInfo/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MER_COMPCODE mer_compcode = db.MER_COMPCODE.Find(id);
            if (mer_compcode == null)
            {
                return HttpNotFound();
            }
            return View(mer_compcode);
        }

        // POST: /BuyerInfo/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            MER_COMPCODE mer_compcode = db.MER_COMPCODE.Find(id);
            db.MER_COMPCODE.Remove(mer_compcode);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('Deleted Buyer Information Succesfully !!');</script>";
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
