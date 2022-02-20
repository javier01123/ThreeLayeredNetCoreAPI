using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.BLL.Services.Users.RegisterUser
{
    public class RegisterUserRes
    {

        public RegisterUserRes(int id, string username)
        {
            Id = id;
            Username = username;
        }
        public int Id { get; set; }
        public string Username { get; set; }
    }
}
