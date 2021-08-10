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
    public class PostGradutesMasterService : IPostGradutesMasterService
    {
       
        
        private readonly ApplicationDbContext _context;

        public PostGradutesMasterService(ApplicationDbContext context)
        {
            _context = context;

        }

        //Add Master Info fro the PostGradute
        public async Task<Response> AddGraduteMaster(PostGraduteMasterVM graduteMasterVM)
        {
            Response response = new Response();
            try
            {

                var postGradute = await _context.PostGradutesInfos.FirstOrDefaultAsync(p => p.SSD == graduteMasterVM.SSD);

                _context.PostGraduteMasters.Add(new PostGraduteMaster
                {
                    accepted = -1,
                    CollageCertificateFile = graduteMasterVM.CollageCertificateFile,
                    CollageGrade = graduteMasterVM.CollageGrade,
                    MasterType = graduteMasterVM.MasterType,
                    GraduteYear = graduteMasterVM.GraduteYear,
                    InterviewPassed = -1,
                    expancesDone = -1,
                    GradutePrencetage = graduteMasterVM.GradutePrencetage,
                    matchingPaper = -1,
                    registerDate = DateTime.Today.Date,
                    PostGraduteId = postGradute.Id,
                    RequestAccepted = -1,
                    StatementGradesFile = graduteMasterVM.StatementGradesFile

                });

                await _context.SaveChangesAsync();
                response.Code = ResponseCode.Success;
             }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }


        //Upload Files in Master Register 
        public async Task<Response> UploadPostGradutesPhotoMaster(IFormFileCollection file, string SSD)
        {
            var postGradute = await _context.PostGradutesInfos.Where(p => p.SSD == SSD)
                                            .Select(p=>p.Id).FirstOrDefaultAsync();

            var MasterRegister = await _context.PostGraduteMasters
                .Where(p => p.PostGraduteId == postGradute && p.registerDate.Year == DateTime.Today.Year)
                .FirstOrDefaultAsync();           
            Response response = new Response();
            if (postGradute != 0)
            {
                
                var folderName = Path.Combine("StaticFiles/Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Count > 0)
                {
                    foreach (var item in file)
                    {

                        string fileName = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderName, fileName);
                        if (item.Name == "CollageCertificateFile")
                        {
                            MasterRegister.CollageCertificateFile = dbPath;
                        }

                        else 
                        {
                            MasterRegister.StatementGradesFile = dbPath;
                        }

                       
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            item.CopyTo(stream);


                        }

                        await _context.SaveChangesAsync();
                        response.Code = ResponseCode.Success;
                       

                    }

                }
            }


            return response;
        }
        public async Task<Response<List<PostGraduteMaster>>> getMasterInfo(string ssd)
        {
            Response<List<PostGraduteMaster>> response = new Response<List<PostGraduteMaster>>();
            try
            {
                int postGraduteId = await _context.PostGradutesInfos.Where(p => p.SSD == ssd).Select(p => p.Id).FirstOrDefaultAsync();
                List<PostGraduteMaster> gradutePhd = new List<PostGraduteMaster>();
                gradutePhd = _context.PostGraduteMasters
                                         .Where(d => d.registerDate.Date.Year == 2021 && d.PostGraduteId == postGraduteId)
                                         .ToList();
                response.DataResult = gradutePhd;
                response.Code = ResponseCode.Success;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
