namespace service_bus
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Sinh_Vien
    {
        [DataMember]
        [Key]
        [StringLength(10)]
        public string MaSV { get; set; }

        [DataMember]
        [Required]
        [StringLength(10)]
        public string HoSV { get; set; }

        [DataMember]
        [Required]
        [StringLength(100)]
        public string TenSV { get; set; }

        [DataMember]
        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        [DataMember]
        [Required]
        [StringLength(10)]
        public string GioiTinh { get; set; }

        [DataMember]
        [Required]
        [StringLength(10)]
        public string MaKhoa { get; set; }
    }
}
