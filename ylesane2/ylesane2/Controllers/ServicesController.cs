using PagedList;
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
    public class ServicesController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        //GET: Services
        //public ActionResult Index()
        //{
        //    return View(db.Services.ToList());
        //}

        public ActionResult Index(string sortOrder, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var Services = from s in db.Services
                           select s;
            switch (sortOrder)
            {
                case "name_desc":
                    Services = Services.OrderByDescending(s => s.ProductName);
                    break;
                case "Date":
                    Services = Services.OrderBy(s => s.EndTime);
                    break;
                case "date_desc":
                    Services = Services.OrderByDescending(s => s.EndTime);
                    break;
                default:
                    Services = Services.OrderBy(s => s.ProductName);
                    break;
            }
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(Services.ToPagedList(pageNumber, pageSize));
            //return View(workDays.ToList());
        }

        // GET: User Services
        public ActionResult UserServices(int? id)
        {
            Service service = new Service();

            if (Session["Email"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(db.Services.ToList().Where(x => x.Email == (string)Session["Email"]));
        }

        // GET: Services/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: Services/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,userId,Email,Name,SecondName,PhoneNumber,productId,productName,productPrice,StartTime,EndTime")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(service);
        }

        // GET: Services/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Days = db.WorkDays.Where(x => x.Status == 0).OrderBy(x => x.DateIn);
            ViewBag.Days = db.WorkDays.Where(x => x.Status == 0 && x.DateIn >= DateTime.Now);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,userId,Email,Name,SecondName,PhoneNumber,productId,productName,productPrice,StartTime,EndTime,WorkDayId")] Service service)
        {
            if (ModelState.IsValid)
            {
                WorkDay day = db.WorkDays.FirstOrDefault(x => x.Id == service.WorkDayId);
                day.Status = 1;
                service.EndTime = day.DateIn;
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Days = db.WorkDays.Where(x => x.Status == 0);
            return View(service);
        }

        // GET: Services/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
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
