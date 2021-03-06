 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UniWebAPI.Models
{
    public class PostGradutePhd
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PhdType { get; set; }
        public DateTime registerDate { get; set; }
        public string MasterGrade { get; set; }
        public string MasterCertificateFile { get; set; }
        public int MasterYear { get; set; }
        public int RequestAccepted { get; set; }
        public DateTime matchingPaperDate { get; set; }
        public int matchingPaper { get; set; }
        public DateTime InterviewDate { get; set; }
        public int InterviewPassed { get; set; }
        public DateTime expancesDate { get; set; }
        public float expancesAmount { get; set; }
        public int expancesDone { get; set; }
        public string expancesReciepts { get; set; }
        public int accepted { get; set; }


        [ForeignKey("PostGradutes")]
        public int PostGraduteId { get; set; }


        public PostGradutesInfo PostGradutes { get; set; }
    }
}
