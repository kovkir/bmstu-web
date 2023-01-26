﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.Logging;
using AutoMapper;
using db_cp.Utils;
using System.Text.Json.Serialization;

using Microsoft.EntityFrameworkCore;
using db_cp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using db_cp.Services;
using db_cp.Interfaces;
using db_cp.Repository;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace db_cp
{
    public class Startup
    {

        private IConfigurationRoot _configuration;

        public Startup(IWebHostEnvironment hostEnv)
        {
            _configuration = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        // This method gets called by the runtime
        public virtual void ConfigureServices(IServiceCollection services)
        {

            // Connect to DB
            var provider = _configuration["Database"];

            services.AddDbContext<AppDBContext>(
                options => _ = provider switch
                {
                    "PostgreSQL" => options.UseNpgsql(
                        _configuration.GetConnectionString("DefaultConnection")
                        ),
                    _ => throw new Exception($"Unsupported provider: {provider}")
                }
            );

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<ICoachService, CoachService>();
            services.AddTransient<IClubService, ClubService>();
            services.AddTransient<ISquadService, SquadService>();
            services.AddTransient<IAgentService, AgentService>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<ICoachRepository, CoachRepository>();
            services.AddTransient<IClubRepository, ClubRepository>();
            services.AddTransient<ISquadRepository, SquadRepository>();
            services.AddTransient<IAgentRepository, AgentRepository>();


            // MVC
            services.AddControllers().AddJsonOptions(o =>
            {
                var enumConverter = new JsonStringEnumConverter();
                o.JsonSerializerOptions.Converters.Add(enumConverter);
            }); // add string enum
            services.AddEndpointsApiExplorer();

            // Swagger
            services.AddSwaggerGen();

            // Admin Page
            services.AddCoreAdmin();

            // AutoMapper
            services.AddAutoMapper(typeof(AutoMappingProfile));

            // DTO converters
            services.AddDtoConverters(); // self

            // CORS
            services.AddCors(options => {
                options.AddPolicy(name: "MyPolicy",
                    policy => {
                        policy
                            .WithOrigins("*")
                            .WithHeaders("*")
                            .WithMethods("*");
                    });
            });
        }

        // This method gets called by the runtime
        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                // app.UseSwagger();
                app.UseSwagger(c => {
                    c.RouteTemplate = "/api/v1/swagger/{documentName}/swagger.json";
                });
                app.UseSwaggerUI(c => {
                    //Notice the lack of / making it relative
                    c.SwaggerEndpoint("swagger/v1/swagger.json", "My API V1");
                    //This is the reverse proxy address
                    c.RoutePrefix = "api/v1";
                });
                app.UseDeveloperExceptionPage();
            }

            // Authentication
            // app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            // app.UseHttpsRedirection();

            app.UseCors();

            app.UseStaticFiles(); // стили для админки
            app.UseCoreAdminCustomUrl("admin");

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();     // нет определенных маршрутов
            });
        }
    }
}