using Library.Models;
using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel
{
    public class CreateBookViewModel: Book
    {

        
        public IFormFile? Photo { get; set; }

    }
}
