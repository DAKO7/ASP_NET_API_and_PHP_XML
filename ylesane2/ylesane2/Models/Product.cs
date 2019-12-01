using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ylesane2.Models
{
    [Table("tableProducts")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public int WorkDayId { get; set; }

        public DateTime? CreatedTime { get; set; }
        public DateTime? StartTime { get; set; }
        [DisplayFormat(DataFormatString = "{0: dd-MMM-yyyy HH:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? EndTime { get; set; }

        public string CreatedTimeString
        {
            get
            {
                return CreatedTime?.ToString("yyyy-MM-dd hh:mm");
            }
        }

        public string StartTimeString
        {
            get
            {
                return StartTime?.ToString("yyyy-MM-dd hh:mm");
            }
        }
        [DisplayFormat(DataFormatString = "{0: dd-MMM-yyyy HH:mm tt}", ApplyFormatInEditMode = true)]
        public string EndTimeString
        {
            get
            {

                return EndTime?.ToString("0: dd-MMM-yyyy HH:mm tt");
            }
        }

        public string Status
        {
            get
            {
                if (DateTime.Now < StartTime)
                    return "Not started yet";
                else if (DateTime.Now > StartTime && DateTime.Now < EndTime)
                    return "In work";
                else
                    return "Ended";
            }
        }
    }
}