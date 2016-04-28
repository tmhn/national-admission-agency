using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercury.Services.IService
{
    interface IMercuryService
    {
        IList<MercuryServiceSheffieldHallam.CourseList> GetCourses(int UniversityId);
    }
}
