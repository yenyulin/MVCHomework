using System;
using System.Web.Mvc;

namespace Homework.Controllers
{
    public class 宣告客戶分類的物件Attribute :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //ViewBag.客戶類別ID = new SelectList(db.客戶類別, "客戶類別ID", "CustomerType", 客戶資料.客戶類別ID);
            base.OnActionExecuting(filterContext);
        }
        
    }
}