
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components;
using Radzen;
using Blackmail.Models.AzureBlackmail;

namespace Blackmail
{
    public partial class AzureBlackmailService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;
        public AzureBlackmailService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            this.baseUri = new Uri($"{navigationManager.BaseUri}odata/AzureBlackmail/");
        }

        public async System.Threading.Tasks.Task ExportDevicecodesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/azureblackmail/devicecodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/azureblackmail/devicecodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportDevicecodesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/azureblackmail/devicecodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/azureblackmail/devicecodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetDevicecodes(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<ODataServiceResult<Models.AzureBlackmail.Devicecode>> GetDevicecodes(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string))
        {
            var uri = new Uri(baseUri, $"Devicecodes");
            uri = uri.GetODataUri(filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:null, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDevicecodes(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<Models.AzureBlackmail.Devicecode>>();
        }
        partial void OnCreateDevicecode(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Models.AzureBlackmail.Devicecode> CreateDevicecode(Models.AzureBlackmail.Devicecode devicecode = default(Models.AzureBlackmail.Devicecode))
        {
            var uri = new Uri(baseUri, $"Devicecodes");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(devicecode), Encoding.UTF8, "application/json");

            OnCreateDevicecode(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Models.AzureBlackmail.Devicecode>();
        }

        public async System.Threading.Tasks.Task ExportPersistedgrantsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/azureblackmail/persistedgrants/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/azureblackmail/persistedgrants/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportPersistedgrantsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/azureblackmail/persistedgrants/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/azureblackmail/persistedgrants/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetPersistedgrants(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<ODataServiceResult<Models.AzureBlackmail.Persistedgrant>> GetPersistedgrants(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string))
        {
            var uri = new Uri(baseUri, $"Persistedgrants");
            uri = uri.GetODataUri(filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:null, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetPersistedgrants(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<Models.AzureBlackmail.Persistedgrant>>();
        }
        partial void OnCreatePersistedgrant(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Models.AzureBlackmail.Persistedgrant> CreatePersistedgrant(Models.AzureBlackmail.Persistedgrant persistedgrant = default(Models.AzureBlackmail.Persistedgrant))
        {
            var uri = new Uri(baseUri, $"Persistedgrants");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(persistedgrant), Encoding.UTF8, "application/json");

            OnCreatePersistedgrant(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Models.AzureBlackmail.Persistedgrant>();
        }
        partial void OnDeleteDevicecode(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteDevicecode(string userCode = default(string))
        {
            var uri = new Uri(baseUri, $"Devicecodes('{HttpUtility.UrlEncode(userCode)}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteDevicecode(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetDevicecodeByUserCode(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Models.AzureBlackmail.Devicecode> GetDevicecodeByUserCode(string userCode = default(string))
        {
            var uri = new Uri(baseUri, $"Devicecodes('{HttpUtility.UrlEncode(userCode)}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDevicecodeByUserCode(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Models.AzureBlackmail.Devicecode>();
        }
        partial void OnUpdateDevicecode(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateDevicecode(string userCode = default(string), Models.AzureBlackmail.Devicecode devicecode = default(Models.AzureBlackmail.Devicecode))
        {
            var uri = new Uri(baseUri, $"Devicecodes('{HttpUtility.UrlEncode(userCode)}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(devicecode), Encoding.UTF8, "application/json");

            OnUpdateDevicecode(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeletePersistedgrant(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeletePersistedgrant(string key = default(string))
        {
            var uri = new Uri(baseUri, $"Persistedgrants('{HttpUtility.UrlEncode(key)}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeletePersistedgrant(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetPersistedgrantByKey(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Models.AzureBlackmail.Persistedgrant> GetPersistedgrantByKey(string key = default(string))
        {
            var uri = new Uri(baseUri, $"Persistedgrants('{HttpUtility.UrlEncode(key)}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetPersistedgrantByKey(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Models.AzureBlackmail.Persistedgrant>();
        }
        partial void OnUpdatePersistedgrant(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdatePersistedgrant(string key = default(string), Models.AzureBlackmail.Persistedgrant persistedgrant = default(Models.AzureBlackmail.Persistedgrant))
        {
            var uri = new Uri(baseUri, $"Persistedgrants('{HttpUtility.UrlEncode(key)}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(persistedgrant), Encoding.UTF8, "application/json");

            OnUpdatePersistedgrant(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
    }
}
