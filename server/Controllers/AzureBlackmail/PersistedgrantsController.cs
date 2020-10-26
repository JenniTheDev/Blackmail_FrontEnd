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



namespace Blackmail.Controllers.AzureBlackmail
{
  using Models;
  using Data;
  using Models.AzureBlackmail;

  [ODataRoutePrefix("odata/AzureBlackmail/Persistedgrants")]
  [Route("mvc/odata/AzureBlackmail/Persistedgrants")]
  public partial class PersistedgrantsController : ODataController
  {
    private Data.AzureBlackmailContext context;

    public PersistedgrantsController(Data.AzureBlackmailContext context)
    {
      this.context = context;
    }
    // GET /odata/AzureBlackmail/Persistedgrants
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.AzureBlackmail.Persistedgrant> GetPersistedgrants()
    {
      var items = this.context.Persistedgrants.AsQueryable<Models.AzureBlackmail.Persistedgrant>();
      this.OnPersistedgrantsRead(ref items);

      return items;
    }

    partial void OnPersistedgrantsRead(ref IQueryable<Models.AzureBlackmail.Persistedgrant> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Key}")]
    public SingleResult<Persistedgrant> GetPersistedgrant(string key)
    {
        var items = this.context.Persistedgrants.Where(i=>i.Key == key);
        return SingleResult.Create(items);
    }
    partial void OnPersistedgrantDeleted(Models.AzureBlackmail.Persistedgrant item);
    partial void OnAfterPersistedgrantDeleted(Models.AzureBlackmail.Persistedgrant item);

    [HttpDelete("{Key}")]
    public IActionResult DeletePersistedgrant(string key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Persistedgrants
                .Where(i => i.Key == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnPersistedgrantDeleted(item);
            this.context.Persistedgrants.Remove(item);
            this.context.SaveChanges();
            this.OnAfterPersistedgrantDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnPersistedgrantUpdated(Models.AzureBlackmail.Persistedgrant item);
    partial void OnAfterPersistedgrantUpdated(Models.AzureBlackmail.Persistedgrant item);

    [HttpPut("{Key}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutPersistedgrant(string key, [FromBody]Models.AzureBlackmail.Persistedgrant newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.Key != key))
            {
                return BadRequest();
            }

            this.OnPersistedgrantUpdated(newItem);
            this.context.Persistedgrants.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Persistedgrants.Where(i => i.Key == key);
            this.OnAfterPersistedgrantUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{Key}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchPersistedgrant(string key, [FromBody]Delta<Models.AzureBlackmail.Persistedgrant> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Persistedgrants.Where(i => i.Key == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnPersistedgrantUpdated(item);
            this.context.Persistedgrants.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Persistedgrants.Where(i => i.Key == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnPersistedgrantCreated(Models.AzureBlackmail.Persistedgrant item);
    partial void OnAfterPersistedgrantCreated(Models.AzureBlackmail.Persistedgrant item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.AzureBlackmail.Persistedgrant item)
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

            this.OnPersistedgrantCreated(item);
            this.context.Persistedgrants.Add(item);
            this.context.SaveChanges();

            return Created($"odata/AzureBlackmail/Persistedgrants/{item.Key}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
