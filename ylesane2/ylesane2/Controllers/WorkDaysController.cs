using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ylesane2.Models;
using PagedList;

namespace ylesane2.Controllers
{
    public class WorkDaysController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: WorkDays
        //public ActionResult Index()
        //{
        //    return View(db.WorkDays.ToList());
        //}

        public ActionResult Index(string sortOrder, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var workDays = from s in db.WorkDays
                           select s;
            switch (sortOrder)
            {
                case "name_desc":
                    workDays = workDays.OrderByDescending(s => s.Status);
                    break;
                case "Date":
                    workDays = workDays.OrderBy(s => s.DateIn);
                    break;
                case "date_desc":
                    workDays = workDays.OrderByDescending(s => s.DateIn);
                    break;
                default:
                    workDays = workDays.OrderBy(s => s.Status);
                    break;
            }
            int pageSize = 14;
            int pageNumber = (page ?? 1);
            return View(workDays.ToPagedList(pageNumber, pageSize));
            //return View(workDays.ToList());
        }

        // GET: WorkDays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkDay workDay = db.WorkDays.Find(id);
            if (workDay == null)
            {
                return HttpNotFound();
            }
            return View(workDay);
        }

        // GET: WorkDays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkDays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateIn,Status")] WorkDay workDay)
        {
            if (ModelState.IsValid)
            {
                if (db.WorkDays.Where(x => x.DateIn == workDay.DateIn).FirstOrDefault() == null)
                {
                    workDay.Status = 0;
                    db.WorkDays.Add(workDay);
                    db.SaveChanges();
                    return RedirectToAction("Create");
                }
                else
                {
                    return RedirectToAction("Create");
                }
            }

            return View(workDay);
        }

        // GET: WorkDays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkDay workDay = db.WorkDays.Find(id);
            if (workDay == null)
            {
                return HttpNotFound();
            }
            return View(workDay);
        }

        // POST: WorkDays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateIn,Status")] WorkDay workDay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workDay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workDay);
        }

        // GET: WorkDays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkDay workDay = db.WorkDays.Find(id);
            if (workDay == null)
            {
                return HttpNotFound();
            }
            return View(workDay);
        }

        // POST: WorkDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkDay workDay = db.WorkDays.Find(id);
            db.WorkDays.Remove(workDay);
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
