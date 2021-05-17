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
            //����cookie,ʹ��cookie��Ϊ��֤��ʽ
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options=> 
                {
                    options.LoginPath = "/Account/Index";//Ĭ�ϵ�¼·��
                    options.LogoutPath = "/Account/Logout";//Ĭ�ϵǳ�·��
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(15);//cookie��Чʱ��
                });

            //����session
            services.AddSession(options => 
            {
                options.IdleTimeout = TimeSpan.FromMinutes(15);//session����ʧЧʱ��
                options.Cookie.HttpOnly = true;//����ͨ���ű�js�޷���ȡCookie,��ֹXSS����
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddScoped<IManagerRepository, ManagerRepository>();//.netcore �Դ�����ע������
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

            loggerFactory.AddLog4Net();//��־ϵͳ

            app.UseRequestIp();//�Զ����м������¼����Ip

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();

            app.UseSession();//ʹ��session

            app.UseAuthentication();//��֤

            app.UseAuthorization();//��Ȩ

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
