#pragma checksum "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\Pages\ChangePassword.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a8c0e92a7aafba59f960c702aa4b5ebc4b7c9b5"
// <auto-generated/>
#pragma warning disable 1591
namespace Blackmail.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\_Imports.razor"
using Blackmail.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\_Imports.razor"
using Blackmail.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\Pages\ChangePassword.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\Pages\ChangePassword.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\Pages\ChangePassword.razor"
using Blackmail.Models.Blackmailazure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\Pages\ChangePassword.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\Pages\ChangePassword.razor"
using Blackmail.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\Pages\ChangePassword.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\Pages\ChangePassword.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/change-password")]
    public partial class ChangePassword : Blackmail.Pages.ChangePasswordComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Radzen.Blazor.RadzenContent>(0);
            __builder.AddAttribute(1, "Container", "main");
            __builder.AddAttribute(2, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(3, "\n    ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenHeading>(4);
                __builder2.AddAttribute(5, "Size", "H1");
                __builder2.AddAttribute(6, "Text", "Profile");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(7, "\n    ");
                __builder2.OpenElement(8, "div");
                __builder2.AddAttribute(9, "class", "row");
                __builder2.AddMarkupContent(10, "\n      ");
                __builder2.OpenElement(11, "div");
                __builder2.AddAttribute(12, "class", "col-md-12");
                __builder2.AddMarkupContent(13, "\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenTemplateForm<ApplicationUser>>(14);
                __builder2.AddAttribute(15, "Method", "post");
                __builder2.AddAttribute(16, "Action", "account/changepassword");
                __builder2.AddAttribute(17, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<ApplicationUser>(
#nullable restore
#line 20 "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\Pages\ChangePassword.razor"
                                                                                                          user

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(18, "Visible", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 20 "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\Pages\ChangePassword.razor"
                                                                                                                            user != null

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(19, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder3) => {
                    __builder3.AddMarkupContent(20, "\n            ");
                    __builder3.OpenElement(21, "div");
                    __builder3.AddAttribute(22, "style", "margin-bottom: 1rem");
                    __builder3.AddAttribute(23, "class", "row");
                    __builder3.AddMarkupContent(24, "\n              ");
                    __builder3.OpenElement(25, "div");
                    __builder3.AddAttribute(26, "class", "col-md-3");
                    __builder3.AddMarkupContent(27, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenLabel>(28);
                    __builder3.AddAttribute(29, "Component", "OldPassword");
                    __builder3.AddAttribute(30, "style", "width: 100%");
                    __builder3.AddAttribute(31, "Text", "Old Password");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(32, "\n              ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(33, "\n              ");
                    __builder3.OpenElement(34, "div");
                    __builder3.AddAttribute(35, "class", "col-md-9");
                    __builder3.AddMarkupContent(36, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenPassword>(37);
                    __builder3.AddAttribute(38, "style", "display: block; width: 100%");
                    __builder3.AddAttribute(39, "Name", "OldPassword");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(40, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenRequiredValidator>(41);
                    __builder3.AddAttribute(42, "Component", "OldPassword");
                    __builder3.AddAttribute(43, "style", "position: absolute");
                    __builder3.AddAttribute(44, "Text", "Password is required");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(45, "\n              ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(46, "\n            ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(47, "\n            ");
                    __builder3.OpenElement(48, "div");
                    __builder3.AddAttribute(49, "style", "margin-bottom: 1rem");
                    __builder3.AddAttribute(50, "class", "row");
                    __builder3.AddMarkupContent(51, "\n              ");
                    __builder3.OpenElement(52, "div");
                    __builder3.AddAttribute(53, "class", "col-md-3");
                    __builder3.AddMarkupContent(54, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenLabel>(55);
                    __builder3.AddAttribute(56, "Component", "NewPassword");
                    __builder3.AddAttribute(57, "style", "width: 100%");
                    __builder3.AddAttribute(58, "Text", "New Password");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(59, "\n              ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(60, "\n              ");
                    __builder3.OpenElement(61, "div");
                    __builder3.AddAttribute(62, "class", "col-md-9");
                    __builder3.AddMarkupContent(63, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenPassword>(64);
                    __builder3.AddAttribute(65, "style", "display: block; width: 100%");
                    __builder3.AddAttribute(66, "Name", "NewPassword");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(67, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenRequiredValidator>(68);
                    __builder3.AddAttribute(69, "Component", "NewPassword");
                    __builder3.AddAttribute(70, "style", "position: absolute");
                    __builder3.AddAttribute(71, "Text", "Password is required");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(72, "\n              ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(73, "\n            ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(74, "\n            ");
                    __builder3.OpenElement(75, "div");
                    __builder3.AddAttribute(76, "style", "margin-bottom: 1rem");
                    __builder3.AddAttribute(77, "class", "row");
                    __builder3.AddMarkupContent(78, "\n              ");
                    __builder3.OpenElement(79, "div");
                    __builder3.AddAttribute(80, "class", "col-md-3");
                    __builder3.AddMarkupContent(81, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenLabel>(82);
                    __builder3.AddAttribute(83, "Component", "ConfirmPassword");
                    __builder3.AddAttribute(84, "style", "width: 100%");
                    __builder3.AddAttribute(85, "Text", "Confirm password");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(86, "\n              ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(87, "\n              ");
                    __builder3.OpenElement(88, "div");
                    __builder3.AddAttribute(89, "class", "col-md-9");
                    __builder3.AddMarkupContent(90, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenPassword>(91);
                    __builder3.AddAttribute(92, "style", "display: block; width: 100%");
                    __builder3.AddAttribute(93, "Name", "ConfirmPassword");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(94, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenRequiredValidator>(95);
                    __builder3.AddAttribute(96, "Component", "ConfirmPassword");
                    __builder3.AddAttribute(97, "style", "position: absolute");
                    __builder3.AddAttribute(98, "Text", "ConfirmPassword is required");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(99, "\n              ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(100, "\n            ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(101, "\n            ");
                    __builder3.OpenElement(102, "div");
                    __builder3.AddAttribute(103, "class", "row");
                    __builder3.AddMarkupContent(104, "\n              ");
                    __builder3.OpenElement(105, "div");
                    __builder3.AddAttribute(106, "class", "col offset-sm-3");
                    __builder3.AddMarkupContent(107, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenButton>(108);
                    __builder3.AddAttribute(109, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 60 "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\Pages\ChangePassword.razor"
                                           ButtonStyle.Primary

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(110, "ButtonType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonType>(
#nullable restore
#line 60 "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\Pages\ChangePassword.razor"
                                                                            ButtonType.Submit

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(111, "Icon", "save");
                    __builder3.AddAttribute(112, "Text", "Change password");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(113, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenButton>(114);
                    __builder3.AddAttribute(115, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 62 "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\Pages\ChangePassword.razor"
                                           ButtonStyle.Light

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(116, "Text", "Cancel");
                    __builder3.AddAttribute(117, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 62 "C:\Users\jenni\Documents\FrontEndWeb\Blackmail_FrontEnd\client\Pages\ChangePassword.razor"
                                                                                    Button2Click

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(118, "\n              ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(119, "\n            ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(120, "\n          ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(121, "\n      ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(122, "\n    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(123, "\n  ");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
