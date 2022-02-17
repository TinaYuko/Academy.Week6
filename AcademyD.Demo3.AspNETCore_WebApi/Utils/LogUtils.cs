using Serilog;
using System;
using System.IO;
using System.Reflection;

namespace AcademyD.Demo3.AspNETCore_WebApi.Utils
{
    public static class LogUtils
    {
        private static ILogger _logger;

        private static ILogger GetLogger()
        {
            if(_logger == null)
            {
                //TODO init logger
                string appName = Assembly.GetEntryAssembly().GetName().Name;
                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", appName);

                _logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.File(
                    filePath, 
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}",// formattazione del messaggio d'errore
                    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Verbose,
                    retainedFileCountLimit: 100,
                    fileSizeLimitBytes: 1024 * 1024 * 1000)
                    .CreateLogger();

                _logger.Information("Logger Started");
            }
            return _logger;
        }

        public static void Error(string message)
        {
            // invia mail al dipendente
            // scrivi su un db ad hoc per errori

            GetLogger().Error(message);
        }
    }
}
