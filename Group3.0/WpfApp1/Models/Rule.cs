using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileTesting.Models
{
    [Table("rules")]
    public class Rule
    {
        [Key]
        public int RuleID { get; set; }
        public int RuleNo { get; set; }
        public string RuleText { get; set; }
    }
}
