using Production_Planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace Production_Planner.Controllers
{
    public class DashboardV1Controller : Controller
    {
        private ProductionPlannerEntities db = new ProductionPlannerEntities();
        //
        // GET: /DashboardV1/
        public ActionResult Index()
        {
            ViewBag.COMPCD = new SelectList(db.HRP_COMPUNIT, "COMPCD", "COMPNM");
            ViewBag.SECCODE = new SelectList(db.HRP_SECTION, "SECCODE", "SECNAME");
            ViewBag.GAUGECD = new SelectList(db.MER_GAUGE, "GAUGECD", "GAUGENM");
            return View();
        }
        public ActionResult ModuleCreate()
        {



            ViewBag.COMPCD = new SelectList(db.HRP_COMPUNIT, "COMPCD", "COMPNM");
            ViewBag.SECCODE = new SelectList(db.HRP_SECTION, "SECCODE", "SECNAME");
            ViewBag.GAUGECD = new SelectList(db.MER_GAUGE, "GAUGECD", "GAUGENM");
            return View();
        }

        // POST: /myModule/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult ModuleCreate(PRP_MODULE prp_module, byte COMPCD, byte SECCODE, int ModuleNm, string MACTYPE, byte GAUGECD, short WORKMINTS, short MACQTY, byte MACEFF, int PERDAYMINTS, string CATAGORY)
        {
            prp_module.COMPCD = COMPCD;
            prp_module.SECCODE = SECCODE;
            prp_module.MODULENM = ModuleNm;
            prp_module.MACTYPE = MACTYPE;
            prp_module.GAUGECD = GAUGECD;
            prp_module.WORKMINTS = WORKMINTS;
            prp_module.MACQTY = MACQTY;
            prp_module.MACEFF = MACEFF;
            prp_module.PERDAYMINTS = PERDAYMINTS;
            prp_module.CATEGORY = CATAGORY;
            prp_module.INSERTBY = 1;
            prp_module.INSERTDT = DateTime.Now;



            if (ModelState.IsValid)
            {

                int getId = db.PRP_MODULE.Select(x => x.MODCD).Max() + 1;

                prp_module.MODCD = getId;

                db.PRP_MODULE.Add(prp_module);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.COMPCD = new SelectList(db.HRP_COMPUNIT, "COMPCD", "COMPNM");
            ViewBag.SECCODE = new SelectList(db.HRP_SECTION, "SECCODE", "SECNAME");
            ViewBag.GAUGECD = new SelectList(db.MER_GAUGE, "GAUGECD", "GAUGENM");
            return View(prp_module);
        }

      
        public ActionResult myPView(int? page,int?GaugeCode)
        {
            
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            //ViewBag.GuageName = db.MER_GAUGE.Where(x => x.GAUGECD == GaugeCode).Select(x => x.GAUGENM).First();
     
            

            return PartialView("_PView", db.PRP_MODULE.OrderByDescending(x=>x.MODCD).ToPagedList(pageNumber, pageSize));

        }

       
	}
}