using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class CategoryMetadata
    {
        [HiddenInput]
        public int CatID { get; set; }

        [Required]
        [StringLength(50, MinimumLength =5)]
        public string NameCate { get; set; }
    }
    public class UserMetadata
    {
        [Required(ErrorMessage = "Username is required!")]
        [StringLength(30, MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z0-9](?!.*[_.]{2})[a-zA-Z0-9._]{3,18}[a-zA-Z0-9]$")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
    public class CustomerMetadata
    {

    }
    public class ProDetailMetadata
    {

    }
    public class ProductMetadata
    {
        [Display(Name ="Mã sản phẩm")]
        public int ProID { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage ="Phải nhập tên sản phẩm")]
        [Display(Name ="Tên sản phẩm")]
        public string ProName { get; set; }
        [Display(Name = "Chủng loại sản phẩm")]
        public int CatID { get; set; }
        [Display(Name = "Đường dẫn ảnh sản phẩm")]
        [DefaultValue("~/Content/images/default_img.jfif")]
        public string ProImage { get; set; }
        [Display(Name = "Mô tả sản phẩm")]
        public string NameDescription { get; set; }
        [DefaultValue(true)]
        public System.DateTime CreateDate { get; set; }
    }
}