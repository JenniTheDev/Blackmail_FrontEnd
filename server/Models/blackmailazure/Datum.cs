using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blackmail.Models.Blackmailazure {
    [Table("data")]
    public partial class Datum {
        [Key]
        public int UserID {
            get;
            set;
        }

        public string UserName {
            get;
            set;
        }
        public string email {
            get;
            set;
        }
        public string password {
            get;
            set;
        }
        public bool admin {
            get;
            set;
        }
        public string Blackmailer {
            get;
            set;
        }
        public string Blackmailee {
            get;
            set;
        }
        public double? cost {
            get;
            set;
        }
        public string img {
            get;
            set;
        }
    }
}
