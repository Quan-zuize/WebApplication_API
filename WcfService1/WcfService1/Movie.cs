namespace WcfService1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [DataContract]
    [Table("Movie")]
    public partial class Movie
    {
        [DataMember]
        public int MovieId { get; set; }

        [DataMember]
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [DataMember]
        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }

        [DataMember]
        public int RunningTime { get; set; }

        [DataMember]
        public int GenreId { get; set; }

        [DataMember]
        [Column(TypeName = "money")]
        public decimal BoxOffice { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
