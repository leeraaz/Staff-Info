using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaffInfo.Models
{
    public class BlogModel
    {
        public int BLOG_ID { get; set; }

        [Required(ErrorMessage = "*Required")]
        public Nullable<int> STAFF_ID { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string TITLE { get; set; }
        
        [Required(ErrorMessage = "*Required")]
        [AllowHtml]
        public string BLOG_BODY { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string PUBLISHED_DATE { get; set; }

        public string PUBLISHED_BY { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}