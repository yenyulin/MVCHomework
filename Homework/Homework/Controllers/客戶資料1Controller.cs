﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homework.Models;

namespace Homework.Controllers
{
    public class 客戶資料1Controller : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        //// GET: 客戶資料
        //public ActionResult Index(string search="")
        //{
        //    var dt = db.客戶資料.Where(p => p.刪除 == false);
        //    if (search != null)
        //    {
        //        if (search.Length > 0)
        //        {
        //            dt = db.客戶資料.
        //            Where(p => p.刪除 == false && (p.Email.Contains(search) | p.客戶名稱.Contains(search)));
        //        }
        //    }          
        //    //.OrderByDescending(p => p.ProductId).Take(10);
        //    //return View(db.Product.Take(10));
        //    return View(dt.ToList());            
        //}

        //// GET: 客戶資料/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    客戶資料 客戶資料 = db.客戶資料.Find(id);
        //    if (客戶資料 == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(客戶資料);
        //}

        //// GET: 客戶資料/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: 客戶資料/Create
        //// 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        //// 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,刪除")] 客戶資料 客戶資料)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.客戶資料.Add(客戶資料);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(客戶資料);
        //}

        //// GET: 客戶資料/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    客戶資料 客戶資料 = db.客戶資料.Find(id);
        //    if (客戶資料 == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(客戶資料);
        //}

        //// POST: 客戶資料/Edit/5
        //// 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        //// 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,刪除")] 客戶資料 客戶資料)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(客戶資料).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(客戶資料);
        //}


        //// GET: 客戶資料/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    客戶資料 客戶資料 = db.客戶資料.Find(id);
        //    if (客戶資料 == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(客戶資料);
        //}

        //// POST: 客戶資料/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    客戶資料 CustomerData = db.客戶資料.Find(id);
        //    CustomerData.刪除 = true;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
