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
    public class LoginController : ApiController
    {
        private DataBaseContext db = new DataBaseContext();

        public string Post(LoginUser user)
        {
            string result = "alala";
            if (user.Password == "") result = "Password field are null";
            else if (user.Email == "") result = "Email field are null";
            else
            {
                if ((db.Users.Where(x => x.Email == user.Email).FirstOrDefault() != null))
                {
                    string Password = user.Password;
                    Password = Hash.ComputeSha256Hash(Password);
                    if ((db.Users.Where(x => x.Email == user.Email).FirstOrDefault().Password == Password))
                    {
                        HttpContext.Current.Session["Email"] = user.Email;
                        HttpContext.Current.Session["Id"] = db.Users.Where(x => x.Email == user.Email).FirstOrDefault().Id;
                        HttpContext.Current.Session["Name"] = db.Users.Where(x => x.Email == user.Email).FirstOrDefault().Name;
                        HttpContext.Current.Session["SecondName"] = db.Users.Where(x => x.Email == user.Email).FirstOrDefault().SecondName;
                        HttpContext.Current.Session["FullName"] = db.Users.Where(x => x.Email == user.Email).FirstOrDefault().FullName;
                        HttpContext.Current.Session["PhoneNumber"] = db.Users.Where(x => x.Email == user.Email).FirstOrDefault().PhoneNumber;
                        HttpContext.Current.Session["Products"] = db.Users.Where(x => x.Email == user.Email).FirstOrDefault().Products;
                        //HttpContext.Current.Session["Name"] = user.Name;
                        //HttpContext.Current.Session["SecondName"] = user.SecondName;
                        //HttpContext.Current.Session["FullName"] = user.FullName;
                        //HttpContext.Current.Session["PhoneNumber"] = user.PhoneNumber;
                        //HttpContext.Current.Session["Products"] = user.Products;
                        HttpContext.Current.Session["roleID"] = db.Users.Where(x => x.Email == user.Email).FirstOrDefault().RoleId;
                        result = "Success";
                    }
                    else
                    {
                        result = "test";
                    }
                }
                else
                {
                    result = "Invalid Password or Email";
                }
            }
            return result;
        }
    }
}
