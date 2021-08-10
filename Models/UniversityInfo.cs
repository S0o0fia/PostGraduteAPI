using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UniWebAPI.Models
{
    public class UniversityInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UniName_ar { get; set; }
        public string UniName_en { get; set; }
        [DataType(DataType.Date)]
        public string CreationDate { get; set; }
        public string UniVisionar_ar { get; set; }
        public string UniVisionar_en { get; set; }
        public string UniMassage_ar { get; set; }
        public string UniMassage_en { get; set; }
        public string UniPresidentSpeech_ar { get; set; }
        public string UniPresidentSpeech_en { get; set; }



    }
}
