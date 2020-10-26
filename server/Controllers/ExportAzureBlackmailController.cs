using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blackmail.Data;

namespace Blackmail
{
    public partial class ExportAzureBlackmailController : ExportController
    {
        private readonly AzureBlackmailContext context;

        public ExportAzureBlackmailController(AzureBlackmailContext context)
        {
            this.context = context;
        }
        [HttpGet("/export/AzureBlackmail/devicecodes/csv")]
        [HttpGet("/export/AzureBlackmail/devicecodes/csv(fileName='{fileName}')")]
        public FileStreamResult ExportDevicecodesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Devicecodes, Request.Query), fileName);
        }

        [HttpGet("/export/AzureBlackmail/devicecodes/excel")]
        [HttpGet("/export/AzureBlackmail/devicecodes/excel(fileName='{fileName}')")]
        public FileStreamResult ExportDevicecodesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Devicecodes, Request.Query), fileName);
        }
        [HttpGet("/export/AzureBlackmail/persistedgrants/csv")]
        [HttpGet("/export/AzureBlackmail/persistedgrants/csv(fileName='{fileName}')")]
        public FileStreamResult ExportPersistedgrantsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Persistedgrants, Request.Query), fileName);
        }

        [HttpGet("/export/AzureBlackmail/persistedgrants/excel")]
        [HttpGet("/export/AzureBlackmail/persistedgrants/excel(fileName='{fileName}')")]
        public FileStreamResult ExportPersistedgrantsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Persistedgrants, Request.Query), fileName);
        }
    }
}
