namespace WcfServiceApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [DataContract]
    [Table("SinhVien")]
    public partial class SinhVien
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [DataMember]
        [StringLength(10)]
        public string Phone { get; set; }

        [DataMember]
        [StringLength(50)]
        public string Email { get; set; }

        [DataMember]
        [Required]
        [StringLength(50)]
        public string Pass { get; set; }

        [DataMember]
        public int ClassID { get; set; }

        public virtual LopHoc LopHoc { get; set; }
    }
}
