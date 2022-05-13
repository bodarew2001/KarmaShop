using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace TW.App_Start
{
     public class BundleConfig
     {
          public static void RegisterBundles(BundleCollection bundles)
          {
               bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                    "~/Vendors/Styles/bootstrap.css", new CssRewriteUrlTransform()));

               bundles.Add(new ScriptBundle("~/bundles/boostrap/js").Include(
                    "~/Vendors/Scripts/bootsrap.min.js"));

               bundles.Add(new StyleBundle("~/bundles/font-awesome/css").Include(
                    "~/Vendors/Styles/font-awesome.min.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/linearicons/css").Include(
                    "~/Vendors/Styles/linearicons.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/themify-icons/css").Include(
                    "~/Vendors/Styles/themify-icons.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/owl.carousel/css").Include(
                    "~/Vendors/Styles/owl.carousel.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/nice-select/css").Include(
                    "~/Vendors/Styles/nice-select.css", new CssRewriteUrlTransform()));
               
               bundles.Add(new StyleBundle("~/bundles/nouislidert/css").Include(
                    "~/Vendors/Styles/nouislider.min.css", new CssRewriteUrlTransform()));
               
               bundles.Add(new StyleBundle("~/bundles/ion.rangeSlider/css").Include(
                    "~/Vendors/Styles/ion.rangeSlider.css", new CssRewriteUrlTransform()));
               
               bundles.Add(new StyleBundle("~/bundles/ion.rangeSlider.skinFlat/css").Include(
                    "~/Vendors/Styles/ion.rangeSlider.skinFlat.css", new CssRewriteUrlTransform()));
               
               bundles.Add(new StyleBundle("~/bundles/magnific-popup/css").Include(
                    "~/Vendors/Styles/magnific-popup.css", new CssRewriteUrlTransform()));
               
               bundles.Add(new StyleBundle("~/bundles/main/css").Include(
                    "~/Vendors/Styles/main.css", new CssRewriteUrlTransform()));

               bundles.Add(new ScriptBundle("~/bundles/jquery-2.2.4/js").Include(
                    "~/Vendors/Scripts/jquery-2.2.4.min.js", new CssRewriteUrlTransform()));

               bundles.Add(new ScriptBundle("~/bundles/popper/js").Include(
                    "~/Vendors/Scripts/popper.min.js", new CssRewriteUrlTransform()));

               bundles.Add(new ScriptBundle("~/bundles/jquery.ajaxchimp/js").Include(
                    "~/Vendors/Scripts/jquery.ajaxchimp.min.js", new CssRewriteUrlTransform()));

               bundles.Add(new ScriptBundle("~/bundles/jquery.nice-select/js").Include(
                    "~/Vendors/Scripts/jquery.nice-select.min.js", new CssRewriteUrlTransform()));

               bundles.Add(new ScriptBundle("~/bundles/jquery.sticky/js").Include(
                    "~/Vendors/Scripts/jquery.sticky.js", new CssRewriteUrlTransform()));

               bundles.Add(new ScriptBundle("~/bundles/nouislider/js").Include(
                    "~/Vendors/Scripts/nouislider.min.js", new CssRewriteUrlTransform()));

               bundles.Add(new ScriptBundle("~/bundles/countdown/js").Include(
                    "~/Vendors/Scripts/countdown.js", new CssRewriteUrlTransform()));

               bundles.Add(new ScriptBundle("~/bundles/jquery.magnific-popup/js").Include(
                    "~/Vendors/Scripts/jquery.magnific-popup.min.js", new CssRewriteUrlTransform()));

               bundles.Add(new ScriptBundle("~/bundles/owl.carousel.min/js").Include(
                    "~/Vendors/Scripts/owl.carousel.min.js", new CssRewriteUrlTransform()));

               bundles.Add(new ScriptBundle("~/bundles/gmaps/js").Include(
                    "~/Vendors/Scripts/gmaps.min.js", new CssRewriteUrlTransform()));

               bundles.Add(new ScriptBundle("~/bundles/main/js").Include(
                    "~/Vendors/Scripts/main.js", new CssRewriteUrlTransform()));
          }
     } 
}