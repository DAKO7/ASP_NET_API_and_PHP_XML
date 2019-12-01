using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ylesane2.Models;

namespace ylesane2.Controllers
{
    public class RegisterController : ApiController
    {
        private DataBaseContext db = new DataBaseContext();

        public string Post(RegisterUser registerUser)
        {
            string result = "";
            if (registerUser.Password != registerUser.ConfirmPassword) result = "Passwords do not match";
            else if (db.Users.Where(x => x.Email == registerUser.Email).FirstOrDefault() != null) result = "This user already exists";
            else
            {
                if (registerUser.Email == "" || registerUser.Password == "" || registerUser.ConfirmPassword == "" || registerUser.Name == "" || registerUser.SecondName == "" || registerUser.PhoneNumber == "") return "some field is not filled";
                else
                {
                    HttpContext.Current.Session["email"] = registerUser.Email;

                    string password = registerUser.Password;
                    result = "Success";
                    User user = new User();
                    user.Name = registerUser.Name;
                    user.SecondName = registerUser.SecondName;
                    user.PhoneNumber = registerUser.PhoneNumber;
                    user.Email = registerUser.Email;
                    user.Password = Hash.ComputeSha256Hash(password);
                    user.RoleId = 1;
                    db.Users.Add(user);
                    db.SaveChanges();
                }


            }
            return result;
        }
    }
}
