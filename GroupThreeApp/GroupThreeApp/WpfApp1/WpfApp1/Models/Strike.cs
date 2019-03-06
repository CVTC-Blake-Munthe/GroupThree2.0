using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileTesting.Models
{
    [Table("strikes")]
    public class Strike
    {
        [Key]
        public int StrikeID { get; set; }

        [ForeignKey("guests")]
        public int GuestID { get; set; }
        public Guest guests { get; set; }

        [ForeignKey("calendar")]
        public int CalendarID { get; set; }
        public Calendar calendar { get; set; }

        [ForeignKey("rules")]
        public int RuleID { get; set; }
        public Rule rules { get; set; }

        public string Notes { get; set; }
        public string StrikeOutWarning { get; set; }

    }
}
