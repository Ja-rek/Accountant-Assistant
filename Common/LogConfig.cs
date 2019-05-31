using NLog;
using NLog.Config;
using NLog.Targets;

namespace Common
{
    public static class LogConfig
    {
        public static LoggingConfiguration Config()
        {
            var config = new LoggingConfiguration();

            var logfile = new FileTarget("logfile") { FileName = "log.txt" };
            var console = new ColoredConsoleTarget()
            {
                Layout = "${date:format=HH\\:mm\\:ss} ${level}: \n ${message} ${exception}\n"
            };


            config.AddRule(LogLevel.Trace, LogLevel.Fatal, logfile);
            config.AddRule(LogLevel.Trace, LogLevel.Fatal, console);
                        
            return config;
        }
    }
}
