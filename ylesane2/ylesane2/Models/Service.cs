using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ylesane2.Models
{
    [Table("tableServices")]
    public class Service
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }

        public int WorkDayId { get; set; }

        [Required]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int ProductPrice { get; set; }

        public DateTime? StartTime { get; set; }

        [DisplayFormat(DataFormatString = "{0: dd-MMM-yyyy HH:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? EndTime { get; set; }

        public string StartTimeString
        {
            get
            {
                return StartTime?.ToString("yyyy-MM-dd hh:mm");
            }
        }

        //public string EndTimeString
        //{
        //    get
        //    {
        //        return EndTime?.ToString("yyyy-MM-dd hh:mm");
        //    }
        //}

        public string Status
        {
            get
            {
                if (DateTime.Now > StartTime && DateTime.Now < EndTime)
                    return "Not started yet";
                else if (DateTime.Now == EndTime)
                    return "In work";
                else
                    return "Ended";
            }
        }
    }
}