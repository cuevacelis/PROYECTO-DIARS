using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Maldonado
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //CSS
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Contents/css/style.css",//propio Estilo de Hotel la Posada del REy

                "~/Contents/css/bootstrap.min.css",
                "~/Contents/css/animate.css",
                "~/Contents/css/owl.carousel.min.css",
                "~/Contents/css/aos.css",
                "~/Contents/css/bootstrap-datepicker.css",
                "~/Contents/css/jquery.timepicker.css",
                "~/Contents/css/fancybox.min.css",
                "~/Contents/FontAwesomeIcon/css/all.css"
                ));
            bundles.Add(new StyleBundle("~/bundles/OdenarTablasCSS").Include(
                "~/Contents/css/style.css"
                ));

            //JS
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Contents/js/jquery-3.4.1.min.js",
                "~/Contents/js/jquery-migrate-3.0.1.min.js",
                "~/Contents/js/popper.min.js",
                "~/Contents/js/bootstrap.min.js",
                "~/Contents/js/owl.carousel.min.js",
                "~/Contents/js/jquery.stellar.min.js",
                "~/Contents/js/jquery.fancybox.min.js",
                "~/Contents/js/aos.js",
                "~/Contents/js/bootstrap-datepicker.js",
                "~/Contents/js/jquery.timepicker.min.js",
                "~/Contents/js/main.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/MyJson").Include(
                "~/Contents/js/jquery-3.4.1.min.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/OrdenarTablas").Include(
                "~/Contents/js/jquery-3.4.1.min.js",
                "~/Contents/js/SortTable.js"
                ));
        }
    }
}