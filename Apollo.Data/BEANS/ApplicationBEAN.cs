using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Data.BEANS
{
    public class ApplicationBEAN
    {
        public ApplicationBEAN()
        {
            
        }

        // ApplicantProfile Table attributes
        public int ApplicantId { get; set; }

        public string ApplicantName { get; set; }

        public string ApplicantAddress { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string UserId { get; set; }

        // Application Table attributes

        public int ApplicationId { get; set; }

        //public int ApplicantId { get; set; }

        public string CourseName { get; set; }

        public string UniversityName { get; set; }

        public int UniversityId { get; set; }

        public string PersonalStatement { get; set; }

        public string TeacherReference { get; set; }

        public string TeacherContactDetails { get; set; }

        public string UniversityOffer { get; set; }

        public Nullable<bool> Firm { get; set; }
    }
}
