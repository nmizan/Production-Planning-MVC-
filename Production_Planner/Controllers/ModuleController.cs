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
    public class ModuleController : Controller
    {
        private ProductionPlannerEntities db = new ProductionPlannerEntities();
        public CategoryModel unitModel = new CategoryModel();
        // GET: /Module/
        public ActionResult Index()
        {
           
            var prp_module = db.PRP_MODULE.Include(p => p.HRP_COMPUNIT).Include(p => p.HRP_SECTION).Include(p => p.MER_GAUGE);
            return View(prp_module.ToList ());
        }

        // GET: /Module/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRP_MODULE prp_module = db.PRP_MODULE.Find(id);
            if (prp_module == null)
            {
                return HttpNotFound();
            }
            return View(prp_module);
        }

        // GET: /Module/Create
        public ActionResult Create()
        {
            ViewBag.COMPCD = new SelectList(db.HRP_COMPUNIT, "COMPCD", "COMPNM");
            ViewBag.SECCODE = new SelectList(db.HRP_SECTION, "SECCODE", "SECNAME");
            ViewBag.GAUGECD = new SelectList(db.MER_GAUGE, "GAUGECD", "GAUGENM");
            ViewBag.Category = new SelectList(unitModel.CategoryList, "Value", "Text");
            
            return View();
        }

        // POST: /Module/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MODCD,COMPCD,SECCODE,MODULENM,MACTYPE,GAUGECD,WORKMINTS,MACQTY,MACEFF,PERDAYMINTS,CATEGORY,INSERTBY,INSERTDT,UPDATEBY,UPDATEDT")] PRP_MODULE prp_module)
        {
            if (ModelState.IsValid)
            {
                db.PRP_MODULE.Add(prp_module);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COMPCD = new SelectList(db.HRP_COMPUNIT, "COMPCD", "COMPNM", prp_module.COMPCD);
            ViewBag.SECCODE = new SelectList(db.HRP_SECTION, "SECCODE", "SECNAME", prp_module.SECCODE);
            ViewBag.GAUGECD = new SelectList(db.MER_GAUGE, "GAUGECD", "GAUGENM", prp_module.GAUGECD);
            ViewBag.Category = new SelectList(unitModel.CategoryList, "Value", "Text",prp_module.CATEGORY);
            return View(prp_module);
        }

        // GET: /Module/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRP_MODULE prp_module = db.PRP_MODULE.Find(id);
            if (prp_module == null)
            {
                return HttpNotFound();
            }
            ViewBag.COMPCD = new SelectList(db.HRP_COMPUNIT, "COMPCD", "COMPNM", prp_module.COMPCD);
            ViewBag.SECCODE = new SelectList(db.HRP_SECTION, "SECCODE", "SECNAME", prp_module.SECCODE);
            ViewBag.GAUGECD = new SelectList(db.MER_GAUGE, "GAUGECD", "GAUGENM", prp_module.GAUGECD);
            ViewBag.Category = new SelectList(unitModel.CategoryList, "Value", "Text", prp_module.CATEGORY);
            
            return View(prp_module);
        }

        // POST: /Module/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MODCD,COMPCD,SECCODE,MODULENM,MACTYPE,GAUGECD,WORKMINTS,MACQTY,MACEFF,PERDAYMINTS,CATEGORY,INSERTBY,INSERTDT,UPDATEBY,UPDATEDT")] PRP_MODULE prp_module)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prp_module).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COMPCD = new SelectList(db.HRP_COMPUNIT, "COMPCD", "COMPNM", prp_module.COMPCD);
            ViewBag.SECCODE = new SelectList(db.HRP_SECTION, "SECCODE", "SECNAME", prp_module.SECCODE);
            ViewBag.GAUGECD = new SelectList(db.MER_GAUGE, "GAUGECD", "GAUGENM", prp_module.GAUGECD);
            ViewBag.Category = new SelectList(unitModel.CategoryList, "Value", "Text", prp_module.CATEGORY);
            return View(prp_module);
        }

        // GET: /Module/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRP_MODULE prp_module = db.PRP_MODULE.Find(id);
            if (prp_module == null)
            {
                return HttpNotFound();
            }
            return View(prp_module);
        }

        // POST: /Module/Delete/5

        //[HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRP_MODULE prp_module = db.PRP_MODULE.Find(id);
            db.PRP_MODULE.Remove(prp_module);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('Deleted Module Information Succesfully !!');</script>";
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

        public ActionResult ModuleListForFactory(int? id, int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var prp_module = db.PRP_MODULE.Include(p => p.HRP_COMPUNIT).Include(p => p.HRP_SECTION).Include(p => p.MER_GAUGE).Where(p => p.COMPCD == id).OrderBy(p => p.MODCD);
            return View(prp_module.ToPagedList(pageNumber, pageSize));
        }

        public JsonResult GetSections()
        {
            var resultSections = db.HRP_SECTION.Select(c => new
            {
                id = c.SECCODE,
                name = c.SECNAME

            }).ToList();
            return Json(resultSections, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetGauges()
        {
            var resultGauges = db.MER_GAUGE.Select(d => new
            {
                id = d.GAUGECD,
                name = d.GAUGENM

            }).ToList();
            return Json(resultGauges, JsonRequestBehavior.AllowGet);
        }
       

        public JsonResult ModuleListToFilter()
        {
            var result = (from b in db.PRP_MODULE
                          join c in db.HRP_COMPUNIT on b.COMPCD equals c.COMPCD into bc
                          from c in bc.DefaultIfEmpty()
                          join d in db.HRP_SECTION on b.SECCODE equals d.SECCODE into cd
                          from d in cd.DefaultIfEmpty()
                          join e in db.MER_GAUGE on b.GAUGECD equals e.GAUGECD into de
                          from e in de.DefaultIfEmpty()
                          select new
                          {
                              MODULENM = b.MODULENM,
                              MACTYPE = b.MACTYPE,
                              WORKMINTS = b.WORKMINTS,
                              MACQTY = b.MACQTY,
                              MACEFF = b.MACEFF,
                              PERDAYMINTS = b.PERDAYMINTS,
                              CATEGORY = b.CATEGORY,
                              FactoryName = b.HRP_COMPUNIT.COMPNM,
                              SectionName = b.HRP_SECTION.SECNAME,
                              GaugeName = b.MER_GAUGE.GAUGENM,
                              ModuleCode = b.MODCD,
                              Section = b.SECCODE,
                              Gauge = b.GAUGECD
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

       
        public JsonResult SearchBySection(int? sectionid = 0 )
        {
            
            if (sectionid != 0)
            {
                var result = (from b in db.PRP_MODULE
                              where b.SECCODE == sectionid
                              select new
                              {
                                  MODULENM = b.MODULENM,
                                  MACTYPE = b.MACTYPE,
                                  WORKMINTS = b.WORKMINTS,
                                  MACQTY = b.MACQTY,
                                  MACEFF = b.MACEFF,
                                  PERDAYMINTS = b.PERDAYMINTS,
                                  CATEGORY = b.CATEGORY,
                                  FactoryName = b.HRP_COMPUNIT.COMPNM,
                                  SectionName = b.HRP_SECTION.SECNAME,
                                  GaugeName = b.MER_GAUGE.GAUGENM,
                                  ModuleCode = b.MODCD,
                                  Section = b.SECCODE,
                                  Gauge = b.GAUGECD
                                 
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = (from b in db.PRP_MODULE
                              join c in db.HRP_COMPUNIT on b.COMPCD equals c.COMPCD into bc
                              from c in bc.DefaultIfEmpty()
                              join d in db.HRP_SECTION on b.SECCODE equals d.SECCODE into cd
                              from d in cd.DefaultIfEmpty()
                              join e in db.MER_GAUGE on b.GAUGECD equals e.GAUGECD into de
                              from e in de.DefaultIfEmpty()
                              select new
                              {
                                  MODULENM = b.MODULENM,
                                  MACTYPE = b.MACTYPE,
                                  WORKMINTS = b.WORKMINTS,
                                  MACQTY = b.MACQTY,
                                  MACEFF = b.MACEFF,
                                  PERDAYMINTS = b.PERDAYMINTS,
                                  CATEGORY = b.CATEGORY,
                                  FactoryName = b.HRP_COMPUNIT.COMPNM,
                                  SectionName = b.HRP_SECTION.SECNAME,
                                  GaugeName = b.MER_GAUGE.GAUGENM,
                                  ModuleCode = b.MODCD,
                                  Section = b.SECCODE,
                                  Gauge = b.GAUGECD
                                 
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult SearchByGauge(int? gaugeid = 0)
        {

            if (gaugeid != 0)
            {
                var result = (from b in db.PRP_MODULE
                              where b.GAUGECD == gaugeid
                              select new
                              {
                                  MODULENM = b.MODULENM,
                                  MACTYPE = b.MACTYPE,
                                  WORKMINTS = b.WORKMINTS,
                                  MACQTY = b.MACQTY,
                                  MACEFF = b.MACEFF,
                                  PERDAYMINTS = b.PERDAYMINTS,
                                  CATEGORY = b.CATEGORY,
                                  FactoryName = b.HRP_COMPUNIT.COMPNM,
                                  SectionName = b.HRP_SECTION.SECNAME,
                                  GaugeName = b.MER_GAUGE.GAUGENM,
                                  ModuleCode = b.MODCD,
                                  Section = b.SECCODE,
                                  Gauge = b.GAUGECD
                                 
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = (from b in db.PRP_MODULE
                              join c in db.HRP_COMPUNIT on b.COMPCD equals c.COMPCD into bc
                              from c in bc.DefaultIfEmpty()
                              join d in db.HRP_SECTION on b.SECCODE equals d.SECCODE into cd
                              from d in cd.DefaultIfEmpty()
                              join e in db.MER_GAUGE on b.GAUGECD equals e.GAUGECD into de
                              from e in de.DefaultIfEmpty()
                              select new
                              {
                                  MODULENM = b.MODULENM,
                                  MACTYPE = b.MACTYPE,
                                  WORKMINTS = b.WORKMINTS,
                                  MACQTY = b.MACQTY,
                                  MACEFF = b.MACEFF,
                                  PERDAYMINTS = b.PERDAYMINTS,
                                  CATEGORY = b.CATEGORY,
                                  FactoryName = b.HRP_COMPUNIT.COMPNM,
                                  SectionName = b.HRP_SECTION.SECNAME,
                                  GaugeName = b.MER_GAUGE.GAUGENM,
                                  ModuleCode = b.MODCD,
                                  Section = b.SECCODE,
                                  Gauge = b.GAUGECD
                                  
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
          }

        
      }
    }

