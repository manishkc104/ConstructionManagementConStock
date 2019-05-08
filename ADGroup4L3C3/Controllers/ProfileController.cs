﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ADGroup4L3C3.Models;
using ADGroup4L3C3.ViewModel;

namespace ADGroup4L3C3.Controllers
{
    public class ProfileController : Controller
    {
        private ADG4_L3C3Entities db = new ADG4_L3C3Entities();


        // GET: UserAccounts
        public ActionResult Index()
        {
            int UserAccountID = Convert.ToInt32(HttpContext.Session["UserAccountID"]);
            var userAccounts = db.UserAccounts.Include(u => u.UserAccounts2).Include(u => u.UserType).Where(u => u.UserAccountID == UserAccountID);
            return View(userAccounts.ToList());
        }

        
        // GET: UserAccounts/Edit/5
        public ActionResult Edit(int? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccounts userAccounts = db.UserAccounts.Find(id);
            if (userAccounts == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModifiedBy = new SelectList(db.UserAccounts, "UserAccountID", "Email", userAccounts.ModifiedBy);
            ViewBag.UserTypeID = new SelectList(db.UserType, "UserTypeID", "UserTypeName", userAccounts.UserTypeID);
            return View(userAccounts);
        }

        // POST: UserAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserAccountID,UserTypeID,Email,Password,DateCreated,DateModified,ModifiedBy")] UserAccounts userAccounts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAccounts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModifiedBy = new SelectList(db.UserAccounts, "UserAccountID", "Email", userAccounts.ModifiedBy);
            ViewBag.UserTypeID = new SelectList(db.UserType, "UserTypeID", "UserTypeName", userAccounts.UserTypeID);
            return View(userAccounts);
        }

        [HttpPost]
        public async Task<ActionResult> EditPassword(string oldpassword, string newpassword, string confirmpassword)
        {
            using(ADG4_L3C3Entities db = new ADG4_L3C3Entities())
            {
                try
                {
                    int UserAccountID = Convert.ToInt32(HttpContext.Session["UserAccountID"]);

                    if (newpassword != null && confirmpassword != null && newpassword != "" && confirmpassword != "")
                    {
                        var user = db.UserAccounts.Where(u => u.UserAccountID == UserAccountID).FirstOrDefault();
                        if(user.Password == oldpassword)
                        {
                            if (newpassword == oldpassword)
                            {
                                await QueryHelper.UpdatePassowrd(db, UserAccountID, confirmpassword);
                                return View("Index");
                            }
                            else
                            {
                                throw new Exception("Confirm Password Mismatched.");
                            }
                        }
                        else
                        {
                            throw new Exception("Incorrect Current Password");
                        }
                      
                    }
                    else
                    {
                        throw new Exception("All fields are required.");
                    }
                }
                catch(Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return View();
                }
            }          
        }
    }
}
