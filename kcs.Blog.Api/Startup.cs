using kcs.Blog.Domain.Entities;
using kcs.Blog.Application;
using kcs.Blog.Infrastructure.Context;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using kcs.Blog.Core.Data;
using MediatR;
using MediatR.Pipeline;
using kcs.Blog.Abstraction;
using FluentValidation.AspNetCore;
using kcs.Blog.Abstraction.Validator;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using kcs.Blog.Abstraction.HealthChecks;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using static kcs.Blog.Api.Controllers.AuthController;
using kcs.Blog.Abstraction.Authorization;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
//using kcs.Blog.Application.ValidationRequestPreProcessor;

namespace kcs.Blog.Api
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
            services.AddControllers();
            services.AddMvc(options => options.EnableEndpointRouting = false).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateArticleCommandValidator>());
            services.RegisterRequestHandlers();
            services.AddHealthChecks().AddDbContextCheck<BlogDbContext>();
            var tokenKey = Configuration.GetValue<string>("TokenKey");
            var key = Encoding.ASCII.GetBytes(tokenKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSingleton<IJWTAuthenticationManager>(new JWTAuthenticationManager(tokenKey));
            var configurationSection = Configuration.GetSection("ConnectionStrings:DefaultConnection");
            services.AddDbContext<BlogDbContext>(options =>
                options.UseSqlServer(configurationSection.Value)
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddOData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.ConfigureHealthCheck();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvc(p =>
            {
                p.Select().Expand().Filter().OrderBy().Count().MaxTop(100);
                p.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Article>("Articles");
            builder.EntitySet<Review>("Reviews");
            return builder.GetEdmModel();
        }
    }
}
