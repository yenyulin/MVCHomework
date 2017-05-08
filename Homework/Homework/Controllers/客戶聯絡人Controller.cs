using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework.Models;

namespace Homework.Controllers
{
    public class 客戶聯絡人Controller : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: 客戶聯絡人
        public ActionResult Index()
        {
            var dt = db.客戶聯絡人.
                Where(p => p.刪除 == false).ToList();
                //.OrderByDescending(p => p.ProductId).Take(10);

            return View(dt);

        }

        // GET: 客戶聯絡人/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: 客戶聯絡人/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: 客戶聯絡人/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] 客戶聯絡人 product)
        {
            if (ModelState.IsValid)
            {

                db.客戶聯絡人.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: 客戶聯絡人/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: 客戶聯絡人/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶聯絡人 CustomerContants = db.客戶聯絡人.Find(id);
            CustomerContants.刪除 = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //// GET: 客戶聯絡人/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: 客戶聯絡人/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
