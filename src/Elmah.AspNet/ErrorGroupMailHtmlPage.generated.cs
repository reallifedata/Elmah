﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Elmah
{
    
    #line 2 "..\..\ErrorGroupMailHtmlPage.cshtml"
    using System;
    
    #line default
    #line hidden
    
    #line 3 "..\..\ErrorGroupMailHtmlPage.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 4 "..\..\ErrorGroupMailHtmlPage.cshtml"
    using System.Collections.Specialized;
    
    #line default
    #line hidden
    
    #line 5 "..\..\ErrorGroupMailHtmlPage.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    using System.Text;
    
    #line 6 "..\..\ErrorGroupMailHtmlPage.cshtml"
    using Elmah;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class ErrorGroupMailHtmlPage : RazorTemplateBase
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");








            
            #line 8 "..\..\ErrorGroupMailHtmlPage.cshtml"
  
    // NB cast is not really required, but aids with intellisense!
    var errorGroup = (ErrorGroup) this.ErrorGroup;


            
            #line default
            #line hidden
WriteLiteral(@"<html>
    <head>
        <style type=""text/css"">
            body { font-family: verdana, arial, helvetic; font-size: x-small; }
            table.collection { border-collapse: collapse; border-spacing: 0; border: 1px solid black; width: 100% }
            table.collection tr { vertical-align: top; }
            table.collection th { text-align: left; border: 1px solid black; padding: 4px; font-weight: bold; }
            table.collection td { border: 1px solid black; padding: 4px; }
            td, th, pre { font-size: x-small; } 
            #errorDetail { padding: 1em; background-color: #FFFFCC; } 
            #errorMessage { font-size: medium; font-style: italic; color: maroon; }
            h1 { font-size: small; }
        </style>
    </head>
    <body>
        <p id=""errorMessage"">Errors and Frequencies</p>
            <table class=""collection"">
                <tr>
                    <th> Type / Message </th>
                    <th> Details </th>
                </tr>
");


            
            #line 33 "..\..\ErrorGroupMailHtmlPage.cshtml"
         foreach (var errorTypeAndMessage in errorGroup.Errors
            .GroupBy(x => x.Type.ToString() + ": " + x.Message)
            .OrderByDescending(x => x.Count()))
        {

            
            #line default
            #line hidden
WriteLiteral("            <tr>\r\n                <td> ");


            
            #line 38 "..\..\ErrorGroupMailHtmlPage.cshtml"
                Write(errorTypeAndMessage.Key);

            
            #line default
            #line hidden
WriteLiteral("\r\n");



WriteLiteral("<pre id=\"errorDetail\">");


            
            #line 42 "..\..\ErrorGroupMailHtmlPage.cshtml"
                               Write(errorTypeAndMessage.First().Detail);

            
            #line default
            #line hidden
WriteLiteral("</pre>\r\n                </td>\r\n                <td>\r\n                    <ul>\r\n  " +
"                      <li> <strong>Count</strong> ");


            
            #line 46 "..\..\ErrorGroupMailHtmlPage.cshtml"
                                               Write(errorTypeAndMessage.Count());

            
            #line default
            #line hidden
WriteLiteral(" </li>\r\n                        <li> <strong>Min-Time</strong> ");


            
            #line 47 "..\..\ErrorGroupMailHtmlPage.cshtml"
                                                  Write(errorTypeAndMessage.Min(x => x.Time));

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n                        <li> <strong>Max-Time</strong> ");


            
            #line 48 "..\..\ErrorGroupMailHtmlPage.cshtml"
                                                  Write(errorTypeAndMessage.Max(x => x.Time));

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n                    </ul>\r\n                </td>\r\n            </tr>    \r\n");


            
            #line 52 "..\..\ErrorGroupMailHtmlPage.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("            </table>\r\n");


            
            #line 54 "..\..\ErrorGroupMailHtmlPage.cshtml"
      
            var groupedServerVariables = new Dictionary<string, List<string>>();
            foreach (var error in errorGroup.Errors.OrderBy(x => x.Time))
            {
                for(var i = 0; i < error.ServerVariables.Count; i++)
                {
                    var key = error.ServerVariables.GetKey(i);
                    var value = error.ServerVariables[i];
                    if (!groupedServerVariables.ContainsKey(key))
                    {
                        groupedServerVariables.Add(key, new List<string>());
                    }
                    groupedServerVariables[key].Add(value);
                }
            }
        

            
            #line default
            #line hidden
WriteLiteral("            <div id=\"ServerVariables\">\r\n                <h1>Server Variables</h1>" +
"\r\n                <table class=\"collection\">\r\n                    <tr><th>Name</" +
"th>            \r\n                        <th>Value</th></tr>\r\n");


            
            #line 75 "..\..\ErrorGroupMailHtmlPage.cshtml"
                     foreach(var groupedServerVariable in groupedServerVariables)
             {

            
            #line default
            #line hidden
WriteLiteral("                 <tr><td>");


            
            #line 77 "..\..\ErrorGroupMailHtmlPage.cshtml"
                    Write(groupedServerVariable.Key);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                     <td>\r\n                         <table class=\"collecti" +
"on\">\r\n");


            
            #line 80 "..\..\ErrorGroupMailHtmlPage.cshtml"
                              foreach (var val in groupedServerVariable.Value.Distinct())
                             {

            
            #line default
            #line hidden
WriteLiteral("                                 <tr><td>");


            
            #line 82 "..\..\ErrorGroupMailHtmlPage.cshtml"
                                    Write(val);

            
            #line default
            #line hidden
WriteLiteral("</td></tr>\r\n");


            
            #line 83 "..\..\ErrorGroupMailHtmlPage.cshtml"
                             }

            
            #line default
            #line hidden
WriteLiteral("                         </table>\r\n                     </td></tr>\r\n");


            
            #line 86 "..\..\ErrorGroupMailHtmlPage.cshtml"
             }

            
            #line default
            #line hidden
WriteLiteral("                </table>\r\n            </div>\r\n        <p>");


            
            #line 89 "..\..\ErrorGroupMailHtmlPage.cshtml"
       Write(RenderPartial<PoweredBy>());

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n    </body>\r\n</html>\r\n");


        }
    }
}
#pragma warning restore 1591