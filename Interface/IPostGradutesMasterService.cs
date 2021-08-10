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
  public  interface IPostGradutesMasterService 
    {
        public Task<Response> AddGraduteMaster(PostGraduteMasterVM graduteMasterVM);

        public  Task<Response> UploadPostGradutesPhotoMaster(IFormFileCollection file, string SSD);

        public  Task<Response<List<PostGraduteMaster>>> getMasterInfo(string ssd);


    }
}
