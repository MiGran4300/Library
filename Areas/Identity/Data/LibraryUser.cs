using Library.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Areas.Identity.Data
{
    public class LibraryUser : IdentityUser
    {
        [PersonalData]
        [DisplayName("Име")]
        public string? Name { get; set; }
        [PersonalData]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DisplayName("Дата на раждане")]
        public DateTime? DOB { get; set; }

        

    }
}
