using Production_Planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Production_Planner.ViewDataModel;

namespace Production_Planner.Controllers
{
    public class OrderInfoController : Controller
    {
        private ProductionPlannerEntities db = new ProductionPlannerEntities();
        //
        // GET: /OrderInfo/
        public ActionResult Index()
        {
            return View();
        }





        public ActionResult AddOrderInfoRow()
        {

            ViewBag.OrderColor = new SelectList(db.MER_ORDERCOLOR, "ORDCOLCD", "ORDCOLNM");
            ViewBag.YarnType = new SelectList(db.MER_YARNINFO, "YARNCD", "YARNDESC");
            return PartialView("PartialOrderInfo");
        }
        public ActionResult AddOrderDetailsRow()
        {

            ViewBag.Section = new SelectList(db.HRP_SECTION, "SecCode", "SecName");
            ViewBag.Category = new SelectList(db.MER_ORDER_CATEGORY, "Category", "Category");   
            return PartialView("PartialOrderDetails");
        }
        public ActionResult Create()
        {
            ViewBag.Guage = new SelectList(db.MER_GAUGE, "GAUGECD", "GAUGENM");
            ViewBag.LC = new SelectList(db.MER_LCREGIS, "LCSLNO", "LCNO");
            ViewBag.OrderColor = new SelectList(db.MER_ORDERCOLOR, "ORDCOLCD", "ORDCOLNM");
            ViewBag.YarnType = new SelectList(db.MER_YARNINFO, "YARNCD", "YARNDESC");
            ViewBag.Buyer = new SelectList(db.MER_COMPCODE, "COMPCD", "COMPNM");
           ViewBag.Section = new SelectList(db.HRP_SECTION,"SecCode","SecName");
           ViewBag.Category = new SelectList(db.MER_ORDER_CATEGORY, "Category", "Category");            
            return View();
        }






        [HttpPost]
        public ActionResult Create(Order OM)
        {
            int getORDSLNO = db.MER_ORDERMAS.Select(x => x.ORDSLNO).Max();

            if (db.MER_ORDERMAS.Any(x => x.ORDSLNO == getORDSLNO))
            { 
            
            }
            else
            {
                getORDSLNO += 1;
                MER_ORDERMAS orderMass = new MER_ORDERMAS();
                orderMass.ORDSLNO = getORDSLNO;
                orderMass.COMPCD = OM.COMPCD;
                orderMass.ORDSLNO = getORDSLNO;
                orderMass.SKETCHNO = OM.SKETCHNO;
                orderMass.STYLENO = OM.STYLENO;
                orderMass.GAUGECD = OM.GAUGECD;
                orderMass.ORDTYPE = OM.ORDTYPE;
                orderMass.ORDMETHOD = OM.ORDMETHOD;
                orderMass.STATUS = OM.STATUS;
                orderMass.REMARKS = OM.REMARKS;
                orderMass.ORDFLAG = "N";
                orderMass.FLAGIMG = "N";
                orderMass.INSERTBY = 1;
                orderMass.INSERTDT = DateTime.Now;
                db.MER_ORDERMAS.Add(orderMass);
                db.SaveChanges();
              
            }




            ViewBag.Guage = new SelectList(db.MER_GAUGE, "GAUGECD", "GAUGENM");
            ViewBag.LC = new SelectList(db.MER_LCREGIS, "LCSLNO", "LCNO");
            ViewBag.OrderColor = new SelectList(db.MER_ORDERCOLOR, "ORDCOLCD", "ORDCOLNM");
            ViewBag.YarnType = new SelectList(db.MER_YARNINFO, "YARNCD", "YARNDESC");
            ViewBag.Buyer = new SelectList(db.MER_COMPCODE, "COMPCD", "COMPNM");
            ViewBag.Section = new SelectList(db.HRP_SECTION, "SecCode", "SecName");
            ViewBag.Category = new SelectList(db.MER_ORDER_CATEGORY, "Category", "Category");
            ViewBag.OrderSLNo = getORDSLNO;
            return View();
        }


  
        public ActionResult CreateOrderInfo(List<MER_ORDERDET> OrderDetails, int OrderSLNo)
        {


            var getSLNo = db.MER_ORDERDET.Where(x => x.ORDSLNO == OrderSLNo).Count();

            ///order det data start

            MER_ORDERDET od = new MER_ORDERDET();

            foreach (var item in OrderDetails.ToList())
            {
                var CountOderDet = db.MER_ORDERDET.Count();
                var OrderRefNo = "";
                if (CountOderDet == 0)
                {
                    OrderRefNo = "X000001";
                }
                else
                {

                    OrderRefNo = string.Format("X{0:000000}", CountOderDet + 1);
                }



                od.INSERTBY = 1;
                od.INSERTDT = DateTime.Now;
                od.ORD_REFNO = OrderRefNo;
                od.ORDERNO = item.ORDERNO;
                od.ORDCOLCD = item.ORDCOLCD;
                od.YARNCD = item.YARNCD;
                od.ORDQTY = item.ORDQTY;
                od.ORDDATED = item.ORDDATED;
                od.SHIPDATE = item.SHIPDATE;
                od.TOTYARNQTY = 0;
                od.YARNQTY = 0;
                od.SLNO = Convert.ToByte( getSLNo + 1);
                od.PRODQTY = item.ORDQTY;
                od.ORDSLNO = OrderSLNo;

                db.MER_ORDERDET.Add(od);
                db.SaveChanges();

                getSLNo++;
            }



            ViewBag.Guage = new SelectList(db.MER_GAUGE, "GAUGECD", "GAUGENM");
            ViewBag.LC = new SelectList(db.MER_LCREGIS, "LCSLNO", "LCNO");
            ViewBag.OrderColor = new SelectList(db.MER_ORDERCOLOR, "ORDCOLCD", "ORDCOLNM");
            ViewBag.YarnType = new SelectList(db.MER_YARNINFO, "YARNCD", "YARNDESC");
            ViewBag.Buyer = new SelectList(db.MER_COMPCODE, "COMPCD", "COMPNM");
            ViewBag.Section = new SelectList(db.HRP_SECTION, "SecCode", "SecName");
            ViewBag.Category = new SelectList(db.MER_ORDER_CATEGORY, "Category", "Category");

            //,List<MER_ORDERDET> OrderDetails

            ViewBag.OrderSLNo = OrderSLNo;
            return View("Create");

        }

       

	}
}