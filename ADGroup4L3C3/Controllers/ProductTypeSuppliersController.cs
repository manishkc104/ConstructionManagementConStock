using System;
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
    public class ProductTypeSuppliersController : Controller
    {
        private ADG4_L3C3Entities db = new ADG4_L3C3Entities();


        // GET: ProductTypeSuppliers
        public ActionResult Index()
        {


            var productTypeSupplier = db.ProductTypeSupplier.Include(p => p.ProductType).Include(p => p.UserAccounts).Include(p => p.Suppliers);
            return View(productTypeSupplier.ToList());
        }

        // GET: ProductTypeSuppliers/Details/5
        public ActionResult Details(int? ptid,int? sid)
        {


            if (sid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTypeSupplier productTypeSupplier = db.ProductTypeSupplier.Find(ptid, sid);
            if (productTypeSupplier == null)
            {
                return HttpNotFound();
            }
            return View(productTypeSupplier);
        }

        // GET: ProductTypeSuppliers/Create
        public ActionResult Create()
        {


            ViewBag.ProductTypeID = new SelectList(db.ProductType, "ProductTypeID", "ProductTypeName");
            ViewBag.ModifiedBy = new SelectList(db.UserAccounts, "UserAccountID", "Email");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierEmail");
            return View();
        }

        // POST: ProductTypeSuppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductTypeSupplierID,ProductTypeID,SupplierID,DateCreated,DateModified,ModifiedBy")] ProductTypeSupplier productTypeSupplier)
        {
            if (ModelState.IsValid)
            {
                db.ProductTypeSupplier.Add(productTypeSupplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductTypeID = new SelectList(db.ProductType, "ProductTypeID", "ProductTypeName", productTypeSupplier.ProductTypeID);
            ViewBag.ModifiedBy = new SelectList(db.UserAccounts, "UserAccountID", "Email", productTypeSupplier.ModifiedBy);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierEmail", productTypeSupplier.SupplierID);
            return View(productTypeSupplier);
        }

        // GET: ProductTypeSuppliers/Edit/5
        public ActionResult Edit(int? ptid, int?sid)
        {


            if (sid == null && ptid==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTypeSupplier productTypeSupplier = db.ProductTypeSupplier.Find(ptid,sid);
            if (productTypeSupplier == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductTypeID = new SelectList(db.ProductType, "ProductTypeID", "ProductTypeName", productTypeSupplier.ProductTypeID);
            ViewBag.ModifiedBy = new SelectList(db.UserAccounts, "UserAccountID", "Email", productTypeSupplier.ModifiedBy);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierEmail", productTypeSupplier.SupplierID);
            return View(productTypeSupplier);
        }

        // POST: ProductTypeSuppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductTypeSupplierID,ProductTypeID,SupplierID,DateCreated,DateModified,ModifiedBy")] ProductTypeSupplier productTypeSupplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productTypeSupplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductTypeID = new SelectList(db.ProductType, "ProductTypeID", "ProductTypeName", productTypeSupplier.ProductTypeID);
            ViewBag.ModifiedBy = new SelectList(db.UserAccounts, "UserAccountID", "Email", productTypeSupplier.ModifiedBy);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierEmail", productTypeSupplier.SupplierID);
            return View(productTypeSupplier);
        }

        // GET: ProductTypeSuppliers/Delete/5
        public ActionResult Delete(int? ptid, int? sid)
        {


            if (sid == null && ptid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTypeSupplier productTypeSupplier = db.ProductTypeSupplier.Find(ptid,sid);
            if (productTypeSupplier == null)
            {
                return HttpNotFound();
            }
            return View(productTypeSupplier);
        }

        // POST: ProductTypeSuppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductTypeSupplier productTypeSupplier = db.ProductTypeSupplier.Find(id);
            db.ProductTypeSupplier.Remove(productTypeSupplier);
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
