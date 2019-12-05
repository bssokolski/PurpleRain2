using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleRain2.Data
{
    public class Day
    {
        [Key]
        public int DayID { get; set; }
        [Required]
        public string DayName { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [ForeignKey("Outfit")]
        public int? OutfitID { get; set; }
        [ForeignKey("Goal")]
        public int? GoalID { get; set; }
        public virtual Outfit Outfit { get; set; }
        public virtual Goal Goal{ get; set; }
    }
}
