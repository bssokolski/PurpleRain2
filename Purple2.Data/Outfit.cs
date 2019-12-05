
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleRain2.Data
{
    public class Outfit
    {
        [Key]
        public int OutfitID { get; set; }
        public string OutfitName { get; set; }
        public string Top { get; set; }
        public string Bottom { get; set; }
        public int? DayID { get; set; }
    }
}