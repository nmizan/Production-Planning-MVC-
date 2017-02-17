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
    public class HolidayController : Controller
    {
        private ProductionPlannerEntities db = new ProductionPlannerEntities();

       
        public JsonResult GetAllHolidays()
        {
            object allHolidays;

            allHolidays = from h in db.HRP_HOLIDAY.ToList().OrderBy(x=>x.HOLDATE)
                          select new
                          {
                              id= h.HOLDATE.ToString(),
                              title = h.HOLTYPE.ToString(),
                              start = h.HOLDATE.ToString("yyyy-MM-dd"),
                              htype= h.HOLTYPE.ToString(),
                              wday = h.WORKDAY.ToString(),
                              insid = h.INSERTBY.ToString(),
                              remarks=h.HOLREMARKS
                     
                           
                             
                          };

            return Json(allHolidays, JsonRequestBehavior.AllowGet);
        }


















        [HttpPost]
        public JsonResult EditHolidays(DateTime id, DateTime start, string htype, byte wday, string remarks,short insid)
        {
            string message = "";
          
                try
                {

                    HRP_HOLIDAY hrp_holiday = db.HRP_HOLIDAY.Find(id);


                    if (hrp_holiday != null)
                    {
                        db.HRP_HOLIDAY.Remove(hrp_holiday);
                        db.SaveChanges();

                        hrp_holiday.HOLDATE = start;
                        hrp_holiday.HOLTYPE = htype;
                        hrp_holiday.WORKDAY = wday;
                        hrp_holiday.HOLREMARKS = remarks;
                        hrp_holiday.INSERTDT = DateTime.Now;
                        db.HRP_HOLIDAY.Add(hrp_holiday);
                        db.SaveChanges();


                    }


                   


                }
                catch (Exception ex)
                {
                   
                    message = "failed";
                }
            

            return new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        [HttpPost]
        public JsonResult DeleteHolidays(DateTime id)
        {
            string message = "";

            try
            {

                HRP_HOLIDAY hrp_holiday = db.HRP_HOLIDAY.Find(id);


                if (hrp_holiday != null)
                {
                    db.HRP_HOLIDAY.Remove(hrp_holiday);
                    db.SaveChanges();

                }


                else
                {
                    message = "failedyyyy";
                }



            }
            catch (Exception ex)
            {
                message = "failed";
            }

            return new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

      



        // GET: /Holiday/
        public ActionResult Index()
        {
            //int pageSize = 5;
            //int pageNumber = (page ?? 1);
            //var hrp_holiday = db.HRP_HOLIDAY.OrderBy(a => a.HOLDATE);
            return View();
        }

        // GET: /Holiday/Details/5
      
        // GET: /Holiday/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Holiday/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DateTime hdate, string htype, byte wday, string remarks)
        {
           
                HRP_HOLIDAY hrp_holiday = new HRP_HOLIDAY();
                hrp_holiday.HOLDATE = hdate;
                hrp_holiday.HOLTYPE = htype;
                hrp_holiday.WORKDAY = wday;
                hrp_holiday.HOLREMARKS = remarks;
                hrp_holiday.INSERTBY = 1;
                hrp_holiday.INSERTDT = DateTime.Now;

                try
                {
                if (ModelState.IsValid)
                {
                    db.HRP_HOLIDAY.Add(hrp_holiday);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
               
            }
            catch (Exception ex)
            {
                TempData["msg"] = "<script>alert('error to save data !!');</script>";
                
            }

                return View("Index");
        }

        // GET: /Holiday/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HRP_HOLIDAY hrp_holiday = db.HRP_HOLIDAY.Find(id);
            if (hrp_holiday == null)
            {
                return HttpNotFound();
            }
            return View(hrp_holiday);
        }

        // POST: /Holiday/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="HOLDATE,HOLTYPE,WDAYBEFOREHDAY,WDAYAFTERHDAY,WORKDAY,HOLREMARKS,INSERTBY,INSERTDT,UPDATEBY,UPDATEDT")] HRP_HOLIDAY hrp_holiday)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hrp_holiday).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hrp_holiday);
        }

        // GET: /Holiday/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HRP_HOLIDAY hrp_holiday = db.HRP_HOLIDAY.Find(id);
            if (hrp_holiday == null)
            {
                return HttpNotFound();
            }
            return View(hrp_holiday);
        }

        // POST: /Holiday/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            HRP_HOLIDAY hrp_holiday = db.HRP_HOLIDAY.Find(id);
            db.HRP_HOLIDAY.Remove(hrp_holiday);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('Deleted Holiday Information Succesfully !!');</script>";
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


        [HttpPost]
        public JsonResult Create_Holiday(HRP_HOLIDAY  holidyinfo)
        {
            string message = "";

            try
            {
                if (ModelState.IsValid)
                {
                    using (ProductionPlannerEntities dc = new ProductionPlannerEntities())
                    {

                        if (holidyinfo!=null)
                        {

                            dc.HRP_HOLIDAY.Add(holidyinfo);
                            dc.SaveChanges();
                            
                        }
                        else
                        {
                            message = "failed";
                        }

                    }
                }
                else
                {
                    message = "failed";
                }
            }
            catch (Exception ex)
            {
                message = "failed"+ex.ToString();
            }

            return new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
