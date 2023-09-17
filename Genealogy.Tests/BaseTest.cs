using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using velocist.Services.Core.Interfaces.SqlServer;
using Genealogy.Common;

namespace Genealogy.Tests {
    public class BaseConfigureTest {
        /// <summary>
        /// Gets or sets the unit of work.
        /// </summary>
        /// <value>
        /// The unit of work.
        /// </value>
        protected IUnitOfWorkSqlServer<AppEntitiesContext> UnitOfWork { get; set; }

        /// <summary>
        /// The logger
        /// </summary>
        protected static ILogger<BaseConfigureTest> _logger { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryTests"/> class.
        /// </summary>
        public BaseConfigureTest() {
            var host = Host.CreateDefaultBuilder(Array.Empty<string>());
            _ = host.ConfigureAppConfiguration((hostingContext, config) => Common.AccessServiceConfiguration.GetConfiguration())
                .ConfigureLogging(logging => LogServiceContainer.GetConfiguration())
                .ConfigureServices((context, services) => {
                    _ = services.ConfigureAppDatabaseServices();
                    _ = services.ConfigureAppUnitOfWork();
                    _ = services.ConfigureAppServices();

                    UnitOfWork = services.BuildServiceProvider().GetRequiredService<IUnitOfWorkSqlServer<AppEntitiesContext>>();
                }).Build();
            _logger = LogServiceContainer.GetLog<BaseConfigureTest>();
        }

        public void LogResults<T>(IEnumerable<T> list) where T : class {
            foreach (var item in list) {
                var stringItem = JsonAppHelper<T>.GetString(item);
                _logger.LogInformation(stringItem);
            }
        }

        public void LogResults<T>(T item) where T : class {
            var stringItem = JsonAppHelper<T>.GetString(item);
            _logger.LogDebug(stringItem);
        }
    }
    public class BaseServiceTest<TModel, TService> : BaseConfigureTest {

        public TService service;
        public TModel model;

    }
}
