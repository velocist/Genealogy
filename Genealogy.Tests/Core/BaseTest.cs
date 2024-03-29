using System.Reflection;
using Genealogy.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using velocist.Services.Core.Interfaces.SqlServer;

namespace Genealogy.Tests.Core {

    /// <summary>
    /// Bases class for configure tests.
    /// </summary>
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
        /// Initializes a new instance of the <see cref="BaseConfigureTest"/> class.
        /// </summary>
        public BaseConfigureTest() {
            var host = Host.CreateDefaultBuilder(Array.Empty<string>());
            _ = host.ConfigureAppConfiguration((hostingContext, config) => AccessServiceConfiguration.GetConfiguration())
                .ConfigureLogging(logging => {
                    //LogServiceContainer.GetConfiguration();
                    logging.ClearProviders();
                    logging.AddLog4Net(AccessServiceConfiguration.LogSettingsFile, true);
#if DEBUG
                    logging.SetMinimumLevel(LogLevel.Trace);
#else
                    logging.SetMinimumLevel(LogLevel.Error);
#endif
                }
                ).ConfigureServices((context, services) => {
                    _ = services.ConfigureAppDatabaseServices();
                    _ = services.ConfigureAppUnitOfWork();
                    _ = services.ConfigureAppServices();

                    var builder = services.BuildServiceProvider();
                    InitializeLog(builder.GetRequiredService<ILoggerFactory>());

                    UnitOfWork = builder.GetRequiredService<IUnitOfWorkSqlServer<AppEntitiesContext>>();
                }).Build();
            //_logger = LogServiceContainer.GetLog<BaseConfigureTest>();
            _logger = (ILogger<BaseConfigureTest>)GetStaticLogger<BaseConfigureTest>();

        }

        /// <summary>
        /// Logs the results.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        public void LogResults<T>(IEnumerable<T> list) where T : class {
            foreach (var item in list) {
                var stringItem = JsonAppHelper<T>.GetString(item);
                //_logger.LogInformation(stringItem);
            }
        }

        /// <summary>
        /// Logs the results.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        public void LogResults<T>(T item) where T : class {
            var stringItem = JsonAppHelper<T>.GetString(item);
            //_logger.LogInformation(stringItem);
        }

        /// <summary>
        /// Logs the results.
        /// </summary>
        /// <param name="item">The item.</param>
        public void LogResults(object item) {
            var stringItem = JsonAppHelper<object>.GetString(item);
            //_logger.LogInformation(stringItem);
        }

        /// <summary>
        /// Logs the results.
        /// </summary>
        /// <param name="list">The list.</param>
        public void LogResults(Dictionary<string, Type> list) {
            foreach (var item in list) {
                _logger.LogInformation($"Key: {item.Key} Value: {item.Value}");
            }
        }

        /// <summary>
        /// Logs the results.
        /// </summary>
        /// <param name="list">The list.</param>
        public void LogResults(PropertyInfo[] list) {
            foreach (var item in list) {
                _logger.LogInformation($"Name: {item.Name} PropertyType: {item.PropertyType}");
            }
        }

        /// <summary>
        /// Logs the results.
        /// </summary>
        /// <param name="list">The list.</param>
        public void LogResults(Dictionary<string, object> list) {
            var stringItem = JsonAppHelper<Dictionary<string, object>>.GetString(list);
            //foreach (var item in list) {
            //    _logger.LogInformation($"Key: {item.Key} Value: {item.Value}");
            //}
        }

    }

    public class BaseServiceTest<TModel, TService> : BaseConfigureTest {

        public TService _service;
        public TModel _model;

    }

    public class ServiceTest<TModel, TEntity, TService>
        where TService : IBaseService<TModel, TEntity, AppEntitiesContext> {

        /// <summary>
        /// Gets or sets the unit of work.
        /// </summary>
        /// <value>
        /// The unit of work.
        /// </value>
        protected IUnitOfWorkSqlServer<AppEntitiesContext> _unitOfWork { get; set; }

        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        /// <value>
        /// The service.
        /// </value>
        protected TService _service { get; set; }

        /// <summary>
        /// The model
        /// </summary>
        protected TModel _model { get; set; }

        /// <summary>
        /// The list
        /// </summary>
        protected List<TModel> _list { get; set; }

        /// <summary>
        /// The logger
        /// </summary>
        protected static ILogger<ServiceTest<TModel, TEntity, TService>> _logger { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceTest{TModel,TEntity,TService}"/> class.
        /// </summary>
        public ServiceTest() {
            var host = Host.CreateDefaultBuilder(Array.Empty<string>());
            _ = host.ConfigureAppConfiguration((hostingContext, config) => AccessServiceConfiguration.GetConfiguration())
                .ConfigureLogging(logging => {
                    //LogServiceContainer.GetConfiguration();
                    logging.ClearProviders();
                    logging.AddLog4Net(AccessServiceConfiguration.LogSettingsFile, true);
#if DEBUG
                    //logging.SetMinimumLevel(LogLevel.Trace);
#else
                    logging.SetMinimumLevel(LogLevel.Error);
#endif
                }).ConfigureServices((context, services) => {
                    _ = services.ConfigureAppDatabaseServices();
                    _ = services.ConfigureAppUnitOfWork();
                    _ = services.ConfigureAppServices();

                    var builder = services.BuildServiceProvider();
                    InitializeLog(builder.GetRequiredService<ILoggerFactory>());

                    //_unitOfWork = services.BuildServiceProvider().GetRequiredService<IUnitOfWorkSqlServer<AppEntitiesContext>>();
                    _unitOfWork = (IUnitOfWorkSqlServer<AppEntitiesContext>)builder.GetRequiredService(typeof(IUnitOfWorkSqlServer<AppEntitiesContext>));
                    _service = (TService)builder.GetRequiredService(typeof(TService));
                }).Build();
            //_logger = LogServiceContainer.GetLog<ServiceTest<TModel, TEntity, TService>>();
            _logger = (ILogger<ServiceTest<TModel, TEntity, TService>>)GetStaticLogger<ServiceTest<TModel, TEntity, TService>>();

            //_service = Activator.CreateInstance<TService>();
        }

        /// <summary>
        /// Logs the results.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        public void LogResults<T>(IEnumerable<T> list) where T : class {
            foreach (var item in list) {
                var stringItem = JsonAppHelper<T>.GetString(item);
                _logger.LogInformation(stringItem);
            }
        }

        /// <summary>
        /// Logs the results.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        public void LogResults<T>(T item) where T : class {
            var stringItem = JsonAppHelper<T>.GetString(item);
            _logger.LogInformation(stringItem);
        }

        /// <summary>
        /// Logs the results.
        /// </summary>
        /// <param name="item">The item.</param>
        public void LogResults(object item) {
            var stringItem = JsonAppHelper<object>.GetString(item);
            _logger.LogInformation(stringItem);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetData {

        public static FSImageModel GetFSImageModel(string text) {
            var numberTest = DateTime.Now.Ticks;
            text = text + "_" + numberTest;
            return new() {
                Citation = $"Citation {text}",
                NumberImage = "1",
                FSFilm = new() {
                    FilmDigitalNote = $"Digital note {text}",
                    ImageGroupNumber = 1,
                    Citation = $"Citation {text}",
                    FSCatalogId = 1,
                    FSCatalog = new() {
                        Name = $"Start model {text}",
                        Number = 1,
                        Author = $"Author {text}",
                        Format = $"Formato {text}",
                        Note = $"Notas {text}",
                        Publication = $"Publicador {text}",
                        Url = $"Url {text} test",
                        Observaciones = $"Start model {text}",
                        AddDate = DateTime.Now,
                        LastChange = DateTime.Now,
                        //ExportModel = new ExportModel() {
                        //    FileName = "Catalogs" + text,
                        //    PathFile = @"C:\Logs\"
                        //},
                    },
                    Note = $"Notes {text}",
                    Url = $"Url {text}",
                    Observaciones = $"New {text}",
                    AddDate = DateTime.Now,
                    LastChange = DateTime.Now,
                    //ExportModel = new ExportModel() {
                    //    FileName = "Films" + text,
                    //    PathFile = @"C:\Logs\"
                    //},
                },
                Url = $"Url {text}",
                Observaciones = $"New {text}",
                AddDate = DateTime.Now,
                LastChange = DateTime.Now,
                //ExportModel = new ExportModel() {
                //    FileName = "Images" + text,
                //    PathFile = @"C:\Logs\"
                //},
            };
        }

        /// <summary>
        /// Gets the fs record model.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static FSRecordModel GetFSRecordModel(string text) {
            var numberTest = DateTime.Now.Ticks;
            text = text + "_" + numberTest;
            return new() {
                Citation = $"Citation {text}",
                NumberRecord = "1",
                FSFilm = new() {
                    FilmDigitalNote = $"Digital note {text}",
                    ImageGroupNumber = 1,
                    Citation = $"Citation {text}",
                    FSCatalogId = 1,
                    FSCatalog = new() {
                        Name = $"Start model {text}",
                        Number = 1,
                        Author = $"Author {text}",
                        Format = $"Formato {text}",
                        Note = $"Notas {text}",
                        Publication = $"Publicador {text}",
                        Url = $"Url {text} test",
                        Observaciones = $"Start model {text}",
                        AddDate = DateTime.Now,
                        LastChange = DateTime.Now,
                        //ExportModel = new ExportModel() {
                        //    FileName = "Catalogs" + text,
                        //    PathFile = @"C:\Logs\"
                        //},
                    },
                    Note = $"Notes {text}",
                    Url = $"Url {text}",
                    Observaciones = $"New {text}",
                    AddDate = DateTime.Now,
                    LastChange = DateTime.Now,
                    //ExportModel = new ExportModel() {
                    //    FileName = "Films" + text,
                    //    PathFile = @"C:\Logs\"
                    //},
                },
                Url = $"Url {text}",
                Observaciones = $"New {text}",
                AddDate = DateTime.Now,
                LastChange = DateTime.Now,
                //ExportModel = new ExportModel() {
                //    FileName = "Images" + text,
                //    PathFile = @"C:\Logs\"
                //},
            };
        }

        /// <summary>
        /// Gets the investigacion model.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static InvestigacionModel GetInvestigacionModel(string text) {
            var numberTest = DateTime.Now.Ticks;
            text = text + "_" + numberTest;
            return new() {
                //Citation = $"Citation {text}",
                //NumberRecord = "1",
                //FSFilm = new() {
                //    FilmDigitalNote = $"Digital note {text}",
                //    ImageGroupNumber = 1,
                //    Citation = $"Citation {text}",
                //    FSCatalogId = 1,
                //    FSCatalog = new() {
                //        Name = $"Start model {text}",
                //        Number = 1,
                //        Author = $"Author {text}",
                //        Format = $"Formato {text}",
                //        Note = $"Notas {text}",
                //        Publication = $"Publicador {text}",
                //        Url = $"Url {text} test",
                //        Observaciones = $"Start model {text}",
                //        AddDate = DateTime.Now,
                //        LastChange = DateTime.Now,
                //        ExportModel = new ExportModel() {
                //            FileName = "Catalogs" + text,
                //            PathFile = @"C:\Logs\"
                //        },
                //    },
                //    Note = $"Notes {text}",
                //    Url = $"Url {text}",
                //    Observaciones = $"New {text}",
                //    AddDate = DateTime.Now,
                //    LastChange = DateTime.Now,
                //    ExportModel = new ExportModel() {
                //        FileName = "Films" + text,
                //        PathFile = @"C:\Logs\"
                //    },
                //},
                Url = $"Url {text}",
                Observaciones = $"New {text}",
                AddDate = DateTime.Now,
                LastChange = DateTime.Now,
                //ExportModel = new ExportModel() {
                //    FileName = "Images" + text,
                //    PathFile = @"C:\Logs\"
                //},
            };
        }
    }
}
