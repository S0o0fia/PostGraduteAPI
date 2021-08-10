using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniWebAPI.ViewModel
{
    public class PostGradutePhotosVM
    {
        public IFormFile SSDFile { get; set; }
        public IFormFile MilirtyFile { get; set; }
        public IFormFile Photo { get; set; }
        public IFormFile BirthCertificate { get; set; }
        public IFormFile ApproveAffairFile { get; set; }
        public IFormFile AcknowledmentFile { get; set; }
        public IFormFile AcknowledmentJobFile { get; set; }
    }
}
