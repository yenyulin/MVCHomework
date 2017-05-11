namespace Homework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ValidationAttributes;

    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人
    {
    }
    
    public partial class 客戶聯絡人MetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int 客戶Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 職稱 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 姓名 { get; set; }

        [Required]
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [DataType(DataType.EmailAddress)]
        //[CheckEmailAttribute(ErrorMessage = "email已被使用")]
        public string Email { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [CheckCellPhoneAttribute(ErrorMessage = "格式為 e.g. 0911-111111")]
        public string 手機 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 電話 { get; set; }
        [Required]
        public bool 刪除 { get; set; }
    
        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
