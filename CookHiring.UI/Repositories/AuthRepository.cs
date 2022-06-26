using CookHiring.Data;
using CookHiring.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookHiring.UI.Repositories
{
    public class AuthRepository
    {
        public ApplicationDbContext dbEntities;
        public AuthRepository()
        {
            dbEntities = new ApplicationDbContext();
        }
        public User Login(LoginModel data)
        {
            User user = dbEntities.Users.Where(item=>item.email == data.Email).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            else
            {
            return user;
            }  
            
        }
        
      
        public bool Signup(User data)
        {
            if(data== null)
            {
                return false;
            }
            else
            {
                dbEntities.Users.Add(data);
                dbEntities.SaveChanges();
                return true;
            }
        }
    }
}