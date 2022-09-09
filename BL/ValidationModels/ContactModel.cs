using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ValidationModels
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Put your name")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Put your lastname ")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field cannot be empty")]
        [EmailAddress(ErrorMessage = "Wrong email format")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field cannot be empty")]
        public string AccountName { get; set; } = string.Empty;
    }
}
