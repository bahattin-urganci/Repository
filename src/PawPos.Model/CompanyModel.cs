using PawPos.Infrastructure;
using PawPos.Infrastructure.Attributes;
using PawPos.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using static PawPos.Model.Types;

namespace PawPos.Model
{
   
    public class GroupDTO :BaseDTO
    {
        public string Name { get; set; }
        public List<CompanyDTO> Companies { get; set; }
        public List<UserDTO> Users { get; set; }
        public GroupDTO()
        {
            Companies = new List<CompanyDTO>();
            Users = new List<UserDTO>();
        }

    }
    [WillBeMap("Company")]

    public class CompanyDTO : BaseDTO
    {
        public string Name { get; set; }
        public string ParentId { get; set; }
        public CompanySettings CompanySettings { get; set; }
    }


    public class CompanySettings
    {
        public CompanyDbSettings CompanyDbSettings { get; set; }
    }

    public class CompanyDbSettings
    {
        public string Database { get; set; }
        public string ConnectionString { get; set; }
    }
}
