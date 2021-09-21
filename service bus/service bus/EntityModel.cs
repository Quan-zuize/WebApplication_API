using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace service_bus
{
    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : base("name=EntityModel")
        {
        }

        public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }
        public virtual DbSet<Sinh_Vien> Sinh_Vien { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KhoaHoc>()
                .Property(e => e.MaKhoa)
                .IsFixedLength();

            modelBuilder.Entity<KhoaHoc>()
                .Property(e => e.TenKhoa)
                .IsFixedLength();

            modelBuilder.Entity<Sinh_Vien>()
                .Property(e => e.MaSV)
                .IsFixedLength();

            modelBuilder.Entity<Sinh_Vien>()
                .Property(e => e.HoSV)
                .IsFixedLength();

            modelBuilder.Entity<Sinh_Vien>()
                .Property(e => e.TenSV)
                .IsFixedLength();

            modelBuilder.Entity<Sinh_Vien>()
                .Property(e => e.GioiTinh)
                .IsFixedLength();

            modelBuilder.Entity<Sinh_Vien>()
                .Property(e => e.MaKhoa)
                .IsFixedLength();
        }
    }
}
