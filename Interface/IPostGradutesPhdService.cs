using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniWebAPI.Models;
using UniWebAPI.Reponse;
using UniWebAPI.ViewModel;

namespace UniWebAPI.Interface
{
  public  interface IPostGradutesPhdService
    {
        public  Task<Response> AddGradutePhd(PostGradutePhdVM gradutePhdVM);

        public Task<Response> UploadPhdPhoto(IFormFile file, string SSD);

        public  Task<Response<List<PostGradutePhd>>> getPhdInfo(string ssd);

    }
}
