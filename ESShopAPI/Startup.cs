using ESShopDAL.EFCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;
using System.Reflection;
using System.Linq;
using ESShopBL;
using Microsoft.Extensions.Options;

namespace ESShopAPI
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
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ESShopAPI", Version = "v1" });
            });

            services.AddDbContext<ESShopContext>(option =>
            {
                var builder = new SqlConnectionStringBuilder();
                builder.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
                builder.Password = Configuration["SQLPassword"];
                option.UseSqlServer(builder.ConnectionString);
            });

            services.AddDatabaseDeveloperPageExceptionFilter();
            ScanAllServicesAndAddScoped(services);
        }

        private static void ScanAllServicesAndAddScoped(IServiceCollection services)
        {
            var allIServiceImplementationClasses = Assembly.GetExecutingAssembly()
                                        .GetReferencedAssemblies()
                                        .SelectMany(assemblyName => Assembly.Load(assemblyName).GetTypes())
                                        .Where(assembly => typeof(IService).IsAssignableFrom(assembly)
                                                           && !assembly.IsInterface
                                                           && !assembly.IsAbstract)
                                        .ToList();

            foreach (var type in allIServiceImplementationClasses)
            {
                services.AddScoped(type);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ESShopAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
