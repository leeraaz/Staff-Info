using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Web.Mvc;

namespace StaffInfo.Models
{
    public class StaffModel
    {
        public int Staff_ID { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string First_Name { get; set; }

        public string Middle_Name { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string Primary_Number { get; set; }

        public string Secondary_Number { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string Temporary_Address { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string Permanent_Address { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string Qualification { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string Job_Code { get; set; }
        public IEnumerable<SelectListItem> joblist { get; set; }

        [Required(ErrorMessage ="*Required")]
        public string Branch_Code { get; set; }
        public IEnumerable<SelectListItem> branchList { get; set; }

        [Required(ErrorMessage ="*Required")]
        public string Department_ID { get; set; }
        public IEnumerable<SelectListItem> deptList { get; set; }

        public int Extension_ID { get; set; }

        [Required(ErrorMessage ="*Required")]
        public string Extension_Num { get; set; }

        public string Extension_Num2 { get; set; }
        
        public bool Status { get; set; }
    }
}