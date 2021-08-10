using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UniWebAPI.Enums;
using UniWebAPI.Interface;
using UniWebAPI.Models;
using UniWebAPI.Reponse;
using UniWebAPI.ViewModel;

namespace UniWebAPI.Services
{
    public class PostGradutesService : IPostGradutesService
    {
        private ApplicationDbContext _context { set; get; }

        private ITokenService _tokenService { get; set; }
        public PostGradutesService(ApplicationDbContext context , ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        //PostGradute Login 
        public async Task<Response<LoggedUserVM>> PostGraduteLogin (LoginUserVM model)
        {
            var user = await _context.PostGradutesInfos.FirstOrDefaultAsync(x => x.Email == model.Email);
            Response<LoggedUserVM> response = new Response<LoggedUserVM>();

            if(user != null)
            {
                using var hmac = new HMACSHA512(user.SalltPassword);

                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(model.Paasword));

                for (int i = 0; i < computeHash.Length; i++)
                {
                    if( computeHash[i] != user.Password[i])
                    {
                        response.Code = ResponseCode.EmailOrPasswordAreInvalid;
                        return response;
                    }
                        
                }

                response.DataResult = new LoggedUserVM
                {
                    SSD = user.SSD,
                    Token = _tokenService.CreatToken(user)
                };
                response.Code = ResponseCode.Success;
            }

            return response;

        }


        //Add new PostGradutes 
        public async Task<Response> AddPostGradutes(PostGraduteInfoVM gradutesInfo)
        {
            Response result = new Response();

            try
            {
                using var hmac = new HMACSHA512();
                
                 
                _context.PostGradutesInfos.Add(new PostGradutesInfo
                {
                    AcknowledmentFile =  "",
                    AcknowledmentJobFile = "",
                    Address = gradutesInfo.Address == null ? "" : gradutesInfo.Address,
                    ApproveAffairFile = "",
                    BirthCertificate ="",
                    birthDate = gradutesInfo.birthDate,
                    birthPlace = gradutesInfo.birthPlace,
                    Collage = gradutesInfo.Collage,
                    Department = gradutesInfo.Department,
                    Email = gradutesInfo.Email,
                    Gender = gradutesInfo.Gender,
                    IssuerSSD = gradutesInfo.IssuerSSD,
                    Job = gradutesInfo.Job,
                    MilirityStatus = gradutesInfo.MilirityStatus,
                    MilirtyFile = "",
                    Namear = gradutesInfo.Namear,
                    Nameen = gradutesInfo.Nameen,
                    Nationality = gradutesInfo.Nationality,
                    Phone = gradutesInfo.Phone,
                    Photo ="",
                    Password =hmac.ComputeHash(Encoding.UTF8.GetBytes(gradutesInfo.Password)),
                    SalltPassword = hmac.Key,
                    Religion = gradutesInfo.Religion,
                    SSD = gradutesInfo.SSD,
                    SSDFile = "",
                    University = gradutesInfo.University
                });

                await _context.SaveChangesAsync();
                result.Code = ResponseCode.Success;

            }
            catch (Exception ex)
            {
                result.Code = ResponseCode.Error;
            }
            return result;
        }

        //Upload PostGradute Photos 
        public async Task<Response<LoggedUserVM>> UploadPostGradutesPhotoInfo(IFormFileCollection file , string SSD)
        {
            var postGradute = await _context.PostGradutesInfos.FirstOrDefaultAsync(p => p.SSD == SSD);
            Response<LoggedUserVM> response = new Response<LoggedUserVM>();
            if(postGradute != null)
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
                        if(item.Name == "SSDFile")
                        {
                            postGradute.SSDFile = dbPath;
                        }

                        else if(item.Name == "MilirtyFile")
                        {
                            postGradute.MilirtyFile = dbPath;
                        }

                        else if(item.Name == "ApproveAffairFile")
                        {
                            postGradute.ApproveAffairFile = dbPath;
                        }

                        else if (item.Name == "AcknowledmentJobFile")
                        {
                            postGradute.AcknowledmentJobFile = dbPath;
                        }

                        else if (item.Name == "AcknowledmentFile")
                        {
                            postGradute.AcknowledmentFile = dbPath;
                        }
                        else if (item.Name == "BirthCertificate")
                        {
                            postGradute.BirthCertificate = dbPath;
                        }
                        else
                        {
                            postGradute.Photo = dbPath;
                        }

                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            item.CopyTo(stream);
                          

                        }

                        await _context.SaveChangesAsync();
                        response.Code = ResponseCode.Success;
                        response.DataResult = new LoggedUserVM
                        {
                            SSD = SSD,
                            Token = _tokenService.CreatToken(postGradute)
                        };

                    }
                    
                }
            }


            return response;
        }

        //get specific PostGradute
        public async Task<Response<PostGradutesInfo>> getPostGradute (string SSD)
        {
            Response<PostGradutesInfo> postGradutes = new Response<PostGradutesInfo>();
            postGradutes.DataResult = await _context.PostGradutesInfos.Where(p=>p.SSD == SSD.ToString()).FirstOrDefaultAsync();
            if (postGradutes.DataResult != null)
                postGradutes.Code = ResponseCode.Success;

            return postGradutes;
        }

        //get All PostGradutes 

        public List<PostGradutesInfo> GetPostGradutes()
        {
         
            List<PostGradutesInfo> postGradutes = new List<PostGradutesInfo>();
            postGradutes = _context.PostGradutesInfos.ToList();
            return postGradutes;
        }
    
         

        
    }
}
