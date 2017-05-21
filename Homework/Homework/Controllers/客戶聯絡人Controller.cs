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
    public class 客戶聯絡人Controller : Controller
    {
        //private 客戶資料Entities db = new 客戶資料Entities();

        客戶聯絡人Repository repo = RepositoryHelper.Get客戶聯絡人Repository();// new 客戶聯絡人Repository();
        客戶資料Repository 客戶資料repo;

        public 客戶聯絡人Controller()
        {
            客戶資料repo = RepositoryHelper.Get客戶資料Repository(repo.UnitOfWork);
        }

        // GET: 客戶聯絡人
        public ActionResult Index( string sort , bool? desc, string search = "")
        {

            var dt = repo.All().Include(客 => 客.客戶資料).Where(p => p.刪除 == false);
            if (search != null)
            {
                if (search.Length > 0)
                {
                    dt = repo.All().Include(客 => 客.客戶資料)
                    .Where(p => p.刪除 == false && (p.職稱.Contains(search) | p.姓名.Contains(search) | p.Email.Contains(search)));
                }
            }
            if (sort != null)
            {
                switch (sort)
                {
                    case "職稱":
                        if (desc.HasValue && desc.Value)
                        {
                            dt = dt.OrderByDescending(m => m.職稱);
                        }
                        else
                        {
                            dt = dt.OrderBy(m => m.職稱);
                        }
                       
                        break;
                    case "姓名":
                        if (desc.HasValue && desc.Value)
                        {
                            dt = dt.OrderByDescending(m => m.姓名);
                        }
                        else
                        {
                            dt = dt.OrderBy(m => m.姓名);
                        }
                        break;
                }
                   
            }
            return View(dt.ToList());

        }

        // GET: 客戶聯絡人/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            客戶聯絡人 客戶聯絡人 = repo.GetByID(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(客戶資料repo.All(), "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶聯絡人/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話,刪除")] 客戶聯絡人 客戶聯絡人)
        {
            客戶聯絡人 email = repo.All().FirstOrDefault(u => u.Email.ToLower() == 客戶聯絡人.Email.ToLower() && u.客戶Id== 客戶聯絡人.客戶Id);
            //try
            //{
                // Check if email already exists
                if (email == null)
                {
                    repo.Add(客戶聯絡人);
                    repo.UnitOfWork.Commit();
                    //db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Email", "Email address already exists. Please enter a different email address.");
                    ViewBag.客戶Id = new SelectList(客戶資料repo.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
                    return View(客戶聯絡人);
                }
            //}
            //catch (MembershipCreateUserException e)
            //{
            //    ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            //    return View(客戶聯絡人);
            //    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
            //}


            // If we got this far, something failed, redisplay form
            //return View(model);

            //if (ModelState.IsValid)
            //{
            //    //db email = db.客戶聯絡人.FirstOrDefault(u => u.Email.ToLower() == 客戶聯絡人.Email.ToLower());

            //    db.客戶聯絡人.Add(客戶聯絡人);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            //return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo.GetByID(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(客戶資料repo.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話,刪除")] 客戶聯絡人 客戶聯絡人)
        public ActionResult Edit(int id, FormCollection form)
        {
            var 客戶聯絡人 = repo.GetByID(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            if (TryUpdateModel<客戶聯絡人>(客戶聯絡人))
            {
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            
            ViewBag.客戶Id = new SelectList(客戶資料repo.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo.GetByID(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶聯絡人 客戶聯絡人 = repo.GetByID(id);
            repo.Delete(客戶聯絡人);
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.UnitOfWork.Context.Dispose();
                //不用做兩次 因為unitofwork是共用的
                //客戶資料repo.UnitOfWork.Context.Dispose();
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
