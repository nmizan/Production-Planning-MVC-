using System.Web;
using System.Web.Optimization;

namespace Production_Planner
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
           
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.2.3.js",
                          "~/Scripts/fullcalendar.min.js",
                           "~/Scripts/moment.js",
                          "~/Scripts/scheduler.min.js",
                          "~/Scripts/tooltipster.bundle.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
        "~/Scripts/jquery-ui-1.12.1.js"));
          
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
          
            //css  
          

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/fullcalendar.css",
                      "~/Content/scheduler.min.css",
                      "~/Content/fullcalendar.print.css"));

            bundles.Add(new StyleBundle("~/Content/cssjqryUi").Include(
                 "~/Content/jquery-ui.css"));  

            bundles.Add(new ScriptBundle("~/bundles/angularJS").Include(
                     "~/Scripts/angular.js"));
        }
    }
}
