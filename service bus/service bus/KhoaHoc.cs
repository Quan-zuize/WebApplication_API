namespace service_bus
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhoaHoc")]
    public partial class KhoaHoc
    {
        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        public string MaKhoa { get; set; }

        [Required]
        [StringLength(100)]
        public string TenKhoa { get; set; }
    }
}
