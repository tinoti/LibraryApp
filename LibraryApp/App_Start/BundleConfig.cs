﻿using System.Web;
using System.Web.Optimization;

namespace LibraryApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.js",
                      "~/Scripts/typeahead.bundle.js",
                      "~/Scripts/DataTables/jquery.dataTables.js",
                      "~/Scripts/DataTables/dataTables.bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-lumen.css",
                      "~/Content/site.css",
                      "~/Content/typeahead.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.css",
                      "~/Content/toastr.css"));

            bundles.Add(new ScriptBundle("~/bundles/book").Include(
                "~/Scripts/App/Book.js",
                "~/Scripts/toastr.js"));

            bundles.Add(new ScriptBundle("~/bundles/reservation").Include(
                "~/Scripts/App/Reservation.js",
                 "~/Scripts/toastr.js"));


            bundles.Add(new ScriptBundle("~/bundles/employeeBook").Include(
                "~/Scripts/App/EmployeeBook.js",
                 "~/Scripts/toastr.js"));

            bundles.Add(new ScriptBundle("~/bundles/employeeReservation").Include(
                "~/Scripts/App/EmployeeReservation.js",
                 "~/Scripts/toastr.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminEmployee").Include(
                "~/Scripts/App/AdminEmployee.js",
                 "~/Scripts/toastr.js"));

            bundles.Add(new ScriptBundle("~/bundles/status").Include(
                "~/Scripts/App/Status.js",
                 "~/Scripts/toastr.js"));
        }
    }
}
