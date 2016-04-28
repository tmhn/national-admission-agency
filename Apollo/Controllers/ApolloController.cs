using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apollo.Controllers
{
    public class ApolloController : Controller
    {
        private Apollo.Services.Service.ApolloService _ApolloService;   
       
        public ApolloController()
        {          
            _ApolloService = new Apollo.Services.Service.ApolloService();
        }

        public ActionResult GetUniversities()
        {
            return View(_ApolloService.GetUniversityList());
        }

        public ActionResult GetUniversityList(int applicantId)
        {
            ViewBag.ApplicantId = applicantId;
            return View(_ApolloService.GetUniversityList());
        }

        public ActionResult GetUniversityListAuth(string userId)
        {
            ViewBag.UserId = userId;
            return View(_ApolloService.GetUniversityListAuth());
        }

        public ActionResult GetCourseList(Int32 id, string universityName)
        {
            ViewBag.UniversityName = universityName;
            ViewBag.UniversityId = id;
            return View(_ApolloService.GetUniversityCourses(id));
        }

        public ActionResult GetCourses(Int32 id, string universityName, int applicantId)
        {
            ViewBag.ApplicantId = applicantId;
            ViewBag.UniversityName = universityName;
            ViewBag.UniversityId = id;
            return View(_ApolloService.GetUniversityCourses(id));
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}