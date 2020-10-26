using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNet.OData.Query;



namespace Blackmail.Controllers.Blackmailazure
{
  using Models;
  using Data;
  using Models.Blackmailazure;

  [ODataRoutePrefix("odata/blackmailazure/Data")]
  [Route("mvc/odata/blackmailazure/Data")]
  public partial class DataController : ODataController
  {
    private Data.BlackmailazureContext context;

    public DataController(Data.BlackmailazureContext context)
    {
      this.context = context;
    }
    // GET /odata/Blackmailazure/Data
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Blackmailazure.Datum> GetData()
    {
      var items = this.context.Data.AsQueryable<Models.Blackmailazure.Datum>();
      this.OnDataRead(ref items);

      return items;
    }

    partial void OnDataRead(ref IQueryable<Models.Blackmailazure.Datum> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{UserID}")]
    public SingleResult<Datum> GetDatum(int key)
    {
        var items = this.context.Data.Where(i=>i.UserID == key);
        return SingleResult.Create(items);
    }
    partial void OnDatumDeleted(Models.Blackmailazure.Datum item);
    partial void OnAfterDatumDeleted(Models.Blackmailazure.Datum item);

    [HttpDelete("{UserID}")]
    public IActionResult DeleteDatum(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Data
                .Where(i => i.UserID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnDatumDeleted(item);
            this.context.Data.Remove(item);
            this.context.SaveChanges();
            this.OnAfterDatumDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDatumUpdated(Models.Blackmailazure.Datum item);
    partial void OnAfterDatumUpdated(Models.Blackmailazure.Datum item);

    [HttpPut("{UserID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutDatum(int key, [FromBody]Models.Blackmailazure.Datum newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.UserID != key))
            {
                return BadRequest();
            }

            this.OnDatumUpdated(newItem);
            this.context.Data.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Data.Where(i => i.UserID == key);
            this.OnAfterDatumUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{UserID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchDatum(int key, [FromBody]Delta<Models.Blackmailazure.Datum> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Data.Where(i => i.UserID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnDatumUpdated(item);
            this.context.Data.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Data.Where(i => i.UserID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDatumCreated(Models.Blackmailazure.Datum item);
    partial void OnAfterDatumCreated(Models.Blackmailazure.Datum item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Blackmailazure.Datum item)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (item == null)
            {
                return BadRequest();
            }

            this.OnDatumCreated(item);
            this.context.Data.Add(item);
            this.context.SaveChanges();

            return Created($"odata/Blackmailazure/Data/{item.UserID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
