using DemoAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.BLL.Extensions.ContextExtensions
{
    public static class UsersExtensions
    {
        public static bool IsUsernameTaken(this DbSet<User> users, string username)
        {
            return users.Where(u =>
                               u.Username.Trim() == username.Trim().ToLower()
                               ).Any();           
        }
    }
}
