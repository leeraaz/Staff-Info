using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StaffInfo.Models;
using System.Data.Entity;

namespace StaffInfo.Controllers
{
    public class AdminController : Controller
    {
        private DatabasModel db;
        public AdminController()
        {
            db = new DatabasModel();
            db.Configuration.LazyLoadingEnabled = false;
        }

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult AddAddress(string addressCode)
        {
            if(addressCode != null)
            {
                using (db)
                {
                    var addData = db.Addresses.Where(x => x.Address_Code == addressCode).Select(x => new AddressModel
                    {
                        Address_Code = x.Address_Code,
                        Place_Name = x.Place_name,
                        Mun_VDC = x.Mun_VDC,
                        Ward_No = x.Ward_No
                    }).ToList().FirstOrDefault();
                    return View(addData);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult DeleteAddress(string addCode)
        {
            using (db)
            {
                var add = db.Addresses.Find(addCode);
                db.Entry(add).Property(x => x.Status).CurrentValue = false;
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted successfully.", JsonRequestBehavior.AllowGet });
            }

        }

        public ActionResult AddJobTitle(string jobCode)
        {
            if (jobCode != null)
            {
                using (db)
                {
                    var jobData = db.Job_Title.Where(x => x.Job_Title_Code == jobCode).Select(x => new JobTitle
                    {
                        Job_Title_Code = x.Job_Title_Code,
                        Position = x.Position,
                        Minimum_Salary = x.Maximum_Salary,
                        Maximum_Salary = x.Maximum_Salary,
                        Actual_Salary = x.Actual_Salary
                    }).ToList().FirstOrDefault();
                    return View(jobData);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult AddBranch(string branchCode)
        {
            if (branchCode != null)
            {
                using (db)
                {
                    var branch = db.Branches.Where(x => x.Branch_Code == branchCode).Select(x => new BranchModel
                    {
                        Branch_Code = x.Branch_Code,
                        Branch_Name = x.Branch_Name,
                        Address_Code = x.Address_Code,
                        Primary_Number = x.Primary_Number,
                        Secondary_Number = x.Secondary_Number
                    }).ToList().FirstOrDefault();
                    return View(branch);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult AddDepartment(string deptID)
        {
            if(deptID != null)
            {
                using (db)
                {
                    var depData = db.Departments.Where(x => x.Department_ID == deptID).Select(x => new DepartmentModel
                    {
                        Department_ID = x.Department_ID,
                        Department_Name = x.Department_Name,
                        Primary_Number = x.Primary_Number,
                        Secondary_Number = x.Secondary_Number
                    }).ToList().FirstOrDefault();
                    return View(depData);
                }
            }
            return View();
        }

        public ActionResult Department()
        {
            return View();
        }

        public ActionResult Address()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAddress()
        {
            using (db)
            {
                var addressList = db.Addresses.Where(x => x.Status == true).ToList();
                return Json(new { data = addressList }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetDepartment()
        {
            using(db)
            {
                List<Department> deptList = db.Departments.Where(x => x.Status == true).ToList<Department>();
                return Json(new { data = deptList }, JsonRequestBehavior.AllowGet);                
            }
        }

        [HttpPost]
        public ActionResult AddAddress(Address adds)
        {
            using(db)
            {
                var addID = db.Addresses.Where(x => x.Address_Code == adds.Address_Code).Select(x => new AddressModel
                {
                    Address_Code = x.Address_Code
                }).ToList().FirstOrDefault();
                if (addID == null)
                {
                    adds.Status = true;
                    db.Addresses.Add(adds);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Data has been saved.", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    adds.Status = true;
                    db.Entry(adds).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Data is updated" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpGet]
        public JsonResult GetJob()
        {
            using (db)
            {
                List<Job_Title> jobList = db.Job_Title.Where(x => x.Status==true).ToList<Job_Title>();
                return Json(new { data = jobList }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult JobTitle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddJobTitle(Job_Title job)
        {
            using(db)
            {
                var getJob = db.Job_Title.Where(x => x.Job_Title_Code == job.Job_Title_Code).Select(x => new JobTitle
                {
                    Job_Title_Code = x.Job_Title_Code
                }).ToList().FirstOrDefault();
                if (getJob == null)
                {
                    job.Status = true;
                    db.Job_Title.Add(job);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Data saved.", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    job.Status = true;
                    db.Entry(job).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Data is updated.", JsonRequestBehavior.AllowGet });
                }
            }
        }

        [HttpPost]
        public ActionResult DeleteJob(string jobID)
        {
            using (db)
            {
                var job = db.Job_Title.Where(x => x.Job_Title_Code == jobID).FirstOrDefault<Job_Title>();
                db.Entry(job).Property(x => x.Status).CurrentValue = false;
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted successfully.", JsonRequestBehavior.AllowGet });
            }
        }

        public ActionResult Branch()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetBranch()
        {
            using (db)
            {
                var brnList = db.BRANCHDATA().ToList();
                return Json(new { data = brnList }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DeleteBranch(string brCode)
        {
            using (db)
            {
                var brnchID = db.Branches.Find(brCode);
                db.Entry(brnchID).Property(x => x.Status).CurrentValue = false;
                db.SaveChanges();
                return Json(new { success = true, message = "Branch is deleted.", JsonRequestBehavior.AllowGet });
            }
        }

        [HttpPost]
        public ActionResult AddBranch(Branch brch)
       {
            using(db)
            {
                var getCode = db.Branches.Where(x => x.Branch_Code == brch.Branch_Code).Select(x => new BranchModel
                {
                    Branch_Code = x.Branch_Code,
                }).ToList().FirstOrDefault();
                if (getCode == null)
                {
                    brch.Status = true;
                    db.Branches.Add(brch);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Branch is added.", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    brch.Status = true;
                    db.Entry(brch).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Branch is updated." , JsonRequestBehavior.AllowGet});
                }
            }
        }

        [HttpPost]
        public ActionResult AddDepartment(Department dept)
        {
            using(db)
            {
                var getID = db.Departments.Where(x => x.Department_ID == dept.Department_ID).Select(x => new DepartmentModel
                {
                    Department_ID = x.Department_ID
                }).ToList().FirstOrDefault();
                if (getID == null)
                {
                    dept.Status = true;
                    db.Departments.Add(dept);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Data is saved.", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    dept.Status = true;
                    db.Entry(dept).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Department updated." }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult DeleteData(string deptID)
        {
            using(db)
            {
                //var stf = db.Departments.Where(x => x.Department_ID == dept).FirstOrDefault<Staff>();\
                var dpt = db.Departments.Find(deptID);
                db.Entry(dpt).Property(x => x.Status).CurrentValue = false;
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted successfully.", JsonRequestBehavior.AllowGet });
            }
        }

        [HttpPost]
        public JsonResult AutoCompleteBranch(string branchName)
        {
            using(db)
            {
                List<BranchModel> allsearch = db.Branches.Where(x => x.Branch_Code.StartsWith(branchName)).Select(x => new BranchModel
                {
                    Branch_Code = x.Branch_Code,
                    Branch_Name = x.Branch_Name
                }).ToList();
                return Json(new { data = allsearch, JsonRequestBehavior.AllowGet });
            }
        }

        [HttpPost]
        public JsonResult AutoCompleteDepartment(string deptName)
        {
            using(db)
            {
                var deptList = db.Departments.Where(x => x.Department_Name.StartsWith(deptName)).Select(x => new
                {
                    Department_ID = x.Department_ID, Department_Name = x.Department_Name
                }).ToList();
                return Json(new { data = deptList },JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AddressAutoComplete(string addressAdd)
        {
            using (db)
            {
                var addList = db.Addresses.Where(x => x.Address_Code.StartsWith(addressAdd)).Select(x => new 
                {
                    Address_Code = x.Address_Code,Place_Name = x.Place_name
                }).ToList();
                return Json(new { data = addList }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}