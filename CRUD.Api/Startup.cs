using CRUD.Api.Business;
using CRUD.Api.Context;
using CRUD.Api.Contracts;
using CRUD.Api.Framework.Business;
using CRUD.Api.Framework.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CRUD.Api
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
            var stringConnection = "Server=DESKTOP-N3AACJ8;Database=CRUD;Trusted_Connection=True;";
            services.AddDbContext<CRUDContext>(options => options.UseSqlServer(stringConnection));

            services.AddControllers();
            services.AddApiVersioning();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRUD.Api", Version = "v1" });
            });

            services.AddCors(options => options.AddDefaultPolicy(builder => 
            {
                builder.AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowAnyHeader();
            }));

            services.AddScoped<IPlayerContract, PlayerBusiness>();
            services.AddScoped<ITeamContract, TeamBusiness>();
            services.AddScoped(typeof(IBaseContract<>), typeof(BaseBusiness<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRUD.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseApiVersioning();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
