using System.Web;
using System.Web.Mvc;

namespace Kiemtra_TranDuyPhat
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
