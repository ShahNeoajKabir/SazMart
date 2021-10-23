
using BLLManager.BusinessLogic;
using BLLManager.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SazMart.Common.Helper;
using SazMart.DAL.Database;
using SazMart.DAL.ModelClass.DTO;

namespace SazMart.Service
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
            //services.AddIdentityCore<AppUser>(opt =>
            //{
            //    opt.Password.RequireNonAlphanumeric = false;
            //    opt.Password.RequireUppercase = false;
            //    opt.Password.RequireLowercase = false;
            //    opt.Password.RequiredUniqueChars = 0;
            //    opt.Password.RequireDigit = false;

            //})
            //    .AddEntityFrameworkStores<DatabaseContext>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SazMart.Service", Version = "v1" });
            });

            services.AddDbContext<DatabaseContext>(
                opt => opt.UseSqlServer(Configuration.GetConnectionString("Connection")),
                ServiceLifetime.Transient

                );

            services.AddAutoMapper(typeof(AutoMappingProfile).Assembly);
            services.AddScoped<IBrandBLLManager, BrandBLLManager>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SazMart.Service v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
