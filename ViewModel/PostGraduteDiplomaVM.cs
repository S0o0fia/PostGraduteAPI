using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniWebAPI.ViewModel
{
    public class PostGraduteDiplomaVM
    {
        public string DiplomaType { get; set; }
        public DateTime registerDate { get; set; }
        public string CollageGrade { get; set; }
        public string CollageCertificateFile { get; set; }
        public string StatementGradesFile { get; set; }
        public int GraduteYear { get; set; }
        public float GradutePrencetage { get; set; }
        public string SSD { get; set; }
    }
}
