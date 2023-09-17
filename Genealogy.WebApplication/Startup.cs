using Genealogy.Business.Core.Base;
using Genealogy.Common;
using Microsoft.Extensions.DependencyInjection;
using velocist.Services.Core;

namespace Genealogy.WebApplication {

    /// <summary>
    /// The Startup class for the application web
    /// </summary>
    public class Startup {

        /// <summary>
        /// Constructor of the startup class
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// Method for registry services tot eh container
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services) {
            /* HSTS (HTTP Strict Transport Security)
             * Forces the web server to communicate over an HTTPS connection */
            _ = services.AddHsts(options => {
                options.IncludeSubDomains = true; //The Strict-Transport-Security header will be available for subdomains too
                options.Preload = true; //Adds preload support to the Strict-Transport-Security
                options.MaxAge = TimeSpan.FromDays(30); //The max-age of the Strict-Transport-Security is 30 days
            });
            //services.AddHttpsRedirection(options => {
            //    options.HttpsPort = 443;
            //});

            _ = Configuration.ConfigureApp();

            _ = services.ConfigureAppServiceWeb();
            _ = services.ConfigureAppDatabaseServices();
            _ = services.ConfigureAppUnitOfWork();
            _ = services.ConfigureAppServices();

            _ = services.AddControllersWithViews()
                .AddRazorPagesOptions(options => {
                    //options.AllowAreas = true;
                    _ = options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                    _ = options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                })
                .AddRazorRuntimeCompilation()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
            _ = services.AddRazorPages();

            _ = services.ConfigureApplicationCookie(options => {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });
        }

        /// <summary>
        /// Method fo configure the HTTP request pipeline.
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment())
                _ = app.UseDeveloperExceptionPage();
            else {
                _ = app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                _ = app.UseHsts();

            }
            // global error handler
            //app.UseMiddleware<TraceHandlerMiddleware>();

            var defaultCulture = new CultureInfo("es-ES");
            var localizationOptions = new RequestLocalizationOptions {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            };

            _ = app.UseRequestLocalization(localizationOptions);
            _ = app.UseHttpsRedirection();
            _ = app.UseDefaultFiles();
            _ = app.UseStaticFiles(new StaticFileOptions {
                OnPrepareResponse = _ => _.Context.Response.Headers.Append("Cache-Control", string.Format("public,max-age={0}", TimeSpan.FromDays(7).TotalSeconds))
            });

            _ = app.UseRouting();
            _ = app.UseAuthentication();
            _ = app.UseAuthorization();
            _ = app.UseEndpoints(endpoints => {
                _ = endpoints.MapRazorPages();
                _ = endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
