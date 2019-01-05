using Autumn.Annotation;
using log4net.Config;

namespace Autumn.Logging.Log4Net
{
    [Configuration]
    public class Log4NetXmlConfiguration
    {

        [Autowired]
        public Log4NetXmlConfiguration(Log4NetConfigure configure)
        {
            if (configure != null)
                XmlConfigurator.Configure(configure.Configuration);
            XmlConfigurator.Configure();
        }
    }
}