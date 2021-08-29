using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; } //Id album
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string Title { get; set; } //Tựa Đề album
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }// Ngày Phát Hành
        [Required]
        public string Artist { get; set; }//Ca sĩ/Nhóm nhạc
        [Required]
        [Range(1, 15)]
        public double Price { get; set; }//Giá (đô)
        public int GenreId { get; set; }// Id thể loại
        public virtual Genre Genre { get; set; } //Thể Loại
    }
}