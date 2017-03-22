using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;
using TodoAngular2AspNetCore.Data;
using StructureMap;
using TodoAngular2AspNetCore.Core.Infrastructure;
using TodoAngular2AspNetCore.Models;
using TodoAngular2AspNetCore.Services;
using Container = StructureMap.Container;

namespace TodoAngular2AspNetCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            env.ConfigureNLog("nlog.config");
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TodoConnectionString")));

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("TodoConnectionString")));

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            // Add framework services.
            services.AddMvc().AddControllersAsServices();
            services.AddLogging();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
    
            // Add commands
            var types = GetCommandQueryTypes();
            foreach (var type in types)
            {
                services.AddTransient(type);
            }

            var container = new Container();

            container.Configure(config =>
            {
                // Register stuff in container, using the StructureMap APIs...
                config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();

        }

        private static IEnumerable<Type> GetCommandQueryTypes()
        {
            List<Type> types = new List<Type>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assem in assemblies)
            {
                var definedTypes = assem.DefinedTypes;
                foreach (var defType in definedTypes)
                {
                    if (defType.IsClass && (
                                            defType.Name.EndsWith("command", StringComparison.CurrentCultureIgnoreCase) ||
                                            defType.Name.EndsWith("query", StringComparison.CurrentCultureIgnoreCase)
                                            )
                                            && !defType.Name.StartsWith("icommand", StringComparison.CurrentCultureIgnoreCase) && !defType.Name.StartsWith("iquery", StringComparison.CurrentCultureIgnoreCase)
                        ) 
                    {
                        types.Add(defType.UnderlyingSystemType);
                    }
                }
            }

            return types;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddNLog();
           

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.AddNLogWeb();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
