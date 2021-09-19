using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication1.Models
{
    public partial class DuLieuCuaLinh : DbContext
    {
        public DuLieuCuaLinh()
            : base("name=DuLieuCuaLinh")
        {
        }

        public virtual DbSet<LinhsTestTable2> LinhsTestTable2 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<WebApplication1.Models.Linhs> Linhs { get; set; }
    }
}
