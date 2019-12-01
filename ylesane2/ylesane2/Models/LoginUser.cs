using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ylesane2.Models
{
    public class LoginUser
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
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
    }
}