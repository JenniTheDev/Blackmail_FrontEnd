using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blackmail.Data;

namespace Blackmail
{
    public partial class ExportBlackmailazureController : ExportController
    {
        private readonly BlackmailazureContext context;

        public ExportBlackmailazureController(BlackmailazureContext context)
        {
            this.context = context;
        }
        [HttpGet("/export/Blackmailazure/data/csv")]
        [HttpGet("/export/Blackmailazure/data/csv(fileName='{fileName}')")]
        public FileStreamResult ExportDataToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Data, Request.Query), fileName);
        }

        [HttpGet("/export/Blackmailazure/data/excel")]
        [HttpGet("/export/Blackmailazure/data/excel(fileName='{fileName}')")]
        public FileStreamResult ExportDataToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Data, Request.Query), fileName);
        }
    }
}
