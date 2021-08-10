using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniWebAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base(options)
        {

        }
        //put your Dbsets here 
        public DbSet<UniversityInfo> universityInfos { set; get; }
        public DbSet<Collage> Colleges { set; get; }
        public DbSet<News> News { set; get; }
        public DbSet<NewsImg> NewsImgs { set; get; }
        public DbSet<PostGradutesInfo> PostGradutesInfos { set; get; }
        public DbSet<PostGradutesDiploma> PostGradutesDiplomas { set; get; }
        public DbSet<PostGraduteMaster> PostGraduteMasters { set; get; }
        public DbSet<PostGradutePhd> PostGradutePhds { set; get; }






    }
}
