using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DA.Entities
{
    public class Contact
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        [Key]
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountName { get; set; }
        [JsonIgnore]
        public int AccountId { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }
    }
}
