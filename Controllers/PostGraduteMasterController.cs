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
    public class PostGraduteMasterController : ControllerBase
    {

        private IPostGradutesMasterService masterService;

        public PostGraduteMasterController(IPostGradutesMasterService _masterService)
        {
            masterService = _masterService;
        }

        [HttpPost]
        [Route("MasterRegister")]
        public async Task<ActionResult> PhdRegister(PostGraduteMasterVM model)
        {
            if (model == null)
                return BadRequest();

            Response result = await masterService.AddGraduteMaster(model);

            if (result.IsSccuessCode)
                return Ok();

            return BadRequest(result.Message);
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("UploadMasterPhoto")]
        public async Task<IActionResult> MasterUpload([FromQuery] string SSD)
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files;
                Response response = new Response();
                response = await masterService.UploadPostGradutesPhotoMaster(file, SSD);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("GetMasterPostGradute")]
        public async Task<IActionResult> getPhdInfo(string SSD)
        {

            if (SSD == "")
                return BadRequest();

            Response<List<PostGraduteMaster>> response = new Response<List<PostGraduteMaster>>();
            response = await masterService.getMasterInfo(SSD);
            if (response.Code == ResponseCode.Success)
            {
                return Ok(response.DataResult);
            }



            return BadRequest();
        }

    }
}
