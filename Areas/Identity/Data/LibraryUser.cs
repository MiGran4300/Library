using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Library.Areas.Identity.Data
{
    public class LibraryUser : IdentityUser
    {
        [PersonalData]
        public string? Name { get; set; }
        [PersonalData]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? DOB { get; set; }
    }
}
