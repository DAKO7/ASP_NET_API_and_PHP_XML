using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ylesane2.Models
{
    [Table("tableRoles")]
    public class Role
    {
        public int Id { get; set; }
        public int AccessLevel { get; set; }
        public string Name { get; set; }
    }
}