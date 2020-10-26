
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
using Blackmail.Models.Blackmailazure;

namespace Blackmail
{
    public partial class BlackmailazureService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;
        public BlackmailazureService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            this.baseUri = new Uri($"{navigationManager.BaseUri}odata/blackmailazure/");
        }

        public async System.Threading.Tasks.Task ExportDataToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/blackmailazure/data/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/blackmailazure/data/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportDataToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/blackmailazure/data/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/blackmailazure/data/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetData(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<ODataServiceResult<Models.Blackmailazure.Datum>> GetData(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string))
        {
            var uri = new Uri(baseUri, $"Data");
            uri = uri.GetODataUri(filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:null, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetData(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<Models.Blackmailazure.Datum>>();
        }
        partial void OnCreateDatum(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Models.Blackmailazure.Datum> CreateDatum(Models.Blackmailazure.Datum datum = default(Models.Blackmailazure.Datum))
        {
            var uri = new Uri(baseUri, $"Data");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(datum), Encoding.UTF8, "application/json");

            OnCreateDatum(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Models.Blackmailazure.Datum>();
        }
        partial void OnDeleteDatum(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteDatum(int? userId = default(int?))
        {
            var uri = new Uri(baseUri, $"Data({userId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteDatum(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetDatumByUserId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Models.Blackmailazure.Datum> GetDatumByUserId(int? userId = default(int?))
        {
            var uri = new Uri(baseUri, $"Data({userId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDatumByUserId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Models.Blackmailazure.Datum>();
        }
        partial void OnUpdateDatum(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateDatum(int? userId = default(int?), Models.Blackmailazure.Datum datum = default(Models.Blackmailazure.Datum))
        {
            var uri = new Uri(baseUri, $"Data({userId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(datum), Encoding.UTF8, "application/json");

            OnUpdateDatum(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
    }
}
