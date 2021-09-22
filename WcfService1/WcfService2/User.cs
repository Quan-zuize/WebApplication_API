using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService2
{
    [DataContract]
    [Table("User")]
    public partial class User
    {
        [DataMember]
        [Key]
        [Required]
        public string Username { get; set; }

        [DataMember]
        [Required]
        public string Password { get; set; }
    }
}