using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleRain2.Models
{
    public class GoalCreate
    {
        [Required]
        public string GoalName { get; set; }

    }
}
