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
    public interface IPostGradutesService
    {
        public Task<Response<LoggedUserVM>> PostGraduteLogin(LoginUserVM model);

        public  Task<Response> AddPostGradutes(PostGraduteInfoVM gradutesInfo);


        public  Task<Response<LoggedUserVM>> UploadPostGradutesPhotoInfo(IFormFileCollection file, string SSD);

        public Task<Response<PostGradutesInfo>> getPostGradute(string SSD);

        public List<PostGradutesInfo> GetPostGradutes();


    }
}
