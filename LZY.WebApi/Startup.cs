using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LZY.DataAccess;
using LZY.DataAccess.EntityFramework;
using LZY.Model.ApplicationOrganization;
using LZY.Model.Attachments;
using LZY.Model.WebSettingManagement;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LZY.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private string cors = "any";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // 添加 EF Core 框架，连接串在appsettings设置
            services.AddDbContext<EntityDbContext>(d => d.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, ApplicationRole>()
               .AddEntityFrameworkStores<EntityDbContext>()
               .AddDefaultTokenProviders();


            //配置 Identity
            services.Configure<IdentityOptions>(options =>
            {
                // 密码策略的常规设置
                options.Password.RequireDigit = true;            // 是否需要数字字符
                options.Password.RequiredLength = 6;             // 必须的长度
                options.Password.RequireNonAlphanumeric = true;  // 是否需要非拉丁字符，如%，@ 等
                options.Password.RequireUppercase = false;        // 是否需要大写字符
                options.Password.RequireLowercase = false;        // 是否需要小写字符

                // 登录尝试锁定策略
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;



                //    // 其它的一些设置
                options.User.RequireUniqueEmail = true;
            });
            #region 域控制器相关的依赖注入服务清单
            services.AddTransient<IEntityRepository<BusinessImage>, EntityRepository<BusinessImage>>();
            services.AddTransient<IEntityRepository<BusinessFile>, EntityRepository<BusinessFile>>();
            services.AddTransient<IEntityRepository<BusinessVideo>, EntityRepository<BusinessVideo>>();
            services.AddTransient<IEntityRepository<WebSiteSettings>, EntityRepository<WebSiteSettings>>();
            services.AddTransient<IEntityRepository<Person>, EntityRepository<Person>>();
            services.AddTransient<IEntityRepository<Department>, EntityRepository<Department>>();

            #endregion


            //注册IdentityServer 
            services.AddAuthentication(config => {
                config.DefaultScheme = "Bearer"; //这个是access_token的类型，获取access_token的时候返回参数中的token_type一致
            }).AddIdentityServerAuthentication(option => {
                option.ApiName = "api"; //资源名称，认证服务注册的资源列表名称一致，
                option.Authority = "https://localhost:5000"; //认证服务的url
                option.RequireHttpsMetadata = true; //是否启用https

            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //跨域
            services.AddCors(options =>
            {
                options.AddPolicy(cors, builder =>
                {
                    builder.AllowAnyOrigin() //允许任何来源的主机访问
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();//指定处理cookie
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(cors);
            app.UseHttpsRedirection();//跨域
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
