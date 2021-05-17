using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyBBS.Filter;
using MyBBS.Middleware;
using AutoMapper;
using System.Reflection;
using Autofac;
using ApplicationCore.IRepostiory;
using ApplicationCore.Repository;
using ApplicationCore.IServices;
using ApplicationCore.Services;
using MyBBS.Utils;

namespace MyBBS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        { 
            containerBuilder.RegisterModule<ConfigureAutofac>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DbOption>("CzarCms", Configuration.GetSection("DbOpion"));

            services.AddControllersWithViews(options=> 
            {
                options.Filters.Add(typeof(GlobalExceptionFilter));
            
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //配置cookie,使用cookie作为认证方式
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options=> 
                {
                    options.LoginPath = "/Account/Index";//默认登录路径
                    options.LogoutPath = "/Account/Logout";//默认登出路径
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(15);//cookie有效时间
                });

            //配置session
            services.AddSession(options => 
            {
                options.IdleTimeout = TimeSpan.FromMinutes(15);//session空闲失效时间
                options.Cookie.HttpOnly = true;//设置通过脚本js无法读取Cookie,防止XSS攻击
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddScoped<IManagerRepository, ManagerRepository>();//.netcore 自带依赖注入容器
            //services.AddScoped<IManagerService, ManagerService>();

            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            loggerFactory.AddLog4Net();//日志系统

            app.UseRequestIp();//自定义中间件，记录访问Ip

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();

            app.UseSession();//使用session

            app.UseAuthentication();//认证

            app.UseAuthorization();//授权

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
