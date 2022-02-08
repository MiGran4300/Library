using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Rent
    {
        public int RentID { get; set; }
        public int CostumerID { get; set; }
        public int BookID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime RentDate { get; set; }


        public Costumer? Costumer { get; set; }
        public Book? Book { get; set; }
    }
}
