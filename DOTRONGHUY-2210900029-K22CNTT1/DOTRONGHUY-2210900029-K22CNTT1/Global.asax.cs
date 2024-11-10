using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Hosting;

namespace DOTRONGHUY_2210900029_K22CNTT1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            string imagesPath = HostingEnvironment.MapPath("~/image"); // Đường dẫn tới thư mục ngoài
            if (Directory.Exists(imagesPath))
            {
                FileSystemWatcher fileWatcher = new FileSystemWatcher(imagesPath)
                {
                    EnableRaisingEvents = true
                };
            }
        }
    }
}
