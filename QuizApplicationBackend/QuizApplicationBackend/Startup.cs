using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using QuizApplicationBackend.Data;
using QuizApplicationBackend.Repository;
using QuizApplicationBackend.Repository.IRepository;
using QuizApplicationBackend.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplicationBackend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string cs = Configuration.GetConnectionString("Constr");
            services.AddEntityFrameworkSqlServer().AddDbContext<ApplicationDbContext>
             (option => option.UseSqlServer(cs));
            services.AddScoped<IRegisterRepository, RegisterRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IParticipantRepository ,ParticipantRepository>();
            services.AddAutoMapper();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "QuizApplicationBackend", Version = "v1" });
            });

            //JWt Authetication
            var AppSettingSection = Configuration.GetSection("JwtToken");
            services.Configure<JwtToken>(AppSettingSection);
            var AppSetting = AppSettingSection.Get<JwtToken>();
            var Key = Encoding.ASCII.GetBytes(AppSetting.secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddCors(options =>
            {
                options.AddPolicy(name: "MyPolice",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200", "http://localhost:4200")
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                       .AllowAnyMethod();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuizApplicationBackend v1"));
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();

            app.UseCors("MyPolice");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
