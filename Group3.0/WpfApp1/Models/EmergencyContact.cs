using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileTesting.Models
{
    [Table("emergencyContacts")]
    public class EmergencyContact
    {
        [Key]
        public int ContactID { get; set; }
        
        [ForeignKey("guests")]
        public int GuestID { get; set; }
        public Guest guests { get; set; }
        
        public string ContactFname { get; set; }
        public string ContactLname { get; set; }
        public string ContactPhone { get; set; }
        public string ContactRelation { get; set; }

    }
}
