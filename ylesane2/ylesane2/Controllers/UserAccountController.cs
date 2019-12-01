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
    public class UserAccountController : ApiController
    {
        private DataBaseContext db = new DataBaseContext();

        // GET api/values/5
        public GetUser Get(int id)
        {
            GetUser user = new GetUser();

            User dbUser = db.Users.Where(x => x.Id == id).FirstOrDefault();
            if (dbUser != null)
            {
                user.Id = dbUser.Id;
                user.Email = dbUser.Email;
                user.Name = dbUser.Name;
                user.SecondName = dbUser.SecondName;
                user.PhoneNumber = dbUser.PhoneNumber;
                user.Products = dbUser.Products;          
                
            }
            return user;
        }

        public string Put(PasswordChange user)
        {
            string result = "";

            string OldPassword = user.OldPassword;
            OldPassword = Hash.ComputeSha256Hash(OldPassword);

            string NewPassword = user.NewPassword;
            NewPassword = Hash.ComputeSha256Hash(NewPassword);

            if (user.OldPassword == "") result = "OldPassword null";
            else if (user.NewPassword == "") result = "NewPassword null";
            else
            {
                if ((db.Users.Where(x => x.Email == user.Email).FirstOrDefault().Password == OldPassword))
                {
                    User user_ = db.Users.Where(x => x.Email == user.Email).FirstOrDefault();
                    user_.Password = NewPassword;
                    db.SaveChanges();
                    result = "Sucess";
                }
                else
                {
                    result = "Old password Wrong";
                }
            }

            return result;
        }
    }
}
