using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileTesting.Models
{
    [Table("calendars")]
    public class Calendar
    {
        [Key]
        public int CalendarID { get; set; }
        public DateTime Date { get; set; }
    }
}
