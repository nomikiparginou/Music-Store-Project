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
    public class CustomersController : Controller
    {
        private ChinookEntities db = new ChinookEntities();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.Employee);
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.SupportRepId = new SelectList(db.Employees, "EmployeeId", "LastName");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,FirstName,LastName,Company,Address,City,State,Country,PostalCode,Phone,Fax,Email,SupportRepId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SupportRepId = new SelectList(db.Employees, "EmployeeId", "LastName", customer.SupportRepId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupportRepId = new SelectList(db.Employees, "EmployeeId", "LastName", customer.SupportRepId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,FirstName,LastName,Company,Address,City,State,Country,PostalCode,Phone,Fax,Email,SupportRepId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SupportRepId = new SelectList(db.Employees, "EmployeeId", "LastName", customer.SupportRepId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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

        //methods for Report IV
        public ActionResult InputReportIV()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InputReportIV(string beginDate, string endDate)
        {
            using (var context = new ChinookEntities())
            {

                if (beginDate.Equals("") || endDate.Equals(""))
                    return RedirectToAction("InputReportIV");

                SqlParameter[] Parameters = {
                    new SqlParameter("@BeginDate", beginDate),
                    new SqlParameter("@EndDate", endDate)
                };
                var repIV = context.Database.SqlQuery<ReportIV_Result>("[dbo].[ReportIV] @Begindate, @EndDate", Parameters).ToList();
                TempData["repIV"] = repIV;
                return RedirectToAction("printReportIV");
            }
        }
        public ActionResult printReportIV()
        {
            return View(TempData["repIV"]);
        }
        //method for Report V
        public ActionResult InputReportV()
        {
            var entities = new ChinookEntities();
            ViewBag.Employees = new SelectList(entities.Employees, "EmployeeId", "fullname");
            ViewBag.Customers = new SelectList(entities.Customers, "CustomerId", "fullname");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InputReportV(int CustId, int EmpId, string BeginDate, string EndDate)
        {
            using (var context = new ChinookEntities())
            {

                if (CustId.Equals("") || EmpId.Equals("") || BeginDate.Equals("") || EndDate.Equals(""))
                    return RedirectToAction("InputReportV");

                Customer customer = db.Customers.Find(CustId);
                string CFName = customer.FirstName.ToString();
                string CLName = customer.LastName.ToString();
                Employee employee = db.Employees.Find(EmpId);
                string EFName = employee.FirstName.ToString();
                string ELName = employee.LastName.ToString();
                SqlParameter[] Parameters = {
                    new SqlParameter("@BeginDate", BeginDate),
                    new SqlParameter("@EndDate", EndDate),
                    new SqlParameter("@CustomerFName", CFName),
                    new SqlParameter("@CustomerLName", CLName),
                    new SqlParameter("@EmployeeFName", EFName),
                    new SqlParameter("@EmployeeLName", ELName)
                };
                var repV = context.Database.SqlQuery<ReportV_Result>("[dbo].[ReportV] @Begindate, @EndDate," +
                                " @CustomerFName, @CustomerLName, @EmployeeFName, @EmployeeLName", Parameters).ToList();
                TempData["repV"] = repV;
                return RedirectToAction("printReportV");
            }
        }
        public ActionResult printReportV()
        {
            return View(TempData["repV"]);
        }
    }
 }

