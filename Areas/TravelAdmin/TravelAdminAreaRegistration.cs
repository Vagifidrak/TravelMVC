using System.Web.Mvc;

namespace Travel_MVC.Areas.TravelAdmin
{
    public class TravelAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TravelAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TravelAdmin_default",
                "TravelAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },

                new string[] { "Travel_MVC.Areas.TravelAdmin.Controllers" }
            );
        }
    }
}