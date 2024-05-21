using log4net;
using log4net.Config;

namespace Core
{
    public class LogHelper
    {
        public static void InitializeLogger()
        {
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
        }

        public static ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(type);
        }
    }
}