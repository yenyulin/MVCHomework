using System;
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
    public class 客戶簡覽Controller : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: 客戶簡覽
        public ActionResult Index(string search = "")
        {
            var dt = db.客戶簡覽.AsQueryable();
            
            if (search != null)
            {
                if (search.Length > 0)
                {
                    dt = db.客戶簡覽.Where(p => p.客戶名稱.Contains(search));
                }
            }
            //.OrderByDescending(p => p.ProductId).Take(10);
            //return View(db.Product.Take(10));
            return View(dt.ToList());
            
        }

        // GET: 客戶簡覽/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶簡覽 客戶簡覽 = db.客戶簡覽.Find(id);
            if (客戶簡覽 == null)
            {
                return HttpNotFound();
            }
            return View(客戶簡覽);
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
