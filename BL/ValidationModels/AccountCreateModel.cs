using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ValidationModels
{
    public class AccountCreateModel
    {
        [Required(ErrorMessage = "This field cannot be empty")]
        [MaxLength(25, ErrorMessage = "Max length 25")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Put your name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Put your lastname")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        [EmailAddress(ErrorMessage = "Wrong email format")]
        public string Email { get; set; }
    }
}
