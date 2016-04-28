using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Apollo.Data;
using Apollo.Models;
using Apollo.Services;
using Apollo.Services.Service;

namespace Apollo.Controllers
{
    public class AdminController : Controller
    {

        private Apollo.Models.ApplicationDbContext _context;
        private ApolloService _apolloService;

        public AdminController()
        {
            _context = new Apollo.Models.ApplicationDbContext();
            _apolloService = new ApolloService();
        }

        // GET: Admin
        public ActionResult Index(string userId)
        {
            return View(_apolloService.GetUserProfile(userId));
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #region  
        
        
        // Added Methods
        #endregion

        public ActionResult GetUserList()
        {
            return View(_apolloService.GetApplicantList());
        }



        [HttpGet]
        public ActionResult CreateRole(string userId)
        {
            ViewBag.UserId = userId;
            return View();
        }

        [HttpPost]
        public ActionResult CreateRole(FormCollection collection)
        {
            try
            {
                _context.Roles.Add(
                    new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                    {
                        Name = collection["RoleName"]
                    }
                );

                _context.SaveChanges();
                return RedirectToAction("GetRoles");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetRoles()
        {
            return View(_context.Roles.ToList());
        }


        [HttpGet]
        public ActionResult ManageUserRoles()
        {
            // populate roles for the dropdown
            var roleList = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
                    new SelectListItem
                    {
                        Value = rr.Name.ToString(),
                        Text = rr.Name
                    }).ToList();
            ViewBag.Roles = roleList;

            //populate users for the view dropdown
            var userList = _context.Users.OrderBy(r => r.UserName).ToList().Select(uu =>
                    new SelectListItem
                    {
                        Value = uu.UserName.ToString(),
                        Text = uu.UserName.ToString()
                    }).ToList();

            ViewBag.Users = userList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageUserRoles(string UserName, string RoleName)
        {
            ApplicationUser user =
                _context.Users.Where
                (u => u.UserName.Equals(UserName,
                    StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var um = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>
                (new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(_context));
            var idResult = um.AddToRole(user.Id, RoleName);
            // prepopulat roles for the view dropdown
            var roleList = _context.Roles.OrderBy
                (r => r.Name).ToList().Select
                (rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = roleList;
            // populate users for the view dropdown
            var userList = _context.Users.OrderBy
                (u => u.UserName).ToList().Select
                (uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userList;
            return View("ManageUserRoles");
        }

        
        [HttpGet]
        public ActionResult GetRolesForUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRolesForUser(string username)
        {
            if (!string.IsNullOrWhiteSpace(username))
            {
                ApplicationUser user =
                    _context.Users.Where(u => u.UserName.Equals
                    (username, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                var um = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>
                (new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(_context));

                ViewBag.RolesForThisUser = um.GetRoles(user.Id);
            }

            return View("GetRolesForUserConfirmed");
        }


        public ActionResult EditApplicant(int applicantId, string userId, string applicantName)
        {
            ViewBag.ApplicantId = applicantId;
            ViewBag.UserId = userId;
            ViewBag.ApplicantName = applicantName;
            Applicant_Profile applicant = _apolloService.GetApplicantProfile(applicantId);
            return View(applicant);
        }

        [HttpPost]
        public ActionResult EditApplicant(Applicant_Profile applicant)
        {
            try
            {
                _apolloService.EditApplicant(applicant);
                return RedirectToAction("GetUserList", new { userId = applicant.UserId });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DetailsApplicant(int applicantId, string userId)
        {
            ViewBag.UserId = userId;
            return View(_apolloService.GetApplicantProfile(applicantId));
        }

        public ActionResult DeleteApplicant(int applicantId, string userId)
        {
            ViewBag.ApplicantId = applicantId;
            ViewBag.UserId = userId;
            Applicant_Profile applicant = _apolloService.GetApplicantProfile(applicantId);
            return View(applicant);
        }

        [HttpPost]
        public ActionResult DeleteApplicant(Applicant_Profile applicant)
        {
            try
            {
                _apolloService.DeleteApplicant(applicant);
                return RedirectToAction("GetUniversityList", new { userId = applicant.UserId });
            }
            catch
            {
                return View();
            }
        }

    }
}
