//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP {
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;
using System.Web.UI;
using System.Web.WebPages;
using System.Web.WebPages.Html;

public class _Page_Details_cshtml : System.Web.WebPages.WebPage {
private static object @__o;
#line hidden
public _Page_Details_cshtml() {
}
protected System.Web.HttpApplication ApplicationInstance {
get {
return ((System.Web.HttpApplication)(Context.ApplicationInstance));
}
}
public override void Execute() {

#line 1 "C:\Users\ASUS\AppData\Local\Temp\0E98AC741E019D68503D515728FB28527F1C\4\QuanLyNhanSu\Views\ChucVus\Details.cshtml"
__o = model;


#line default
#line hidden

#line 2 "C:\Users\ASUS\AppData\Local\Temp\0E98AC741E019D68503D515728FB28527F1C\4\QuanLyNhanSu\Views\ChucVus\Details.cshtml"
  
    ViewBag.Title = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";


#line default
#line hidden

#line 3 "C:\Users\ASUS\AppData\Local\Temp\0E98AC741E019D68503D515728FB28527F1C\4\QuanLyNhanSu\Views\ChucVus\Details.cshtml"
          __o = Html.DisplayNameFor(model => model.IdCV);


#line default
#line hidden

#line 4 "C:\Users\ASUS\AppData\Local\Temp\0E98AC741E019D68503D515728FB28527F1C\4\QuanLyNhanSu\Views\ChucVus\Details.cshtml"
                                                               __o = Html.DisplayFor(model => model.IdCV);


#line default
#line hidden

#line 5 "C:\Users\ASUS\AppData\Local\Temp\0E98AC741E019D68503D515728FB28527F1C\4\QuanLyNhanSu\Views\ChucVus\Details.cshtml"
          __o = Html.DisplayNameFor(model => model.TenCV);


#line default
#line hidden

#line 6 "C:\Users\ASUS\AppData\Local\Temp\0E98AC741E019D68503D515728FB28527F1C\4\QuanLyNhanSu\Views\ChucVus\Details.cshtml"
                                                                __o = Html.DisplayFor(model => model.TenCV);


#line default
#line hidden

#line 7 "C:\Users\ASUS\AppData\Local\Temp\0E98AC741E019D68503D515728FB28527F1C\4\QuanLyNhanSu\Views\ChucVus\Details.cshtml"
            __o = Url.Action("Index", "ChucVus", new { id = Model.IdCV });


#line default
#line hidden

#line 8 "C:\Users\ASUS\AppData\Local\Temp\0E98AC741E019D68503D515728FB28527F1C\4\QuanLyNhanSu\Views\ChucVus\Details.cshtml"
            __o = Url.Action("Edit", "ChucVus", new { id = Model.IdCV });


#line default
#line hidden
}
}
}
