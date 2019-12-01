using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ylesane2.Models
{
    [Table("tableWorkDays")]
    public class WorkDay
    {
        public int Id { get; set; }
        public DateTime DateIn { get; set; }
        public int Status { get; set; }
    }
}