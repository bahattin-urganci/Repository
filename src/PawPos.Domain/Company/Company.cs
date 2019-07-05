using PawPos.Infrastructure;
using PawPos.Infrastructure.Attributes;
using PawPos.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static PawPos.Model.Types;

namespace PawPos.Domain.Company
{
    [WillBeMap("Company")]
    public class Company : BaseEntity
    {        
        public string Name { get; set; }
        public string ParentId { get; set; }
        public CompanySettings CompanySettings { get; set; }
    }

    
}
