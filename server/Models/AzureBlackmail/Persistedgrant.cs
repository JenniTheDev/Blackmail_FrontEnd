using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blackmail.Models.AzureBlackmail
{
  [Table("persistedgrants")]
  public partial class Persistedgrant
  {
    [Key]
    public string Key
    {
      get;
      set;
    }
    public string Type
    {
      get;
      set;
    }
    public string SubjectId
    {
      get;
      set;
    }
    public string ClientId
    {
      get;
      set;
    }
    public DateTime CreationTime
    {
      get;
      set;
    }
    public DateTime? Expiration
    {
      get;
      set;
    }
    public string Data
    {
      get;
      set;
    }
  }
}
