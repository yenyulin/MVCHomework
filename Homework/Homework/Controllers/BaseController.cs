using Homework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework.Controllers
{
    public abstract class BaseController : Controller
    {
        protected 客戶資料Repository repo = RepositoryHelper.Get客戶資料Repository();
        protected 客戶銀行資訊Repository 客戶銀行資訊repo = RepositoryHelper.Get客戶銀行資訊Repository();


        protected 客戶資料Entities db = new 客戶資料Entities();


        // GET: Base
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}