using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
namespace Homework.Models.ValidationAttributes
{
    public class CheckCellPhoneAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            //not input
            if (value == null)
                return true;
            //has input
            if (value is String)
                //手機應該都是開頭，並且有10碼，所以利用正則表示式來表示就是這樣
                //IsMatch本身就是bool的回傳值，所以利用直接回傳這個值，就可以表示是否已經通過驗證
                return Regex.IsMatch(value.ToString(), @"\d{4}-\d{6}");
            else
                return true;
        }

        
    }
}