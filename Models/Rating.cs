using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public string? UserId { get; set; }
        [Range(0,5)]
        [Display(Name = "Rank")]
        public decimal Rank { get;  set; }
        public int? BookID { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public Book? Book { get; set; }
    }
}
