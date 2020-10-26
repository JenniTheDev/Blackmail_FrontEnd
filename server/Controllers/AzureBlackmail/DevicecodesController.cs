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

  [ODataRoutePrefix("odata/AzureBlackmail/Devicecodes")]
  [Route("mvc/odata/AzureBlackmail/Devicecodes")]
  public partial class DevicecodesController : ODataController
  {
    private Data.AzureBlackmailContext context;

    public DevicecodesController(Data.AzureBlackmailContext context)
    {
      this.context = context;
    }
    // GET /odata/AzureBlackmail/Devicecodes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.AzureBlackmail.Devicecode> GetDevicecodes()
    {
      var items = this.context.Devicecodes.AsQueryable<Models.AzureBlackmail.Devicecode>();
      this.OnDevicecodesRead(ref items);

      return items;
    }

    partial void OnDevicecodesRead(ref IQueryable<Models.AzureBlackmail.Devicecode> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{UserCode}")]
    public SingleResult<Devicecode> GetDevicecode(string key)
    {
        var items = this.context.Devicecodes.Where(i=>i.UserCode == key);
        return SingleResult.Create(items);
    }
    partial void OnDevicecodeDeleted(Models.AzureBlackmail.Devicecode item);
    partial void OnAfterDevicecodeDeleted(Models.AzureBlackmail.Devicecode item);

    [HttpDelete("{UserCode}")]
    public IActionResult DeleteDevicecode(string key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Devicecodes
                .Where(i => i.UserCode == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnDevicecodeDeleted(item);
            this.context.Devicecodes.Remove(item);
            this.context.SaveChanges();
            this.OnAfterDevicecodeDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDevicecodeUpdated(Models.AzureBlackmail.Devicecode item);
    partial void OnAfterDevicecodeUpdated(Models.AzureBlackmail.Devicecode item);

    [HttpPut("{UserCode}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutDevicecode(string key, [FromBody]Models.AzureBlackmail.Devicecode newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.UserCode != key))
            {
                return BadRequest();
            }

            this.OnDevicecodeUpdated(newItem);
            this.context.Devicecodes.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Devicecodes.Where(i => i.UserCode == key);
            this.OnAfterDevicecodeUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{UserCode}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchDevicecode(string key, [FromBody]Delta<Models.AzureBlackmail.Devicecode> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Devicecodes.Where(i => i.UserCode == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnDevicecodeUpdated(item);
            this.context.Devicecodes.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Devicecodes.Where(i => i.UserCode == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDevicecodeCreated(Models.AzureBlackmail.Devicecode item);
    partial void OnAfterDevicecodeCreated(Models.AzureBlackmail.Devicecode item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.AzureBlackmail.Devicecode item)
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

            this.OnDevicecodeCreated(item);
            this.context.Devicecodes.Add(item);
            this.context.SaveChanges();

            return Created($"odata/AzureBlackmail/Devicecodes/{item.UserCode}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
