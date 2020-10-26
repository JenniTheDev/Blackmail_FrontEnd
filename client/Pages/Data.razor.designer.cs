using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Blackmail.Models.Blackmailazure;
using Microsoft.AspNetCore.Identity;
using Blackmail.Models;
using Blackmail.Client.Pages;

namespace Blackmail.Pages
{
    public partial class DataComponent : ComponentBase
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
        protected BlackmailazureService Blackmailazure { get; set; }
        protected RadzenGrid<Blackmail.Models.Blackmailazure.Datum> grid0;

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

        IEnumerable<Blackmail.Models.Blackmailazure.Datum> _getDataResult;
        protected IEnumerable<Blackmail.Models.Blackmailazure.Datum> getDataResult
        {
            get
            {
                return _getDataResult;
            }
            set
            {
                if (!object.Equals(_getDataResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getDataResult", NewValue = value, OldValue = _getDataResult };
                    _getDataResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getDataCount;
        protected int getDataCount
        {
            get
            {
                return _getDataCount;
            }
            set
            {
                if (!object.Equals(_getDataCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getDataCount", NewValue = value, OldValue = _getDataCount };
                    _getDataCount = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            if (!await Security.IsAuthenticatedAsync())
            {
                UriHelper.NavigateTo("Login", true);
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
            var dialogResult = await DialogService.OpenAsync<AddDatum>("Add Datum", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var blackmailazureGetDataResult = await Blackmailazure.GetData(filter:$@"(contains(Blackmailer,""{search}"") or contains(Blackmailee,""{search}"") or contains(img,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getDataResult = blackmailazureGetDataResult.Value.AsODataEnumerable();

                getDataCount = blackmailazureGetDataResult.Count;
            }
            catch (System.Exception blackmailazureGetDataException)
            {
                NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to load Data");
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(Blackmail.Models.Blackmailazure.Datum args)
        {
            var dialogResult = await DialogService.OpenAsync<EditDatum>("Edit Datum", new Dictionary<string, object>() { {"UserID", args.UserID} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var blackmailazureDeleteDatumResult = await Blackmailazure.DeleteDatum(userId:data.UserID);
                    if (blackmailazureDeleteDatumResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception blackmailazureDeleteDatumException)
            {
                NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete Datum");
            }
        }
    }
}
