﻿using Library.Areas.Identity.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book
    {
        
        public int BookID { get; set; }
        public int? AuthorID { get; set; }
        
        [StringLength(50, MinimumLength = 3)]
        [DisplayName("Заглавие")]
        public string? Title { get; set; }
        [DisplayName("Откъс")]
        public string? Snippet { get; set; }
        [DisplayName("Жанр")]
        public string? Ganre { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата на публикуване")]
        public DateTime? ReleaseDate { get; set; } = DateTime.Now;

        [DisplayName("Качи файл")]
        public string? FilePath { get; set; }
        [NotMapped]
        [DisplayName("Качи файл")]
        public IFormFile? File { get; set; }
        public int Rating { get; set; }
        [DisplayName("Статус")]
        public ContactStatus Status { get; set; }

        public Author? Authors { get; set; }
        public ICollection<Rating>? Ratings { get; set;}
        
        public enum ContactStatus
        {
            Submitted,
            Approved,
            Rejected
        }

        public decimal OverallRating { get
            {
               
               
                if (Ratings!=null&&Ratings.Count > 0)
                { return (Ratings.Average(x => x.Rank)); }

                return (0);
            } }
        
     
       
}
    }

