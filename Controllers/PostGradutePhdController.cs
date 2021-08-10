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
    [Route("api/[controller]")]
    [ApiController]
    public class PostGradutePhdController : ControllerBase
    {
        private IPostGradutesPhdService phdService;

        public PostGradutePhdController(IPostGradutesPhdService _phdService)
        {
            phdService = _phdService;
        }

        [HttpPost]
        [Route("PhdRegister")]
        public async Task<ActionResult> PhdRegister(PostGradutePhdVM model)
        {
            if (model == null)
                return BadRequest();

            Response result = await phdService.AddGradutePhd(model);

            if (result.IsSccuessCode)
                return Ok();

            return BadRequest(result.Message);
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("UploadPhdPhoto")]
        public async Task<IActionResult> PhdUpload([FromQuery] string SSD)
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                Response response = new Response();
                response = await phdService.UploadPhdPhoto(file, SSD);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("GetPhdPostGradute")]
        public async Task<IActionResult> getPhdInfo (string SSD)
        {

            if (SSD == "")
                return BadRequest();

            Response<List<PostGradutePhd>> response = new Response<List<PostGradutePhd>>();
            response = await phdService.getPhdInfo(SSD);
            if(response.Code == ResponseCode.Success)
            {
                return Ok(response.DataResult);
            }



            return BadRequest();
        }



    }
}
