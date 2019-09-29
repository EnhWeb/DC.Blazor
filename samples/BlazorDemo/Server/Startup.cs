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
    /// ��������
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// ��ʼ����������
        /// </summary>
        /// <param name="configuration">����</param>
        /// <param name="env">��������</param>
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            ConfigFileHelper.Set(env: env);
            Configuration = configuration;
        }

        /// <summary>
        /// ����
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

            //���NLog��־����
            services.AddNLog();

            //���EF������Ԫ
            switch (Configuration["Data:Provider"])
            {
                case "MSSQL2012":
                    //====== ֧��Sql Server 2012+ ==========
                    services.AddUnitOfWork<IDCCRMUnitOfWork, DCCRM.Data.SqlServer.DCCRMUnitOfWork>(Configuration.GetConnectionString("DefaultConnection"), Configuration);
                    break;

                case "MSSQL2005":
                    //======= ֧��Sql Server 2005+ ==========
                    services.AddUnitOfWork<IDCCRMUnitOfWork, DCCRM.Data.SqlServer.DCCRMUnitOfWork>(builder =>
                    {
                        builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), option => option.UseRowNumberForPaging());
                    });
                    break;

                case "MySQL":
                    //======= ֧��MySql =======
                    services.AddUnitOfWork<IDCCRMUnitOfWork, DCCRM.Data.MySql.DCCRMUnitOfWork>(Configuration.GetConnectionString("MySqlConnection"), Configuration);
                    break;

                case "Sqlite":
                    //======= ֧��Sqlite =======
                    services.AddUnitOfWork<IDCCRMUnitOfWork, DCCRM.Data.Sqlite.DCCRMUnitOfWork>(Configuration.GetConnectionString("SqliteConnection"), Configuration);
                    break;

                case "PostgreSQL":
                default:
                    //======= ֧��PgSql =======
                    services.AddUnitOfWork<IDCCRMUnitOfWork, DCCRM.Data.PgSql.DCCRMUnitOfWork>(Configuration.GetConnectionString("PgSqlConnection"), Configuration);
                    break;
            }

            //����¼�����
            services.AddEventBus();

            //���Cap�¼�����
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
