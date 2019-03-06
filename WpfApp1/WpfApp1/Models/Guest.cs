using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileTesting.Models
{
    [Table("guests")]
    public class Guest
    {
        [Key]
        public int GuestID { get; set; }
        public String Fname { get; set; }
        public String Lname { get; set; }
        public String MI { get; set; }
        public String DOB { get; set; }
        public String Phone { get; set; }
        public int TotalDays { get; set; }
        public String Gender { get; set; }
        public int SSN { get; set; }
        public bool IntakeComplete { get; set; }
    }
}
