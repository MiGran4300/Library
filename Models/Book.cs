using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book
    {
        


        public int BookID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string? Title { get; set; }
        public string? Author { get; set; }

        public string? Ganre { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Releas Date")]
        public DateTime? ReleaseDate { get; set; }
        
        



        public ICollection<Rent>? Rent { get; set; }
        
}
    }

