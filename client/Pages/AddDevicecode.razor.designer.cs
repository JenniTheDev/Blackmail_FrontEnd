using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Blackmail.Models.AzureBlackmail;
using Microsoft.AspNetCore.Identity;
using Blackmail.Models;
using Blackmail.Client.Pages;

namespace Blackmail.Pages
{
    public partial class AddDevicecodeComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

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
        protected AzureBlackmailService AzureBlackmail { get; set; }

        Blackmail.Models.AzureBlackmail.Devicecode _devicecode;
        protected Blackmail.Models.AzureBlackmail.Devicecode devicecode
        {
            get
            {
                return _devicecode;
            }
            set
            {
                if (!object.Equals(_devicecode, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "devicecode", NewValue = value, OldValue = _devicecode };
                    _devicecode = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            if (!await Security.IsAuthenticatedAsync())
            {
                UriHelper.NavigateTo("Application Users", true);
            }
            else
            {
                await Load();
            }

        }
        protected async System.Threading.Tasks.Task Load()
        {
            devicecode = new Blackmail.Models.AzureBlackmail.Devicecode(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(Blackmail.Models.AzureBlackmail.Devicecode args)
        {
            try
            {
                var azureBlackmailCreateDevicecodeResult = await AzureBlackmail.CreateDevicecode(devicecode:devicecode);
                DialogService.Close(devicecode);
            }
            catch (System.Exception azureBlackmailCreateDevicecodeException)
            {
                NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new Devicecode!");
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
