using System;
using Autumn.Annotation;
using log4net;

namespace Autumn.Logging.Log4Net
{
    [Configuration]
    public class Log4NetConfiguration
    {
        public class LogWrapper : Autumn.Interfaces.ILog
        {
            private readonly ILog log;
            
            public void Debug(object message) { log.Debug(message); }
            public void Debug(object message, Exception exception) { log.Debug(message, exception); }
            
            public void Info(object message) { log.Info(message); }
            public void Info(object message, Exception exception) { log.Info(message, exception); }
            
            public void Warn(object message) { log.Warn(message); }
            public void Warn(object message, Exception exception) { log.Warn(message, exception); }
            
            public void Error(object message) { log.Error(message); }
            public void Error(object message, Exception exception) { log.Error(message, exception); }
            

            public LogWrapper()
            {
                log = LogManager.GetLogger("LOGGER");
            }
            
            public LogWrapper(string name)
            {
                log = LogManager.GetLogger(name);
            }
        }

        [Bean(Singleton = false)]
        [Primary]
        public Interfaces.ILog getILog([Value("{context.target}")] object o, [Value("{logger.name:}")] string name = "")
        {            
            return new LogWrapper(string.IsNullOrEmpty(name) ? o.GetType().FullName : name);
        }


        [Bean]
        public Log4NetConfigure GetConfiguration()
        {
            return null;
        }

    }
}