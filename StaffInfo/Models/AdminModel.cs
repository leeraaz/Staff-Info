using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StaffInfo.Models
{
    public class AddressModel
    {
        //for address form
        [Required(ErrorMessage = "*Required")]
        public string Address_Code { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string Place_Name { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string Mun_VDC { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string Ward_No { get; set; }

        public bool Status { get; set; }
    }

    //for job title
    public class JobTitle
    {
        [Required(ErrorMessage = "*Required")]
        public string Job_Title_Code { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string Position { get; set; }

        [Required(ErrorMessage = "*Required")]
        public Nullable<decimal> Minimum_Salary { get; set; }

        [Required(ErrorMessage = "*Required")]
        public Nullable<decimal> Maximum_Salary { get; set; }

        [Required(ErrorMessage = "*Required")]
        public Nullable<decimal> Actual_Salary { get; set; }

        public bool Status { get; set; }
    }

    //for branch
    public class BranchModel
    {
        [Required(ErrorMessage = "*Required")]
        public string Branch_Code { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string Branch_Name { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string Address_Code { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string Primary_Number { get; set; }

        public string Secondary_Number { get; set; }

        public bool Status { get; set; }
    }

    //for department
    public class DepartmentModel
    {
        [Required(ErrorMessage = "*Required")]
        public string Department_ID { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string Department_Name { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string Primary_Number { get; set; }

        public string Secondary_Number { get; set; }

        public bool Status { get; set; }
    }
}