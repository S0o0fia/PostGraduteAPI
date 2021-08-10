using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniWebAPI.Models;

namespace UniWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext _context; 
        public HomeController (ApplicationDbContext context )
        {
            this._context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<UniversityInfo>> GetUniInfo ()
        {
            var info = _context.universityInfos.ToList();

            return info;
        }

    }
}
