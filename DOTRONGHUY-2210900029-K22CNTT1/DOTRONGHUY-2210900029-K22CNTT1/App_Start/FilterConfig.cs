using System.Web;
using System.Web.Mvc;

namespace DOTRONGHUY_2210900029_K22CNTT1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
