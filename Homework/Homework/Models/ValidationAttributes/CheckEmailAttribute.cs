using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homework.Models.ValidationAttributes
{
    public class CheckEmailAttribute: DataTypeAttribute
    {
        public CheckEmailAttribute() : base(DataType.Text)
        { }

        public override bool IsValid(object value)
        {
            客戶資料Entities db = new 客戶資料Entities();
            var str = (string)value;
            return db.客戶資料.Where(p => p.Email.Contains(str)).ToList().Count == 0;
        }
    }


}