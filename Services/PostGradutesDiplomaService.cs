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
    public class PostGradutesDiplomaService : IPostGradutesDiplomaService
    {

        private readonly ApplicationDbContext _context;

        public PostGradutesDiplomaService(ApplicationDbContext context)
        {
            _context = context;

        }

        //Add Diploma Info fro the PostGradute
        public async Task<Response> AddGraduteDiploma(PostGraduteDiplomaVM graduteDiplomaVM)
        {
            Response response = new Response();
            try
            {

                var postGradute = await _context.PostGradutesInfos.FirstOrDefaultAsync(p => p.SSD == graduteDiplomaVM.SSD);

                _context.PostGradutesDiplomas.Add(new PostGradutesDiploma
                {
                    accepted = -1,
                    CollageCertificateFile = graduteDiplomaVM.CollageCertificateFile,
                    CollageGrade = graduteDiplomaVM.CollageGrade,
                    DiplomaType = graduteDiplomaVM.DiplomaType,
                    InterviewPassed = -1,
                    GraduteYear = graduteDiplomaVM.GraduteYear,
                    expancesDone = -1,
                    GradutePrencetage = graduteDiplomaVM.GradutePrencetage,
                    matchingPaper = -1,
                    registerDate = DateTime.Today.Date,
                    PostGraduteId = postGradute.Id,
                    RequestAccepted = -1,
                    StatementGradesFile = graduteDiplomaVM.StatementGradesFile

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


        //Upload Files in Diploma Register 
        public async Task<Response> UploadPostGradutesPhotoDiploma(IFormFileCollection file, string SSD)
        {
            var postGradute = await _context.PostGradutesInfos.Where(p => p.SSD == SSD)
                                            .Select(p => p.Id).FirstOrDefaultAsync();

            var DiplomaRegister = await _context.PostGradutesDiplomas
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
                            DiplomaRegister.CollageCertificateFile = dbPath;
                        }

                        else
                        {
                            DiplomaRegister.StatementGradesFile = dbPath;
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
        public async Task<Response<List<PostGradutesDiploma>>> getDiplomaInfo(string ssd)
        {
            Response<List<PostGradutesDiploma>> response = new Response<List<PostGradutesDiploma>>();
            try
            {
                int postGraduteId = await _context.PostGradutesInfos.Where(p => p.SSD == ssd).Select(p => p.Id).FirstOrDefaultAsync();
                List<PostGradutesDiploma> gradutePhd = new List<PostGradutesDiploma>();
                gradutePhd = _context.PostGradutesDiplomas
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
