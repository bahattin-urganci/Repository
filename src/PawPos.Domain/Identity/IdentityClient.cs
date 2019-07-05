using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.Domain.Identity
{
    public class IdentityClient :BaseEntity
    {
        public Client Client { get; set; }
    }
}
