namespace Homework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(客戶簡覽MetaData))]
    public partial class 客戶簡覽
    {
    }
    
    public partial class 客戶簡覽MetaData
    {
        [Required]
        public long 序號 { get; set; }
        public int 客戶ID { get; set; }
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 客戶名稱 { get; set; }
        public Nullable<int> 銀行帳戶數量 { get; set; }
        public Nullable<int> 聯絡人數量 { get; set; }
    }
}
