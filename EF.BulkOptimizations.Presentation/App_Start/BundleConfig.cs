using EF.BulkOptimizations.Presentation.Core.Bundles;
using System.Web;
using System.Web.Optimization;

namespace EF.BulkOptimizations.Presentation
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css")
                .Include("~/content/bootstrap.css")
                .Include("~/Content/font-awesome.css")
                .Include("~/fonts/Simple-Line-Icons-Webfont/simple-line-icons.css")
                .Include("~/client-side/css/import.css"));
            
            
            bundles.Add(new StyleImagePathBundle("~/bundles/scripts")
                .Include("~/Scripts/jquery-2.1.3.js")
                .Include("~/Scripts/modernizr-2.8.3.js")
                .Include("~/Scripts/angular.js")
                .Include("~/Scripts/angular-route.js")
                .Include("~/Scripts/angular-file-upload-all.js")
                .Include("~/client-side/js/app.js")
                .IncludeDirectory("~/client-side/js/services", "*.js")
                .IncludeDirectory("~/client-side/js/controllers", "*.js"));
        }
    }
}
