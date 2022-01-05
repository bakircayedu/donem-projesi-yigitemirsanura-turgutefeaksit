using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using MVCTrainProject.Models;

namespace MVCTrainProject.Controllers
{
    public class ParkController : Controller
    {
        car_parkEntities db = new car_parkEntities();
        // GET: Park
        public ActionResult Index()
        {
            var values = db.park_place.ToList();
            return View(values);
        }

        public ActionResult CustomerIndex()
        {
            var values = db.park_place.ToList();
            return View(values);
        }

        //[HttpGet]
        //public ActionResult Park_Registration()
        //{
        //    IEnumClass cs = new IEnumClass();
        //    cs.CarEnum = db.car.ToList();
        //    cs.ParkEnum = db.park_place.ToList();

        //    List<SelectListItem> carValues = (from i in db.car.ToList()
        //                                      select new SelectListItem
        //                                      {
        //                                          Text = i.car_plate,
        //                                          Value = i.car_plate.ToString()
        //                                      }).ToList();
        //    ViewBag.vl = carValues;

        //    List<SelectListItem> parkValues = (from i in db.park_place.ToList()
        //                                       select new SelectListItem
        //                                       {

        //                                           Text = i.loc_number.ToString(),
        //                                           Value = i.loc_number.ToString()
        //                                       }
        //                                       ).ToList();
        //    ViewBag.vl2 = parkValues;

        //    return View(cs);
        //}
        //[HttpPost]
        //public ActionResult Park_Registration(registration_date r)
        //{
        //    r.entery_time = DateTime.Now;
        //    db.registration_date.Add(r);
        //    db.SaveChanges();
        //    return View();
        //}
        //,,,,,

        public ActionResult Park_Registration()
        {
            ViewBag.car_id = new SelectList(db.car, "car_id", "car_plate");
            ViewBag.loc_number = new SelectList(db.park_place, "loc_number", "occupancy_info").Where(p => p.Text == "BOŞ");
            //ViewBag.loc_number = new SelectList(db.park_place, "loc_number", "loc_number").Where(p => p. == "BOŞ"); 
            return View();
        }

        [HttpPost]
        public ActionResult Park_Registration([Bind(Include = "r_date_id,car_id,leave_time,entery_time,loc_number")] registration_date r)
        {
            var park = db.park_place.Find(r.loc_number);
            park.occupancy_info = "DOLU";
            r.park_place = park;
            r.entery_time = DateTime.Now;
            db.registration_date.Add(r);
            db.SaveChanges();
            return RedirectToAction("ParkList");


            //ViewBag.carID = new SelectList(db.car, "car_id", "car_plate");
            //return View(r);
        }

        public ActionResult ParkList()
        {
            var values = db.registration_date.ToList();
            return View(values);
        }

        public ActionResult Registration_Delete()
        {
            var values = db.registration_date.ToList();
            return View(values);
        }

        public ActionResult End_Process(int id)
        {
            var item = db.registration_date.Find(id);
            var park = db.park_place.Find(item.loc_number);
            park.occupancy_info = "BOŞ";
            item.park_place = park;
            item.leave_time = DateTime.Now;
            db.SaveChanges();
            return View("ParkList");
        }


    }
}