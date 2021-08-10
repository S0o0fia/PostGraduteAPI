using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UniWebAPI.Enums;
using UniWebAPI.Interface;
using UniWebAPI.Models;
using UniWebAPI.Reponse;
using UniWebAPI.ViewModel;

namespace UniWebAPI.Services
{
    public class PostGradutesPhdService : IPostGradutesPhdService
    {

        private readonly ApplicationDbContext _context;

        public PostGradutesPhdService(ApplicationDbContext context)
        {
            _context = context;

        }

        //Add Phd Info for the PostGradute
        public async Task<Response> AddGradutePhd(PostGradutePhdVM gradutePhdVM)
        {
            Response reponse = new Response();
            try
            {
                
               var postGradute = await _context.PostGradutesInfos.FirstOrDefaultAsync(p => p.SSD == gradutePhdVM.SSD);

                _context.PostGradutePhds.Add(new PostGradutePhd
                {
                    accepted = -1,
                    MasterCertificateFile ="",
                    MasterGrade = gradutePhdVM.MasterGrade == null ? "" : gradutePhdVM.MasterGrade,
                    PhdType = gradutePhdVM.PhdType == null ? "" : gradutePhdVM.PhdType,
                    InterviewPassed = -1,
                    expancesDone = -1,
                    MasterYear = gradutePhdVM.MasterYear == 0 ? 0 : gradutePhdVM.MasterYear,
                    matchingPaper = -1,
                    registerDate = DateTime.Today.Date,
                    PostGraduteId = postGradute == null? 0 : postGradute.Id,
                    RequestAccepted = -1                   
                });

                await _context.SaveChangesAsync();
                reponse.Code = Enums.ResponseCode.Success;
                reponse.Message = "Phd Register Sucess";

            }
            catch (Exception ex)
            {
                reponse.Message = ex.Message;
            }
            return reponse;
        }


        //Upload phd photo
        public async Task<Response> UploadPhdPhoto(IFormFile file, string SSD)
        {
            Response<LoggedUserVM> response = new Response<LoggedUserVM>();
            if (SSD != "")
            {
                var postGraduteid = await _context.PostGradutesInfos.FirstOrDefaultAsync(p => p.SSD == SSD);

                var PhdInfo = await _context.PostGradutePhds
                     .Where(p => p.PostGraduteId == postGraduteid.Id && p.registerDate.Year == DateTime.Today.Year)
                    .FirstOrDefaultAsync();

                var folderName = Path.Combine("StaticFiles/Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                  
                        string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderName, fileName);
                       
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);


                        }

                        PhdInfo.MasterCertificateFile = dbPath;
                        await _context.SaveChangesAsync();
                        response.Code = ResponseCode.Success;
                        response.Message = "Upload Photo Sucess";
                       

                    }

                }
            


            return response;
        }


        //Get Phd Information for PostGradute
        public async Task<Response<List<PostGradutePhd>>> getPhdInfo(string ssd)
        {
            Response<List<PostGradutePhd>> response = new Response<List<PostGradutePhd>>();
            try
            {
                int postGraduteId = await _context.PostGradutesInfos.Where(p => p.SSD == ssd).Select(p => p.Id).FirstOrDefaultAsync();
                List<PostGradutePhd> gradutePhd = new List<PostGradutePhd>();
                gradutePhd = _context.PostGradutePhds
                                         .Where(d => d.registerDate.Date.Year == 2021 && d.PostGraduteId == postGraduteId)
                                         .ToList();
                response.DataResult = gradutePhd;
                response.Code = ResponseCode.Success;
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
            }

            return response ;
        }

    }
}
