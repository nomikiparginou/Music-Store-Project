using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class InvoiceStatisticsController : Controller
    {
        private ChinookEntities db = new ChinookEntities();

        // GET: InvoiceStatistics
        public ActionResult Index()
        {
            return View(db.InvoiceStatistics.ToList());
        }

        // GET: InvoiceStatistics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceStatistic invoiceStatistic = db.InvoiceStatistics.Find(id);
            if (invoiceStatistic == null)
            {
                return HttpNotFound();
            }
            return View(invoiceStatistic);
        }

        // GET: InvoiceStatistics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceStatistics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenreId,TrackId,TotalTrackCharge,TimeCreated")] InvoiceStatistic invoiceStatistic)
        {
            if (ModelState.IsValid)
            {
                db.InvoiceStatistics.Add(invoiceStatistic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(invoiceStatistic);
        }

        // GET: InvoiceStatistics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceStatistic invoiceStatistic = db.InvoiceStatistics.Find(id);
            if (invoiceStatistic == null)
            {
                return HttpNotFound();
            }
            return View(invoiceStatistic);
        }

        // POST: InvoiceStatistics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GenreId,TrackId,TotalTrackCharge,TimeCreated")] InvoiceStatistic invoiceStatistic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoiceStatistic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invoiceStatistic);
        }

        // GET: InvoiceStatistics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceStatistic invoiceStatistic = db.InvoiceStatistics.Find(id);
            if (invoiceStatistic == null)
            {
                return HttpNotFound();
            }
            return View(invoiceStatistic);
        }

        // POST: InvoiceStatistics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvoiceStatistic invoiceStatistic = db.InvoiceStatistics.Find(id);
            db.InvoiceStatistics.Remove(invoiceStatistic);
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

        //method for Invoice statistics
        public ActionResult InvoiceStatistics()
        {
            using (var context = new ChinookEntities())
            {
                var invstats = context.InvoiceStatistics.SqlQuery("[dbo].[InvStats]").ToList();
                return View(invstats);
            }
        }
    }
}
