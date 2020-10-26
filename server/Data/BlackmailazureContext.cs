using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using Blackmail.Models.Blackmailazure;

namespace Blackmail.Data
{
  public partial class BlackmailazureContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public BlackmailazureContext(DbContextOptions<BlackmailazureContext> options):base(options)
    {
    }

    public BlackmailazureContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);



        this.OnModelBuilding(builder);
    }


    public DbSet<Blackmail.Models.Blackmailazure.Datum> Data
    {
      get;
      set;
    }
  }
}
