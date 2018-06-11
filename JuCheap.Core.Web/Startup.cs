using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using log4net;
using JuCheap.Core.Infrastructure.Utilities;
using System.IO;
using log4net.Config;
using JuCheap.Core.Data;
using Microsoft.EntityFrameworkCore;
using JuCheap.Core.Web.Filters;
using JuCheap.Core.Services;
using JuCheap.Core.Interfaces;
using JuCheap.Core.Services.AppServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Principal;
using System.Security.Claims;

namespace JuCheap.Core.Web
{
    public class Startup
    {
        //����Ȩ����֤����½�����֤��������ӡ�
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            var repository = LogManager.CreateRepository(Constants.Log4net.RepositoryName);
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o =>
                {
                    o.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
                    o.LoginPath = new PathString("/Home/Login");
                    o.LogoutPath = new PathString("/Home/Logout");
                    o.Cookie = new CookieBuilder
                    {
                        HttpOnly = true,
                        Name = ".JuCheap.Core.Identity",
                        Path = "/"
                    };
                    //o.DataProtectionProvider = null;//�����Ҫ�����ؾ��⣬����Ҫ�ṩһ��Key
                });
            ////ʹ��Sql Server���ݿ�
            //services.AddDbContext<JuCheapContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Connection_SqlServer")));
            //֧��sql2008��row_number��ҳ����
            //services.AddDbContext<JuCheapContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Connection_SqlServer"), x => x.UseRowNumberForPaging()));

            ////ʹ��Sqlite���ݿ�
            //services.AddDbContext<JuCheapContext>(options => options.UseSqlite(Configuration.GetConnectionString("Connection_Sqlite")));

            //ʹ��MySql���ݿ�
            services.AddDbContext<JuCheapContext>(options => options.UseMySql(Configuration.GetConnectionString("Connection_MySql")));

            //Ȩ����֤filter��һ�������������֤,��Ҫ����ajax�жϺ���ת��
            services.AddMvc(cfg =>
            {
                cfg.Filters.Add(new RightFilter());
            });

            // Add application services.
            // 1.automapper
            services.AddScoped<AutoMapper.IConfigurationProvider>(_ => AutoMapperConfig.GetMapperConfiguration());
            services.AddScoped(_ => AutoMapperConfig.GetMapperConfiguration().CreateMapper());

            // 2.service
            services.AddScoped<IDatabaseInitService, DatabaseInitService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IPathCodeService, PathCodeService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IAreaService, AreaService>();
            //�Լ����
            services.AddScoped<ICameraPathService, CameraPathService>();
            services.AddScoped<IStationService, StationService>();
            services.AddScoped<IGisProService, GisProService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMiddleware<VisitMiddleware>();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //init database
            
            Task.Run(async () =>
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var dbService = scope.ServiceProvider.GetService<IDatabaseInitService>();
                    await dbService.InitAsync();
                }
            });
        }
    }

    /// <summary>
    /// IIdentity��չ
    /// </summary>
    public static class IdentityExtention
    {
        /// <summary>
        /// ��ȡ��¼���û�ID
        /// </summary>
        /// <param name="identity">IIdentity</param>
        /// <returns></returns>
        public static string GetLoginUserId(this IIdentity identity)
        {
            var claim = (identity as ClaimsIdentity)?.FindFirst("LoginUserId");
            if (claim != null)
            {
                return claim.Value;
            }
            return string.Empty;
        }
    }
}
