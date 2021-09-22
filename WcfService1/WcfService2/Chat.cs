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
    [Table("Chat")]
    public partial class Chat
    {
        [DataMember]
        [Key]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public string Content { get; set; }

        [DataMember]
        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [DataMember]
        [Column(TypeName = "date")]
        public DateTime SentTime { get; set; }

        [ForeignKey("Username")]
        public virtual User User { get; set; }
    }
}