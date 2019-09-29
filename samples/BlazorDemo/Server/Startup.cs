using DCCRM.Data;
using Ding;
using Ding.Configs;
using Ding.Datas.Ef;
using Ding.Events.Default;
using Ding.Logs.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace BlazorDemo.Server
{
    /// <summary>
    /// 启动配置
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 初始化启动配置
        /// </summary>
        /// <param name="configuration">配置</param>
        /// <param name="env">环境变量</param>
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            ConfigFileHelper.Set(env: env);
            Configuration = configuration;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });

            //添加NLog日志操作
            services.AddNLog();

            //添加EF工作单元
            switch (Configuration["Data:Provider"])
            {
                case "MSSQL2012":
                    //====== 支持Sql Server 2012+ ==========
                    services.AddUnitOfWork<IDCCRMUnitOfWork, DCCRM.Data.SqlServer.DCCRMUnitOfWork>(Configuration.GetConnectionString("DefaultConnection"), Configuration);
                    break;

                case "MSSQL2005":
                    //======= 支持Sql Server 2005+ ==========
                    services.AddUnitOfWork<IDCCRMUnitOfWork, DCCRM.Data.SqlServer.DCCRMUnitOfWork>(builder =>
                    {
                        builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), option => option.UseRowNumberForPaging());
                    });
                    break;

                case "MySQL":
                    //======= 支持MySql =======
                    services.AddUnitOfWork<IDCCRMUnitOfWork, DCCRM.Data.MySql.DCCRMUnitOfWork>(Configuration.GetConnectionString("MySqlConnection"), Configuration);
                    break;

                case "Sqlite":
                    //======= 支持Sqlite =======
                    services.AddUnitOfWork<IDCCRMUnitOfWork, DCCRM.Data.Sqlite.DCCRMUnitOfWork>(Configuration.GetConnectionString("SqliteConnection"), Configuration);
                    break;

                case "PostgreSQL":
                default:
                    //======= 支持PgSql =======
                    services.AddUnitOfWork<IDCCRMUnitOfWork, DCCRM.Data.PgSql.DCCRMUnitOfWork>(Configuration.GetConnectionString("PgSqlConnection"), Configuration);
                    break;
            }

            //添加事件总线
            services.AddEventBus();

            //添加Cap事件总线
            //services.AddEventBus( options => {
            //    options.UseDashboard();
            //    options.UseSqlServer( Configuration.GetConnectionString( "DefaultConnection" ) );
            //    options.UseRabbitMQ( "192.168.244.138" );
            //} );

            services.AddDing();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
            }

            app.UseStaticFiles();
            app.UseClientSideBlazorFiles<Client.Startup>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToClientSideBlazor<Client.Startup>("index.html");
            });
        }
    }
}
