using System.Web;
using System.Web.Optimization;

namespace LuigiiLuxury
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css", "~/Content/site.css"));


            // CLIENT
            // 1. scripts
            bundles.Add(new Bundle("~/bundles/scriptsbundle_client").Include(
                "~/Scripts/umd/popper.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/jquery-3.6.4.min.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/bootstrap.bundle.min.js",
                "~/Scripts/jquery.slim.min.js",
                "~/Scripts/custom/main.js"
                ));

            // 2. Style
            bundles.Add(new StyleBundle("~/bundles/stylesbundle_client").Include(
               "~/Content/bootstrap.css",
               "~/Content/font-awesome.min.css",
               "~/Content/Styles/_ClientLayout.css"
               ));


            // ADMIN
            // 1. scripts
            bundles.Add(new Bundle("~/bundles/scriptsbundle_admin").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/jquery-3.6.4.min.js",
                "~/Scripts/bootstrap.bundle.min.js",
                "~/Scripts/umd/popper.js",
                "~/Scripts/bootbox.js",
                "~/Scripts/datatables/jquery.dataTables.js",
                "~/Scripts/datatables/dataTables.bootstrap.js"
                ));

            // 2. Style
            bundles.Add(new StyleBundle("~/bundles/stylesbundle_admin").Include(
               "~/Content/bootstrap.css",
               "~/Content/font-awesome.min.css",
               "~/Content/Styles/_AdminLayout.css"
                ));

            BundleTable.EnableOptimizations = true;
        }
    }
}
