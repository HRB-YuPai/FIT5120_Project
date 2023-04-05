using System.Web;
using System.Web.Mvc;

namespace FIT5120_Quality_Education_in_Australia_Iteration_01
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
