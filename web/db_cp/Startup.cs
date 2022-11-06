using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using db_cp.Models;
using db_cp.Services;
using db_cp.Interfaces;
using db_cp.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.IO;
using db_cp.Logger;

namespace db_cp
{
    public class Startup
    {
        private IConfigurationRoot _configuration;

        public Startup(IWebHostEnvironment hostEnv)
        {
            _configuration = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<AppDBContext>(options => options.UseSqlServer(_configuration.GetConnectionString("MSSQLServerConnection")));
            //services.AddDbContext<AppDBContext>(options => options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection")));

            var dbms = _configuration["Database"];

            services.AddDbContext<AppDBContext>(
                options => _ = dbms switch
                {
                    "PostgreSQL" => options.UseNpgsql(
                        _configuration.GetConnectionString("DefaultConnection")),

                    "MSSQLServer" => options.UseSqlServer(
                        _configuration.GetConnectionString("MSSQLServerConnection")),

                    _ => throw new Exception($"Unsupported provider: {dbms}")
                }
            );

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                    options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });

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

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logs"));

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
