﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ADGroup4L3C3.Models;
using ADGroup4L3C3.ViewModel;

namespace ADGroup4L3C3.Controllers
{
    public class UserTypesController : Controller
    {
        private ADG4_L3C3Entities db = new ADG4_L3C3Entities();


        // GET: UserTypes
        public ActionResult Index()
        {


            return View(db.UserType.ToList());
        }

        // GET: UserTypes/Details/5
        public ActionResult Details(int? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserType userType = db.UserType.Find(id);
            if (userType == null)
            {
                return HttpNotFound();
            }
            return View(userType);
        }

        // GET: UserTypes/Create
        public ActionResult Create()
        {


            return View();
        }

        // POST: UserTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserTypeID,UserTypeName,DateCreated,DateModified")] UserType userType)
        {
            if (ModelState.IsValid)
            {
                db.UserType.Add(userType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userType);
        }

        // GET: UserTypes/Edit/5
        public ActionResult Edit(int? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserType userType = db.UserType.Find(id);
            if (userType == null)
            {
                return HttpNotFound();
            }
            return View(userType);
        }

        // POST: UserTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserTypeID,UserTypeName,DateCreated,DateModified")] UserType userType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userType);
        }

        // GET: UserTypes/Delete/5
        public ActionResult Delete(int? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserType userType = db.UserType.Find(id);
            if (userType == null)
            {
                return HttpNotFound();
            }
            return View(userType);
        }

        // POST: UserTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserType userType = db.UserType.Find(id);
            db.UserType.Remove(userType);
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
