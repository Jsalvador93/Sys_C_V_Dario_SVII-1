using System.Web;
using System.Web.Mvc;

namespace Sys_C_V_Dario_SVII
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
