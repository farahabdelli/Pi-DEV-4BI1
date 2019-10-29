using System.Web;
using System.Web.Optimization;

namespace projetPIWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            #region TemplateBack Design
            bundles.Add(new ScriptBundle("~/template/Backend/css").Include(
                        "~/Content/Backend/css/all.min.css",
                        "~/Content/Backend/css/font-awesome.css",
                           "~/Content/Backend/css/all.css",
                         "~/Content/Backend/css/sb-admin-2.min.css"));


            bundles.Add(new ScriptBundle("~/template/Backend/js").Include(
                        "~/Scripts/jquery.min.js",
                        "~/Scripts/bootstrap.bundle.min.js",
                        "~/Scripts/jquery.easing.min.js",
                        "~/Scripts/jquery.fontawesome.min.js",
                        "~/Scripts/jquery.fontawesome.js",
                        "~/Scripts/jquery.all.mon.js",
                        "~/Scripts/sb-admin-2.min.js"));


            #endregion

            #region TemplateFront Design
            bundles.Add(new ScriptBundle("~/template/Frontend/css").Include(
                        "~/Content/Frontend/css/bootstrap.min.css",
                        "~/Content/Frontend/css/all.css",
                         "~/Content/Frontend/css/font-awesome.min.css",
                         "~/Content/Frontend/css/font-awesome.css",
                         "~/Content/Frontend/css/material-design-iconic-font.min.css",
                         "~/Content/Frontend/css/icon-font.min.css",
                         "~/Content/Frontend/css/animate.css",
                         "~/Content/Frontend/css/hamburgers.min.css",
                         "~/Content/Frontend/css/animsition.min.css",
                         "~/Content/Frontend/css/select2.min.css",
                         "~/Content/Frontend/css/daterangepicker.css",
                         "~/Content/Frontend/css/slick.css",
                         "~/Content/Frontend/css/magnific-popup.css",
                          "~/Content/Frontend/css/perfect-scrollbar.css",
                          "~/Content/Frontend/css/util.css",
                           "~/Content/Frontend/css/main.css"
                         ));


            bundles.Add(new ScriptBundle("~/template/Frontend/js").Include(
                        "~/Scripts/jquery-3.2.1.min.js",
                         "~/Scripts/animsition.min.js",
                          "~/Scripts/popper.js",
                           "~/Scripts/select2.min.js",
                            "~/Scripts/moment.min.js",
                             "~/Scripts/daterangepicker.js",
                              "~/Scripts/slick.min.js",
                               "~/Scripts/slick-custom.js",
                                "~/Scripts/parallax100.js",
                                 "~/Scripts/jquery.magnific-popup.min.js",
                                 "~/Scripts/isotope.pkgd.min.js",
                                 "~/Scripts/sweetalert.min.js",
                                 "~/Scripts/perfect-scrollbar.min.js",
                                 "~/Scripts/main.js",
                        "~/Scripts/demo/bootstrap.min.js"));
                             #endregion
        }
    }
}
