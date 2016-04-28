using Mercury.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercury.Services.Service
{
    public class MercurySearchService : IMercuryService
    {
        private MercuryServiceSheffieldHallam.SHUWebService _SheffieldHallamProxy;
        private MercuryServiceSheffieldUni.SheffieldUniCourses _SheffieldUniProxy;

        public MercurySearchService()
        {
            _SheffieldHallamProxy = new MercuryServiceSheffieldHallam.SHUWebService();
            _SheffieldUniProxy = new MercuryServiceSheffieldUni.SheffieldUniCourses();
        }

        public IList<MercuryServiceSheffieldHallam>

    }
}
