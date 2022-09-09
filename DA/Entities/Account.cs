using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DA.Entities
{
    public class Account
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        [Key]
        public string Name { get; set; }
        public string IncidentTitle { get; set; }
        [JsonIgnore]
        public virtual Incident? Incident { get; set; }
        [JsonIgnore]
        public virtual ICollection<Contact>? Contacts { get; set; }
    }
}
