using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Blackmail.Models.BlackmailDb;
using Microsoft.AspNetCore.Identity;
using Blackmail.Models;
using Microsoft.JSInterop;

namespace Blackmail.Layouts
{
    public partial class HomeLayoutComponent : LayoutComponentBase
    {
        [Inject]
        protected Microsoft.JSInterop.IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }
        
        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }

        [Inject]
        protected BlackmailDbService BlackmailDb { get; set; }

        protected RadzenBody body0;

        protected override void OnInitialized()
        {
             base.OnInitialized();

             if (Security != null)
             {
                  Security.Authenticated += Authenticated;
             }
        }

        private void Authenticated()
        {
             StateHasChanged();
        }

    }
}
