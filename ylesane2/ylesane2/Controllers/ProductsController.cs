using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ylesane2.Models;

namespace ylesane2.Controllers
{
    public class ProductsController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Products
        public ActionResult Index()
        {
            ViewBag.Title = "Products list";
            Product product = new Product();
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Add item";
            Product product = new Product();
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,CreatedTime,StartTime,EndTime")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Create
        public ActionResult ToBook(int? id)
        {
            ViewBag.Days = db.WorkDays.Where(x => x.Status == 0).OrderBy(x => x.DateIn);
            ViewBag.Title = "Book item";
            ViewBag.Days = db.WorkDays.Where(x => x.Status == 0 && x.DateIn >= DateTime.Now);

            //Product product = new Product();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            
            return View(product);
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ToBook([Bind(Include = "Id,Name,Description,Price,CreatedTime,StartTime,EndTime,WorkDayId")] Product product)
        {
            Service service = new Service();
            if (ModelState.IsValid)
            {
                    
                WorkDay day = db.WorkDays.FirstOrDefault(x => x.Id == product.WorkDayId);
                day.Status = 1;
                product.EndTime = day.DateIn;
                service.ProductId = product.Id;
                service.ProductName = product.Name;
                service.ProductPrice = product.Price;
                //service.ProductDesc = product.Description;

                service.UserId = Convert.ToInt32(Session["Id"]);
                service.Name = Convert.ToString(Session["Name"]);
                service.SecondName = Convert.ToString(Session["SecondName"]);
                service.PhoneNumber = Convert.ToString(Session["PhoneNumber"]);
                service.Email = Convert.ToString(Session["Email"]);

                service.StartTime = DateTime.Now;
                service.EndTime = product.EndTime;
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //if (ModelState.IsValid)
            //{

            //    service.ProductId = product.Id;
            //    service.ProductName = product.Name;
            //    service.ProductPrice = product.Price;

            //    service.UserId = Convert.ToInt32(Session["Id"]);
            //    service.Name = Convert.ToString(Session["Name"]);
            //    service.SecondName = Convert.ToString(Session["SecondName"]);
            //    service.PhoneNumber = Convert.ToString(Session["PhoneNumber"]);
            //    service.Email = Convert.ToString(Session["Email"]);

            //    service.StartTime = DateTime.Now;
            //    service.EndTime = product.EndTime;
            //    db.Services.Add(service);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            ViewBag.Days = db.WorkDays.Where(x => x.Status == 0);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Title = "Edit item";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,CreatedTime,StartTime,EndTime")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.Title = "Delete item";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
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
