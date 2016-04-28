using Lunar.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunar.Services.Service
{
    public class LunarApplicationService : ILunarApplicationService
    {
        private LunarServices.SheffieldUniCourses _proxy;

        public LunarApplicationService()
        {
            _proxy = new LunarServices.SheffieldUniCourses();
        }

        public IList<LunarServices.Course> GetLunarFullCourseDetails()
        {
            return _proxy.GetCoursesFullDetails();
        }

        public IList<LunarServices.CourseId_Name> GetLunarShortCourseDetails()
        {
            return _proxy.GetCoursesShortDetails();
        }
    }
}
