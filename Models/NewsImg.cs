using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UniWebAPI.Models
{
    public class NewsImg
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string img { get; set; }

        [ForeignKey("news")]
        public int? NewId { get; set; }
        public News news { get; set; }
    }
}
