using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class PartialClasses
    {
        [MetadataType(typeof(UserMetadata))]
        public partial class User
        {
            [NotMapped]
            [Compare("Password")]
            public string ConfirmedPassword { get; set; }
        }
        [MetadataType(typeof(ProductMetadata))]
        public partial class Product
        {
            [NotMapped]
            public HttpPostedFileBase UploadImage { get; set; }
            [NotMapped]
            public List<ProDetail> RemainProducts { get; set; }
            [NotMapped]
            public List<ProDetail> NeddImportProducts { get; set; }
        }
        [MetadataType(typeof(ProDetailMetadata))]
        public partial class ProDetail
        {

        }
    }
}