using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication16.Models;

namespace WebApplication16.Controllers
{
    public class BatteryLogController : Controller
    {
        private palcellstestEntities db = new palcellstestEntities();

        // GET: /BatteryLog/
        public ActionResult Index()
        {
            return View(db.BatteryLogs.ToList());
        }

        // GET: /BatteryLog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BatteryLog batterylog = db.BatteryLogs.Find(id);
            if (batterylog == null)
            {
                return HttpNotFound();
            }
            return View(batterylog);
        }

        // GET: /BatteryLog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /BatteryLog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BatteryID,Voltage,Current")] BatteryLog batterylog)
        {
            if (ModelState.IsValid)
            {
                db.BatteryLogs.Add(batterylog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(batterylog);
        }

        // GET: /BatteryLog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BatteryLog batterylog = db.BatteryLogs.Find(id);
            if (batterylog == null)
            {
                return HttpNotFound();
            }
            return View(batterylog);
        }

        // POST: /BatteryLog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BatteryID,Voltage,Current")] BatteryLog batterylog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(batterylog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(batterylog);
        }

        // GET: /BatteryLog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BatteryLog batterylog = db.BatteryLogs.Find(id);
            if (batterylog == null)
            {
                return HttpNotFound();
            }
            return View(batterylog);
        }

        // POST: /BatteryLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BatteryLog batterylog = db.BatteryLogs.Find(id);
            db.BatteryLogs.Remove(batterylog);
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
