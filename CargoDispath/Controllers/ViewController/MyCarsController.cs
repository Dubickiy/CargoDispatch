﻿using CargoDispath.DAL.EF;
using CargoDispath.DAL.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoDispath.Controllers.ViewController
{
    public class MyCarsController : Controller
    {
        private CargoContext db = new CargoContext("DBConnection");
        // GET: MyCars
        [Authorize]
        public ActionResult AddCar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCar([Bind(Include = "Name,Number,Type,Body,Label,Weight,Volume,LoadingType,AddedInfo,Driver,TrailerNumber,TrailerLabel,hasTrailer")] Car car, IEnumerable<HttpPostedFileBase> CarPhoto,
            IEnumerable<HttpPostedFileBase> TechPhoto)
        {
            string currentUserId = User.Identity.GetUserId();
            car.UserId = currentUserId;
            if (TechPhoto != null)
            {
                foreach (var file in TechPhoto)
                {
                    if (file != null)
                    {
                        var binaryReader = new BinaryReader(file.InputStream);
                        var imageBase64Data = Convert.ToBase64String(binaryReader.ReadBytes(file.ContentLength));
                        car.Photos.Add(new Photo { Name = "TechPhoto", Value = imageBase64Data, CarId = car.Id, });
                    }
                    else
                    {
                        ModelState.AddModelError("TechPhoto", "Наличие фото тех.паспорта - обязательно");
                    }
                }
            }
            if (CarPhoto != null)
            {
                foreach (var file in CarPhoto)
                {
                    if (file != null)
                    {
                        //string imageFileName = Path.GetFileName(file.FileName);
                        var binaryReader = new BinaryReader(file.InputStream);
                        var imageBase64Data = Convert.ToBase64String(binaryReader.ReadBytes(file.ContentLength));
                        car.Photos.Add(new Photo { Name = "CarPhoto", Value = imageBase64Data, CarId = car.Id, });
                    }
                }
            }

            db._Cars.Add(car);
            db.SaveChanges();
            return Redirect("/MyCars/AllCars");
        }
        public ActionResult AllCars()
        {
            return View();
        }
        public ActionResult GetVehicleTypes()
        {

            db._VehicleTypes.Load();
            var data = db._VehicleTypes.Local.ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPhoto(int? id)
        {
            var photo = db._Photos.Where(a => a.CarId == id);
            //var photos = db._mycars.Where(a => a.Id == id);
            return Json(photo, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetCarInfo(String name)
        {
            db._UserCars.Load();
            var data = db._Cars.Where(a => a.Name == name);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
      
            
    }
}