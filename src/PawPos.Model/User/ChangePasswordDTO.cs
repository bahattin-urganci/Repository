using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.Model.User
{
    public class ChangePasswordDTO
    {
        public string UserId { get; set; }
        public string NewPassword { get; set; }
    }
}
