using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using WishList_Desenvolvimento_Senai.Interfaces;
using WishList_Desenvolvimento_Senai.Interfaces.IRespositories;
using WishList_Desenvolvimento_Senai.Interfaces.IServices;
using WishList_Desenvolvimento_Senai.Repositories;
using WishList_Desenvolvimento_Senai.Services;

namespace Senai_desenvolvimento
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
            services.AddMvc()
           //Adiciona as opções do json 
           .AddJsonOptions(options => {
               options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
           }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "WishList", Version = "v1" });
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }
            ).AddJwtBearer("JwtBearer", options =>
            {
                //Define as opções 
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //Quem esta solicitando
                    ValidateIssuer = true,
                    //Quem esta validadando
                    ValidateAudience = true,
                    //Definindo o tempo de expiração
                    ValidateLifetime = true,
                    //Forma de criptografia
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("WishList.WebApi.Desenvolvimento.Senai")),
                    //Tempo de expiração do Token
                    ClockSkew = TimeSpan.FromMinutes(30),
                    //Nome da Issuer, de onde esta vindo
                    ValidIssuer = "WishList.WebApi",
                    //Nome da Audience, de onde esta vindo
                    ValidAudience = "WishList.WebApi"
                };
            });


            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IWishRepository, WishRepository>();
            services.AddTransient<IWishService, WishService>();





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WishList");
            });

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
