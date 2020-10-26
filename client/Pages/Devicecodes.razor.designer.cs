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
    public partial class DevicecodesComponent : ComponentBase
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
        protected RadzenGrid<Blackmail.Models.AzureBlackmail.Devicecode> grid0;

        string _search;
        protected string search
        {
            get
            {
                return _search;
            }
            set
            {
                if (!object.Equals(_search, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "search", NewValue = value, OldValue = _search };
                    _search = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Blackmail.Models.AzureBlackmail.Devicecode> _getDevicecodesResult;
        protected IEnumerable<Blackmail.Models.AzureBlackmail.Devicecode> getDevicecodesResult
        {
            get
            {
                return _getDevicecodesResult;
            }
            set
            {
                if (!object.Equals(_getDevicecodesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getDevicecodesResult", NewValue = value, OldValue = _getDevicecodesResult };
                    _getDevicecodesResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getDevicecodesCount;
        protected int getDevicecodesCount
        {
            get
            {
                return _getDevicecodesCount;
            }
            set
            {
                if (!object.Equals(_getDevicecodesCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getDevicecodesCount", NewValue = value, OldValue = _getDevicecodesCount };
                    _getDevicecodesCount = value;
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
            if (string.IsNullOrEmpty(search)) {
                search = "";
            }
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddDevicecode>("Add Devicecode", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var azureBlackmailGetDevicecodesResult = await AzureBlackmail.GetDevicecodes(filter:$@"(contains(UserCode,""{search}"") or contains(DeviceCode1,""{search}"") or contains(SubjectId,""{search}"") or contains(ClientId,""{search}"") or contains(Data,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getDevicecodesResult = azureBlackmailGetDevicecodesResult.Value.AsODataEnumerable();

                getDevicecodesCount = azureBlackmailGetDevicecodesResult.Count;
            }
            catch (System.Exception azureBlackmailGetDevicecodesException)
            {
                NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to load Devicecodes");
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(Blackmail.Models.AzureBlackmail.Devicecode args)
        {
            var dialogResult = await DialogService.OpenAsync<EditDevicecode>("Edit Devicecode", new Dictionary<string, object>() { {"UserCode", args.UserCode} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var azureBlackmailDeleteDevicecodeResult = await AzureBlackmail.DeleteDevicecode(userCode:$"{data.UserCode}");
                    if (azureBlackmailDeleteDevicecodeResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception azureBlackmailDeleteDevicecodeException)
            {
                NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete Devicecode");
            }
        }
    }
}
