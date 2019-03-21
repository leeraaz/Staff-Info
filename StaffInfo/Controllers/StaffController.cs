using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StaffInfo.Models;
using System.Data.Entity;

namespace StaffInfo.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (DatabasModel db = new DatabasModel())
            {
                //var stafflist = db.STAFF_DETAILS().ToList();
                List<STAFF_DETAILS_Result> stafflist = db.STAFF_DETAILS().ToList();
                return Json(new { data = stafflist }, JsonRequestBehavior.AllowGet );
            }
        }

        [HttpGet]
        public ActionResult StaffRegister(int STAFF_ID= 0)
        {
            
            {
                using (DatabasModel db = new DatabasModel())
                {
                    List<SelectListItem> branchlist = new List<SelectListItem>();
                    List<SelectListItem> deptList = new List<SelectListItem>();
                    List<SelectListItem> joblist = new List<SelectListItem>();
                    foreach (Branch brh in db.Branches)
                    {
                        SelectListItem item = new SelectListItem()
                        {
                            Text = brh.Branch_Name,
                            Value = brh.Branch_Code.ToString(),
                            Selected = false
                        };
                        branchlist.Add(item);
                    }

                    foreach(Department dept in db.Departments)
                    {
                        SelectListItem item = new SelectListItem()
                        {
                            Text = dept.Department_Name,
                            Value = dept.Department_ID,
                            Selected = false
                        };
                        deptList.Add(item);
                    }

                    foreach(Job_Title jobTitle in db.Job_Title)
                    {
                        SelectListItem item = new SelectListItem()
                        {
                            Text = jobTitle.Position,
                            Value = jobTitle.Job_Title_Code,
                            Selected = false
                        };
                        joblist.Add(item);
                    }
                    ViewData["jobList"] = new SelectList(joblist.ToList(), "Value", "Text");
                    ViewData["branchList"] = new SelectList(branchlist.ToList(), "Value", "Text");
                    ViewData["deptList"] = new SelectList(deptList.ToList(), "Value", "Text");
                    //
                }
            }
            if (STAFF_ID != 0)
            {
                using(DatabasModel db = new DatabasModel())
                {
                    var mdl = db.Staffs.Where(x => x.Staff_ID == STAFF_ID).Select(x => new StaffModel
                    {
                        Staff_ID = x.Staff_ID,
                        First_Name = x.First_Name,
                        Middle_Name = x.Middle_Name,
                        Last_Name = x.Last_Name,
                        Gender = x.Gender,
                        Primary_Number = x.Primary_Number,
                        Secondary_Number = x.Secondary_Number,
                        Email = x.Email,
                        Temporary_Address = x.Temporary_Address,
                        Permanent_Address = x.Permanent_Address,
                        Qualification = x.Qualification,
                        Job_Code = x.Job_Code,
                        Branch_Code = x.Branch_Code,
                        Department_ID = x.Department_ID
                    }).ToList().FirstOrDefault();
                    return View(mdl);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult AddExtension(int staffID)
        {
            using (DatabasModel db = new DatabasModel())
            {
                //var extNum = db.Staff_Extensions.Where(x => x.Staff_ID == staffID).Select(x => new StaffModel
                //{
                //    Extension_ID = x.Extension_ID,
                //    Staff_ID = x.Staff_ID,
                //    Extension_Num = x.Extension_Num,
                //    Extension_Num2 = x.Extension_Num2
                //}).FirstOrDefault();

                var extnNum = (from sx in db.Staff_Extensions join stf in db.Staffs 
                               on sx.Staff_ID equals stf.Staff_ID
                               select new { sx.Extension_ID, sx.Staff_ID, sx.Extension_Num, sx.Extension_Num2 }).Where(x => x.Staff_ID == staffID).Select(x => new StaffModel {
                                   Extension_ID = x.Extension_ID,
                                   Staff_ID = x.Staff_ID,
                                   Extension_Num = x.Extension_Num,
                                   Extension_Num2 = x.Extension_Num2
                               }).FirstOrDefault();

                try
                {
                    if (extnNum != null)
                    {
                        return View(extnNum);
                    }
                    else
                    {
                        var mdl = db.Staffs.Where(x => x.Staff_ID == staffID).Select(x => new StaffModel
                        {
                            Staff_ID = x.Staff_ID
                        }).FirstOrDefault();
                        return View(mdl);
                    }
                }
                catch(Exception ex)
                {
                    return Json(new { success = true, message = "Exception " + ex }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult AddStaffExtension(Staff_Extensions stfExt)
        {
            using(DatabasModel db = new DatabasModel())
            {
                if (stfExt.Extension_ID == 0)
                {
                    db.Staff_Extensions.Add(stfExt);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Extension is added" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(stfExt).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated extension." }, JsonRequestBehavior.AllowGet);
                }
            }
        }


        [HttpPost]
        public ActionResult StaffRegister(Staff stf)
        {
            using (DatabasModel db = new DatabasModel())
            {
                if (stf.Staff_ID == 0)
                {
                    stf.Status = true;
                    db.Staffs.Add(stf);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Staff is registered.", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    stf.Status = true;
                    db.Entry(stf).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult DeleteData(int staffID)
        {
            using(DatabasModel db = new DatabasModel())
            {
                var staf = db.Staffs.Where(x => x.Staff_ID == staffID).FirstOrDefault<Staff>();
                db.Entry(staf).Property(x => x.Status).CurrentValue = false;
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted successfully.", JsonRequestBehavior.AllowGet });
            }
        }

        [HttpPost]
        public JsonResult AutoCompleteJob(string jobName)
        {
            using(DatabasModel db = new DatabasModel())
            {
                var jobList = db.Job_Title.Where(x => x.Job_Title_Code.StartsWith(jobName)).Select(x => new
                {
                    Job_Title_Code = x.Job_Title_Code,
                    Position = x.Position
                }).ToList();
                return Json(new { data = jobList }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult AutoCompleteAddress(string addName)
        {
            using(DatabasModel db = new DatabasModel())
            {
                var addList = db.Addresses.Where(x => x.Address_Code.StartsWith(addName)).Select(x => new
                {
                    Address_Code = x.Address_Code,
                    Place_Name = x.Place_name
                }).ToList();
                return Json(new { data = addList }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AddExtension()
        {
            return View();
        }
    }
}