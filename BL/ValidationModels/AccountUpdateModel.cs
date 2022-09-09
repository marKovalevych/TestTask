using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ValidationModels
{
    public class AccountUpdateModel
    {
        [Required(ErrorMessage = "This field cannot be empty")]
        public string OldName { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field cannot be empty")]
        [MaxLength(25, ErrorMessage = "Max length 25")]
        public string Name { get; set; } = string.Empty;
    }
}
