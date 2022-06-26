using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CookHiring.Data;

namespace CookHiring.UI.Repositories
{
    public class UserRepository
    {
        public ApplicationDbContext dbEntities; 
        public UserRepository()
        {
            dbEntities=new ApplicationDbContext();
        }
        public List<User> GetUsers()
        {
            return dbEntities.Users.ToList();

        }
        public void AddUser(User user)
        {
            dbEntities.Users.Add(user);
            dbEntities.SaveChanges();
        }
        public void EditUser(User data)
        {
            dbEntities.Entry<User>(data).State = System.Data.Entity.EntityState.Modified;
            dbEntities.SaveChanges();

        }
        public User GetUserById(int id)
        {
            User user = dbEntities.Users.Find(id);
            return user;
        }
        public void DeleteUser(int id)
            {
            User user  =dbEntities.Users.Find(id);
            dbEntities.Users.Remove(user);
            dbEntities.SaveChanges();
        }
    }
}