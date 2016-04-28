using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunar.Services.IService
{
    interface ILunarApplicationService
    {
        IList<LunarServices.Course> GetLunarFullCourseDetails();

        IList<LunarServices.CourseId_Name> GetLunarShortCourseDetails();
    }
}
