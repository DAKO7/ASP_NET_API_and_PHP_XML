using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ylesane2.Models
{
    [Table("tableUsers")]
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }

        public string FullName
        {
            get
            {
                return Name + " " + SecondName;
            }
        }

        public string Products { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}