﻿using System.Web.Optimization;



namespace aLevel
{
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles( BundleCollection bundles )
		{
			bundles.Add( new ScriptBundle( "~/bundles/jquery" ).Include(
			                                                            "~/Scripts/jquery-{version}.js" ) );


			bundles.Add( new ScriptBundle( "~/bundles/tablesorter" ).Include(
			                                                                 "~/Scripts/tablesorter/jquery.tablesorter.combined.js" ) );

		    bundles.Add(new ScriptBundle("~/bundles/d3").Include(
                                                                 "~/Scripts/d3/d3.min.js"));

            bundles.Add( new ScriptBundle( "~/bundles/jqueryval" ).Include(
			                                                               "~/Scripts/jquery.validate*" ) );

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
			bundles.Add( new ScriptBundle( "~/bundles/modernizr" ).Include(
			                                                               "~/Scripts/modernizr-*" ) );

			bundles.Add( new ScriptBundle( "~/bundles/bootstrap" ).Include(
			                                                               "~/Scripts/bootstrap.js",
			                                                               "~/Scripts/respond.js" ) );

			bundles.Add( new StyleBundle( "~/Content/css" ).Include(
			                                                        "~/Content/bootstrap.css",
			                                                        "~/Content/site.css",
																	"~/Content/tablesorter/theme.default.min.css",
                                                                    "~/Content/StyleSheetMain.css",
			                                                        "~/Content/StyleSheetResults.css") );

		}
	}
}
