using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homework.Models;
using PagedList;

using ClosedXML;
using ClosedXML.Excel;
using System.IO;
using System.Data.SqlClient;
using System.Reflection;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.Security;

namespace Homework.Controllers
{


    public class 客戶資料Controller : BaseController
    {
        private const int DefaultPageSize = 5;
        //private 客戶資料Entities db = new 客戶資料Entities();

        public ActionResult Index(int? page, ListCustomerQueryVM searchCondition)
        {
            int currentPageIndex = page.HasValue ? page.Value  : 1;
            
           ViewBag.客戶類別ID = new SelectList(db.客戶類別, "客戶類別ID", "CustomerType");
            //ViewBag.客戶類別ID = new SelectList(db.客戶類別, "客戶類別ID", "CustomerType", 客戶資料.客戶類別ID);

            var data = repo.GetCustomerByActive();
            if (searchCondition.strKeyword != null)
            {
                data = repo.GetIndexListByKeywordAndType(searchCondition.strKeyword, searchCondition.客戶類別ID).OrderByDescending(p => p.Id);
            }
           
            ViewData.Model = data.ToList().ToPagedList(currentPageIndex, DefaultPageSize);
            return View();
        }

       
        public ActionResult ExportData( ListCustomerQueryVM searchCondition)
        {
            //剛好以下是別人去取資料回來
            //String constring = ConfigurationManager.ConnectionStrings["RConnection"].ConnectionString;
            //SqlConnection con = new SqlConnection(constring);
            //string query = "select * From Employee";
            //DataTable dt = new DataTable();
            //dt.TableName = "Employee";
            //con.Open();
            //SqlDataAdapter da = new SqlDataAdapter(query, con);
            //da.Fill(dt);
            //con.Close();

            var data = repo.GetCustomerByActive();
            if (searchCondition.strKeyword != null)
            {
                data = repo.GetIndexListByKeywordAndType(searchCondition.strKeyword, searchCondition.客戶類別ID).OrderByDescending(p => p.Id);
            }

            DataTable dt = ConvertObjectsToDataTable(data);// new DataTable();

            //var gv = new GridView();
            //gv.DataSource = data;
            //gv.DataBind();

            //Response.ClearContent();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
            //Response.ContentType = "application/ms-excel";

            //Response.Charset = "";
            //StringWriter objStringWriter = new StringWriter();
            //HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

            //gv.RenderControl(objHtmlTextWriter);

            //Response.Output.Write(objStringWriter.ToString());
            //Response.Flush();
            //Response.End();
            //return RedirectToAction("Index", "客戶資料");

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Sheet1");
                wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                wb.Style.Font.Bold = true;

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= EmployeeReport.xlsx");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
            return RedirectToAction("Index", "客戶資料");
        }

        public static DataTable ConvertObjectsToDataTable(IEnumerable<object> objects)
        {
            DataTable dt = null;

            if (objects != null && objects.Count() > 0)
            {
                Type type = objects.First().GetType();
                dt = new DataTable(type.Name);

                foreach (PropertyInfo property in type.GetProperties())
                {
                    dt.Columns.Add(new DataColumn(property.Name));
                }

                foreach (FieldInfo field in type.GetFields())
                {
                    dt.Columns.Add(new DataColumn(field.Name));
                }

                foreach (object obj in objects)
                {
                    DataRow dr = dt.NewRow();
                    foreach (DataColumn column in dt.Columns)
                    {
                        PropertyInfo propertyInfo = type.GetProperty(column.ColumnName);
                        if (propertyInfo != null)
                        {
                            dr[column.ColumnName] = propertyInfo.GetValue(obj, null);
                        }

                        FieldInfo fieldInfo = type.GetField(column.ColumnName);
                        if (fieldInfo != null)
                        {
                            dr[column.ColumnName] = fieldInfo.GetValue(obj);
                        }
                    }
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }




        // GET: 客戶資料
        //public ActionResult Index(ListCustomerQueryVM searchCondition)
        //{
        //    ViewBag.客戶類別ID = new SelectList(db.客戶類別, "客戶類別ID", "CustomerType");

        //    var data = repo.GetCustomerByActive();
        //    if (searchCondition.strKeyword != null)
        //    {
        //        data = repo.GetIndexListByKeywordAndType(searchCondition.strKeyword, searchCondition.客戶類別ID);
        //    }

        //    ViewData.Model = data.ToList();
        //    return View();
        //}



        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = repo.GetByID(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            ViewBag.客戶類別ID = new SelectList(db.客戶類別, "客戶類別ID", "CustomerType");
            return View();
        }

        // POST: 客戶資料/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [宣告客戶分類的物件]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,刪除,客戶類別ID,帳號,密碼")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                客戶資料.密碼 = FormsAuthentication.HashPasswordForStoringInConfigFile(客戶資料.密碼, "SHA1");
                repo.Add(客戶資料);
                repo.UnitOfWork.Commit();
                
                return RedirectToAction("Index");
            }

            ViewBag.客戶類別ID = new SelectList(db.客戶類別, "客戶類別ID", "CustomerType", 客戶資料.客戶類別ID);
            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        [宣告客戶分類的物件]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 =repo.GetByID(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }

            //老師的解法是讓密碼直接不帶值
            var emptyValue = new ValueProviderResult(string.Empty, string.Empty, System.Globalization.CultureInfo.CurrentCulture);
            ModelState.SetModelValue("密碼", emptyValue);
            //下面也行
            //客戶資料.密碼 = "";


            ViewBag.客戶類別ID = new SelectList(db.客戶類別, "客戶類別ID", "CustomerType", 客戶資料.客戶類別ID);
            return View(客戶資料);
        }

        // POST: 客戶資料/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [宣告客戶分類的物件]
        //public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,刪除,客戶類別ID")] 客戶資料 客戶資料)
        public ActionResult Edit(int id,FormCollection form)
        {
            var 客戶資料 = repo.GetByID(id);
            var oldPW = 客戶資料.密碼;


            if (TryUpdateModel(客戶資料))
            {
                if (!String.IsNullOrEmpty(客戶資料.密碼))
                {
                    客戶資料.密碼 = FormsAuthentication.HashPasswordForStoringInConfigFile(客戶資料.密碼, "SHA1");
                }
                else
                {
                    客戶資料.密碼 = oldPW;
                };
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            //if (ModelState.IsValid)
            //{
            //    db.Entry(客戶資料).State = EntityState.Modified;

            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            ViewBag.客戶類別ID = new SelectList(db.客戶類別, "客戶類別ID", "CustomerType", 客戶資料.客戶類別ID);
            return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            客戶資料 客戶資料 = repo.GetByID(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            客戶資料 客戶資料 = repo.GetByID(id);
            repo.Delete(客戶資料);
            repo.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
