using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace QuoraApp.UI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap.js").Include(
                "~/Scripts/bootstrap.js,~/Scripts/jquery-{version}.js,~/Scripts/popper.js"));

            bundles.Add(new StyleBundle("~/Scripts/bootstrap.css").Include(
                "~/Content/bootstrap.css"));
        }
    }
}