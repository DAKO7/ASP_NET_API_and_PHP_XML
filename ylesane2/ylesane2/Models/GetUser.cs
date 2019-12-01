using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ylesane2.Models
{
    public class GetUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Products { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
    }
}