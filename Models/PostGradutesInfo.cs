using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UniWebAPI.Models
{
    public class PostGradutesInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Namear { get; set; }
        public string Nameen { get; set; }
        public string SSD { get; set; }
        public string IssuerSSD { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string Job { get; set; }
        public string birthPlace { get; set; }
        public DateTime birthDate { get; set; }
        public string Address  { get; set; }
        public string Phone  { get; set; }
        public string Email  { get; set; }
        public byte[] Password { get; set; }  
        public byte[] SalltPassword { get; set; }
        public string MilirityStatus  { get; set; }
        public string University  { get; set; }
        public string Collage  { get; set; }
        public string Department  { get; set; }
        public string SSDFile  { get; set; }
        public string MilirtyFile  { get; set; }
        public string Photo  { get; set; }
        public string BirthCertificate  { get; set; }
        public string ApproveAffairFile  { get; set; }
        public string AcknowledmentFile  { get; set; }
        public string AcknowledmentJobFile { get; set; }
    }
}
