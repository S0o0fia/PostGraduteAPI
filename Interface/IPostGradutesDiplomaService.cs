using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniWebAPI.Models;
using UniWebAPI.Reponse;
using UniWebAPI.ViewModel;

namespace UniWebAPI.Interface
{
   public interface IPostGradutesDiplomaService
    {
        public  Task<Response> AddGraduteDiploma(PostGraduteDiplomaVM graduteDiplomaVM);


        public Task<Response> UploadPostGradutesPhotoDiploma(IFormFileCollection file, string SSD);

        public Task<Response<List<PostGradutesDiploma>>> getDiplomaInfo(string ssd);



    }
}
