using System.Web;
using System.Web.Mvc;

namespace Fst_QRCode_eCheckIn
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
