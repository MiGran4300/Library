using Library.Areas.Identity.Data;
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
        public string? Title { get; set; }
        
        public string? Snippet { get; set; }

        public string? Ganre { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Releas Date")]
        public DateTime? ReleaseDate { get; set; }

        [DisplayName("File Name")]
        public string? FilePath { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile? File { get; set; }

        public Author? Authors { get; set; }

        
       
}
    }

