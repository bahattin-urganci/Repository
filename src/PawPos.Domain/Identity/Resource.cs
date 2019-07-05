using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.Domain.Identity
{
    public class Resource :BaseEntity
    {
        public IdentityResource IdentityResource { get; set; }
    }
}
