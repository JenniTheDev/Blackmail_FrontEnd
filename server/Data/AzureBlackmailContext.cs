using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using Blackmail.Models.AzureBlackmail;

namespace Blackmail.Data
{
  public partial class AzureBlackmailContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public AzureBlackmailContext(DbContextOptions<AzureBlackmailContext> options):base(options)
    {
    }

    public AzureBlackmailContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);



        this.OnModelBuilding(builder);
    }


    public DbSet<Blackmail.Models.AzureBlackmail.Devicecode> Devicecodes
    {
      get;
      set;
    }

    public DbSet<Blackmail.Models.AzureBlackmail.Persistedgrant> Persistedgrants
    {
      get;
      set;
    }
  }
}
