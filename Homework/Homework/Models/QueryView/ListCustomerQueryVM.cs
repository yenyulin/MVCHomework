using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework.Models
{
    public class ListCustomerQueryVM//: IValidatableObject
    {
        public string strKeyword { get; set; }
        public int 客戶類別ID { get; set; }

        //public List<SelectListItem> CustomerTypes { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    //if (this.Stock_E < this.Stock_S)
        //    //{
        //    //    yield return new ValidationResult("庫存資料篩選條件錯誤", new string[] { "Stock_S", "Stock_E" });
        //    //}
        //}

    }
}