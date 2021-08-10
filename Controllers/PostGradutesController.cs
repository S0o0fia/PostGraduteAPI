using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UniWebAPI.Models;
using UniWebAPI.Reponse;
using UniWebAPI.Services;
using System.Net;
using UniWebAPI.Enums;
using UniWebAPI.ViewModel;
using UniWebAPI.Interface;
using System.IO;
using System.Net.Http.Headers;

namespace UniWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostGradutesController : ControllerBase
    {

        private IPostGradutesService gradutesService;

   
   
        public PostGradutesController(IPostGradutesService _gradutesService)
        {
            gradutesService = _gradutesService;
        }

        //Api for PostGradute Login
        [HttpPost]
        [Route("PostGraduteLogin")]
        public async Task<ActionResult> LoginPostGradute(LoginUserVM model)
        {
            if (model == null)
                return BadRequest();

            Response<LoggedUserVM> response = new Response<LoggedUserVM>();
            response = await gradutesService.PostGraduteLogin(model);

            if (response.Code == ResponseCode.Success)
                return Ok(response.DataResult);
            return BadRequest();

        }

        //Api for Register new PostGradute Student 
        [HttpPost]
        [Route("AddNewPostGradute")]
        public async Task<ActionResult> AddNewPostGradute(PostGraduteInfoVM model)
        {
            if (model == null)
                return BadRequest();

            Response result = await gradutesService.AddPostGradutes(model);

            if (result.IsSccuessCode)
                return Ok();

            return BadRequest(result.Message);
        }


        [HttpPost, DisableRequestSizeLimit]
        [Route("UploadPhoto")]
       public async Task<IActionResult> Upload( [FromQuery] string SSD)
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files;
                Response<LoggedUserVM> response = new Response<LoggedUserVM>();
                response = await gradutesService.UploadPostGradutesPhotoInfo(file, SSD);

                return Ok(response.DataResult);
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }


        [HttpGet]
        [Route("GetPostGradute")]
        public async Task<ActionResult<PostGradutesInfo>> GetPostGraduteInfo([FromQuery]string id)
        {
            if (id == "")
                return BadRequest();

            Response<PostGradutesInfo> result = await gradutesService.getPostGradute(id);

            if (result.Code == ResponseCode.Success)
                return result.DataResult;


            return BadRequest(result.Message);
        }


    }
}
