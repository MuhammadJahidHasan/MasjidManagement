﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidManagement
{
    public class Startup
    {

        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContextPool<AppDbContext>(
           options => options.UseSqlServer(_config.GetConnectionString("MusolliDBConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                     .AddEntityFrameworkStores<AppDbContext>();

            services.AddMvc().AddXmlSerializerFormatters();
            services.AddSingleton<IMusolliRepo, MockMusolliRepo>();
            services.AddSingleton<AddMusolliAmountRepo, AddMusolliAmountRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();

           // app.Run(async (context) =>
           // {
               // await context.Response.WriteAsync("Hello World!");
           // });
        }
    }
}