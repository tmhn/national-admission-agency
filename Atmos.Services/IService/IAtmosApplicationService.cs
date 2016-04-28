using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atmos.Services.IService
{
    interface IAtmosApplicationService
    {
        IList<AtmosServices.CourseName> GetAtmosCourseName();

        IList<AtmosServices.CourseList> GetAtmosCourseList();
 
    }
}
