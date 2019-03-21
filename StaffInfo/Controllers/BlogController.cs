using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StaffInfo.Models;
using System.Data.Entity;

namespace StaffInfo.Controllers
{
    public class BlogController : Controller
    {
        public static List<BLOG> blgList = new List<BLOG>();
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Widgets()
        {
            return View();
        }

        public ActionResult Charts()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Posts()
        {
            //using (DatabasModel db = new DatabasModel())
            //{
            //    var idd = Session["First_Name"].ToString();
            //    int ids = Convert.ToInt32(Session["Staff_ID"]);
            //    try
            //    {
            //        var staffName = (from sx in db.Staffs
            //                         join bg in db.BLOGs
            //                        on sx.Staff_ID equals bg.STAFF_ID
            //                         select new BlogModel { publicshBy = sx.First_Name }).Select(x => x.publicshBy).FirstOrDefault();                                     //select new { sx.First_Name }).Where(x => x.First_Name == idd).Select(x => new BlogModel
            //                                                                                                                                                              //{
            //                                                                                                                                                              //    publicshBy = x.First_Name
            //                                                                                                                                                              //}).ToString();

            //        return View(staffName);
            //        //return Json(new { success = true, message = "your name " + staffName }, JsonRequestBehavior.AllowGet);
            //    }
            //    catch (Exception ex)
            //    {
            //        return Json(new { success = true, message = "Exception " + ex }, JsonRequestBehavior.AllowGet);
            //    }
            //}
            return View();
        }

        [HttpPost]
        public ActionResult Posts(BLOG bg)
        {
            if(bg.BLOG_ID == 0)
            {
                using (DatabasModel db = new DatabasModel())
                {
                    db.BLOGs.Add(bg);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Blog has been post" }, JsonRequestBehavior.AllowGet);
                }
            }
            return View();
        }

        public ActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginPage(Staff stf)
        {
            using (DatabasModel db = new DatabasModel())
            {
                var stfIdentity = db.Staffs.Where(model => model.First_Name == stf.First_Name && model.Last_Name == stf.Last_Name).FirstOrDefault();
                if(stfIdentity != null)
                {
                    Session["Staff_ID"] = stfIdentity.Staff_ID;
                    Session["First_Name"] = stfIdentity.First_Name.ToString();
                    return RedirectToAction("Index");
                }       
            }
            return View();
        }

        //public ActionResult Blogs()
        //{
        //    blgList.Clear();

        //    var post = this.GetPost();
        //    foreach (var post in posts)
        //    {
        //        blgList.Add(new BLOG() { })
        //    }
        //}

        public ActionResult GetPost()
        {
            using (DatabasModel db = new DatabasModel())
            {
                var blogList = db.BLOGs.ToList();
                return View(blogList);
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();

            return View("LoginPage");
        }
    }
}