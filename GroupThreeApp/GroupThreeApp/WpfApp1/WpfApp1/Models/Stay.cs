using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileTesting.Models
{
    [Table("stays")]
    public class Stay
    {
        [Key]
        [ForeignKey("guests")]
        public int GuestID { get; set; }
        public Guest guests { get; set; }

        [ForeignKey("calendars")]
        public int CalendarID { get; set; }
        public Calendar calendars { get; set; }
    }
}
