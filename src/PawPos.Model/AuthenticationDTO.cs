using PawPos.Model.User;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace PawPos.Model
{
    public class AuthenticationDTO
    {
        public UserDTO User { get; set; }
        public List<Claim> Claims { get; set; }
    }
}
