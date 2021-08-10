using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniWebAPI.Enums;
using UniWebAPI.Interface;
using UniWebAPI.Models;
using UniWebAPI.Reponse;
using UniWebAPI.Services;
using UniWebAPI.ViewModel;

namespace UniWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
  
    public class PostGraduteDiplomaController : ControllerBase
    {
      
        private readonly IPostGradutesDiplomaService DiplomaService;

        public PostGraduteDiplomaController(IPostGradutesDiplomaService _DiplomaService)
        {
            DiplomaService = _DiplomaService;
        }

        [HttpPost("DiplomaRegister")]
   
        public async Task<ActionResult> PhdRegister(PostGraduteDiplomaVM model)
        {
            if (model == null)
                return BadRequest();

            Response result = await DiplomaService.AddGraduteDiploma(model);

            if (result.IsSccuessCode)
                return Ok();

            return BadRequest(result.Message);
        }

        [HttpPost("UploadDiplomaPhoto"), DisableRequestSizeLimit] 
        public async Task<IActionResult> PhdUpload([FromQuery] string SSD)
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files;
                Response response = new Response();
                response = await DiplomaService.UploadPostGradutesPhotoDiploma(file, SSD);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("GetDiplomaPostGradute")]
        public async Task<IActionResult> getPhdInfo(string SSD)
        {

            if (SSD == "")
                return BadRequest();

            Response<List<PostGradutesDiploma>> response = new Response<List<PostGradutesDiploma>>();
            response = await DiplomaService.getDiplomaInfo(SSD);
            if (response.Code == ResponseCode.Success)
            {
                return Ok(response.DataResult);
            }



            return BadRequest();
        }
      
    }
}
