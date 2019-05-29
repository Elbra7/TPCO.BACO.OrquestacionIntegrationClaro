using System.Web.Http;
using Teleperformance.Helpers.Logger;

namespace TPCO.BACO.OrquestacionIntegration
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static volatile DataMemorySingleton dataMemorySingleton;
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            dataMemorySingleton = DataMemorySingleton.DataMemory;
            LoggerManager.SetLogger("LogToFile");
            LoggerManager.Logger.WriteMessage(LogLevel.Info, LogTags.TRACE, "Inicio de la Aplicación");
        }
    }
}
