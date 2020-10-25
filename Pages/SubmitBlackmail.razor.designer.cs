using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Blackmail.Models.BlackmailDb;
using Microsoft.AspNetCore.Identity;
using Blackmail.Models;
using Blackmail.Client.Pages;

namespace Blackmail.Pages
{
    public partial class SubmitBlackmailComponent : ComponentBase
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
        protected BlackmailDbService BlackmailDb { get; set; }

        Blackmail.Models.BlackmailDb.Datum _datum;
        protected Blackmail.Models.BlackmailDb.Datum datum
        {
            get
            {
                return _datum;
            }
            set
            {
                if (!object.Equals(_datum, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "datum", NewValue = value, OldValue = _datum };
                    _datum = value;
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
            datum = new Blackmail.Models.BlackmailDb.Datum(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(Blackmail.Models.BlackmailDb.Datum args)
        {
            try
            {
                var blackmailDbCreateDatumResult = await BlackmailDb.CreateDatum(datum:datum);
                DialogService.Close(datum);
            }
            catch (System.Exception blackmailDbCreateDatumException)
            {
                NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new Datum!");
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
