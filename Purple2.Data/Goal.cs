using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleRain2.Data
{
    public class Goal
    {
        [Key]
        public int GoalID { get; set; }
        public string GoalName { get; set; }
        public string GoalDescription { get; set; }
        public int? DayID { get; set; }
    }
}
