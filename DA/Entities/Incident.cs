using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DA.Entities
{
    public class Incident
    {
        [Key]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [JsonIgnore]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
