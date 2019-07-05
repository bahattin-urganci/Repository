using PawPos.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.Domain
{
    [WillBeMap("User")]
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; }
        public string ActiveCompanyId { get; set; }
        public string GroupId { get; set; }
        public List<string> Roles { get; set; }
        public List<string> AuthorizedCompanies { get; set; }
    }


}
