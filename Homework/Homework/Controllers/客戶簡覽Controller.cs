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
        public ActionResult Index()
        {
            return View(db.客戶簡覽.ToList());
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
