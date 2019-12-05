using PurpleRain2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleRain2.Models
{
    public class DayListItem
    {
        public int DayID { get; set; }
        public string DayName { get; set; }
        public string Date { get; set; }
        public Outfit Outfit { get; set; }]
        public Goal Goal { get; set; }
    }
}
