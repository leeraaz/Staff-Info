//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StaffInfo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LIKE
    {
        public int LIKE_ID { get; set; }
        public Nullable<int> BLOG_ID { get; set; }
        public string LIKE_BY { get; set; }
        public string LIKE_DATE { get; set; }
    
        public virtual BLOG BLOG { get; set; }
    }
}