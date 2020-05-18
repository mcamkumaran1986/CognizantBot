using Cognizant.BotStore.API.Utilities;
using Cognizant.BotStore.Infrastructure;
using Cognizant.BotStore.Shared;
using Cognizant.BotStore.Shared.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
namespace Cognizant.BotStore.API
{
    public class Startup
    {
        public IConfiguration Configurations { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configurations = configuration;
            var builder = BuildJsonConfiguration.AddConfigurationBuilder(configuration);
            var logconfig = Configurations.GetSection(nameof(LogSetting));
            Serilogging.CreateLogger(logconfig);

            Configurations = builder.Build();

            // Use decrypted connection string to load systemparamvalue
            builder.AddConfigurationFromTable(options => options.UseSqlServer(Configurations.GetConnectionString("BotStoreDBConnectionDBConnection")));
            Configurations = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bot store API", Version = "v1" });
            });

            string connectionString = Configurations.GetConnectionString("BotStoreDBConnectionDBConnection");

            services.AddDbContext<BotStoreDBContext>(options =>
            {
                try
                {
                    options.UseSqlServer(connectionString,
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                    });
                }
                catch (System.Exception ex)
                {
                    Log.Error("Exception occurred in Add Bot Store DB Context", ex);
                }
            });
            services.AddTransient<BotStoreDBContext>();

            services.AddEfCoreRepository();
            services.AddEntityServices();
            services.Add(new ServiceDescriptor(typeof(IConfiguration),
                 provider => Configurations,
                 ServiceLifetime.Singleton));

            services.Configure<FormOptions>(o =>
            {
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
                app.UseMiddleware<GlobalErrorHandlerMiddleware>();
            }
            else
            {
                app.UseMiddleware<GlobalErrorHandlerMiddleware>();
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Bot Store API V1");

            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
