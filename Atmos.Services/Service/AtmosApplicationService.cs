using Atmos.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atmos.Services.Service
{
    public class AtmosApplicationService : IAtmosApplicationService
    {
        private AtmosServices.SHUWebService _proxy;

        public AtmosApplicationService()
        {
            _proxy = new AtmosServices.SHUWebService();
        }

        public IList<AtmosServices.CourseName> GetAtmosCourseName()
        {
            return _proxy.GetAllNames();
        }

        public IList<AtmosServices.CourseList> GetAtmosCourseList()
        {
            return _proxy.GetAllCourses();
        }
       
    }
}
