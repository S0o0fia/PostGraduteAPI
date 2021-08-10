using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniWebAPI.Models;
using UniWebAPI.Controllers;
using UniWebAPI.Helpers;
using UniWebAPI.Interface;
using UniWebAPI.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace UniWebAPI
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            this._config = config;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
               options =>
               {
                   options.UseSqlServer(this._config.GetConnectionString("DefaultConncetion"));
               });

           
            services.AddControllers();
            //services.AddCors();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.SetIsOriginAllowed(origin => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options=>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"])),
                        ValidateAudience = false,
                        ValidateIssuer = false
                    };
                }) ;
            services.AddScoped<IPhotoService , PhotoService>();
            services.AddScoped<ITokenService , TokenService>();
            services.AddScoped<IPostGradutesService , PostGradutesService>();
            services.AddScoped<IPostGradutesPhdService , PostGradutesPhdService>();
            services.AddScoped<IPostGradutesMasterService , PostGradutesMasterService>();
            services.AddScoped<IPostGradutesDiplomaService, PostGradutesDiplomaService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UniWebAPI", Version = "v1" });
            });
            
            services.Configure<CloudinarySetting>(_config.GetSection("CloudinarySettings"));

            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "UniWebAPI v1");
                    //c.RoutePrefix = string.Empty;

                }
                ) ;
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();


            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
                RequestPath = new PathString("/StaticFiles")
            });

            //you need change the origin when you deploy the front end with new url to it 
            //app.UseCors(policy => policy.AllowAnyHeader()
            //                           .AllowAnyMethod()
            //                           .AllowAnyOrigin());
            app.UseCors("CorsPolicy");


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
