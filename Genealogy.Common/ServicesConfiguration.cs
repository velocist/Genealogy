using Genealogy.Business.Services;
using Genealogy.Business.Services.Interfaces;
using Genealogy.IdentityService;
using Genealogy.IdentityService.Entities;
using Genealogy.Objects.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using velocist.DataAccess;
using velocist.DataAccess.Core;
using velocist.Services;
using velocist.Services.Core;
using velocist.Services.Core.Interfaces;
using velocist.Services.Core.Interfaces.SqlServer;
using velocist.Services.Helpers;
using velocist.Web;

namespace Genealogy.Common {
    public static class ServicesConfiguration {

        /// <summary>
        /// Gets or sets the service collection.
        /// </summary>
        /// <value>
        /// The service collection.
        /// </value>
        public static IServiceCollection? ServiceCollection { get; set; }

        /// <summary>
        /// Configuration
        /// </summary>
        public static IConfiguration? Configuration { get; set; }

        static ServicesConfiguration() {

        }

        /// <summary>
        /// Configures the application.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static IConfiguration ConfigureApp(this IConfiguration configuration) {
            try {
                configuration = AccessServiceConfiguration.GetConfiguration();
                Configuration = configuration;
                return configuration;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Configures the application unit of work.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static IServiceCollection ConfigureAppUnitOfWork(this IServiceCollection serviceCollection) {
            try {
                serviceCollection.AddTransient(typeof(IBaseEntity), typeof(BaseEntity));
                serviceCollection.AddScoped(typeof(IBaseModel), typeof(BaseModel));
                serviceCollection.AddScoped(typeof(IRepository<,>), typeof(GenericRepository<,>));
                serviceCollection.AddScoped(typeof(IUnitOfWorkSqlServer<>), typeof(UnitOfWork<>));
                serviceCollection.AddScoped(typeof(IBaseService<,,>), typeof(BaseService<,,>));

                ServiceCollection = serviceCollection;
                return serviceCollection;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static IServiceCollection ConfigureAppServices(this IServiceCollection serviceCollection) {
            try {
                serviceCollection.AddScoped(typeof(IFSCatalogService<,,>), typeof(BaseService<,,>));
                serviceCollection.AddScoped<FSCatalogService>();

                serviceCollection.AddScoped(typeof(IFSFilmService<,,>), typeof(BaseService<,,>));
                serviceCollection.AddScoped<FSFilmService>();

                serviceCollection.AddScoped(typeof(IFSImageService<,,>), typeof(BaseService<,,>));
                serviceCollection.AddScoped<FSImageService>();

                serviceCollection.AddScoped(typeof(IFSRecordService<,,>), typeof(BaseService<,,>));
                serviceCollection.AddScoped<FSRecordService>();

                serviceCollection.AddScoped(typeof(IRecursoService<,,>), typeof(BaseService<,,>));
                serviceCollection.AddScoped<RecursoService>();

                serviceCollection.AddScoped(typeof(IIndiceService<,,>), typeof(BaseService<,,>));
                serviceCollection.AddScoped<IndiceImagenService>();

                serviceCollection.AddScoped(typeof(IInvestigacionService<,,>), typeof(BaseService<,,>));
                serviceCollection.AddScoped<InvestigacionService>();

                ServiceCollection = serviceCollection;
                return serviceCollection;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Configures the application database services.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <returns></returns>
        public static IServiceCollection ConfigureAppDatabaseServices(this IServiceCollection serviceCollection) {
            /* Application DbContext */
            serviceCollection.AddServicesDbContextApp<AppEntitiesContext>(AccessServiceConfiguration.GetConnectionString(AccessServiceConfiguration.GetAppConnectionName()), AccessServiceConfiguration.GetAppContextMigration());

            /* Identity Auth DbContext */
            var authConnectionString = AccessServiceConfiguration.GetConnectionString(AccessServiceConfiguration.GetAppConnectionName());
            serviceCollection.AddServicesIdentityDbContext<AuthContext>(authConnectionString, AccessServiceConfiguration.GetAuthContextMigration(), requireConfirmedAccount: false);
            ServiceCollection = serviceCollection;
            return serviceCollection;
        }

        /// <summary>
        /// Configures the application service web.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <param name="translationsFolder">The translations folder.</param>
        /// <returns></returns>
        public static IServiceCollection ConfigureAppServiceWeb(this IServiceCollection serviceCollection, string translationsFolder = "Translations") {
            /* Services */
            serviceCollection.AddServicesHttpContextAccessor();
            serviceCollection.AddServicesRenderView();
            serviceCollection.AddServicesAntiforgeryToken();
            serviceCollection.AddServicesSendGrid(Configuration, "AuthMessageSenderOptions");
            serviceCollection.AddServicesEmail(Configuration, "SmtpHelper");
            serviceCollection.AddServicesDatetime();

            /* Cookies web */
            serviceCollection.AddServicesCookies();
            serviceCollection.AddServicesEmailAndActivityTimeout();
            serviceCollection.AddServicesChangeDatatProtectionTokenLifespans();
            ServiceCollection = serviceCollection;
            return serviceCollection;
        }

        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T? Resolve<T>() where T : class => ServiceCollection?.BuildServiceProvider().GetRequiredService<T>();
    }
}
