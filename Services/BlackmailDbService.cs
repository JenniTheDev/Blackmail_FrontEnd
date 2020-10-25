
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
using Blackmail.Models.BlackmailDb;

namespace Blackmail
{
    public partial class BlackmailDbService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;
        public BlackmailDbService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            this.baseUri = new Uri($"{navigationManager.BaseUri}odata/BlackmailDB/");
        }

        public async System.Threading.Tasks.Task ExportDataToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/blackmaildb/data/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/blackmaildb/data/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportDataToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/blackmaildb/data/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/blackmaildb/data/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetData(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<ODataServiceResult<Models.BlackmailDb.Datum>> GetData(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string))
        {
            var uri = new Uri(baseUri, $"Data");
            uri = uri.GetODataUri(filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:null, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetData(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<Models.BlackmailDb.Datum>>();
        }
        partial void OnCreateDatum(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Models.BlackmailDb.Datum> CreateDatum(Models.BlackmailDb.Datum datum = default(Models.BlackmailDb.Datum))
        {
            var uri = new Uri(baseUri, $"Data");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(datum), Encoding.UTF8, "application/json");

            OnCreateDatum(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Models.BlackmailDb.Datum>();
        }
        partial void OnDeleteDatum(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteDatum(int? idData = default(int?))
        {
            var uri = new Uri(baseUri, $"Data({idData})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteDatum(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetDatumByidData(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Models.BlackmailDb.Datum> GetDatumByidData(int? idData = default(int?))
        {
            var uri = new Uri(baseUri, $"Data({idData})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDatumByidData(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Models.BlackmailDb.Datum>();
        }
        partial void OnUpdateDatum(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateDatum(int? idData = default(int?), Models.BlackmailDb.Datum datum = default(Models.BlackmailDb.Datum))
        {
            var uri = new Uri(baseUri, $"Data({idData})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(datum), Encoding.UTF8, "application/json");

            OnUpdateDatum(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
    }
}
