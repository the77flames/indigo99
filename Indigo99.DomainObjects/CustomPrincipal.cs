using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Indigo99.DomainObjects;

namespace Indigo99.DomainObjects
{
    public class CustomPrincipal : GenericPrincipal
    {
        public CustomPrincipal(IIdentity identity, string[] roles)
                : base(identity, roles)
        {
        }

        public IPerson Customer { get; set; }
        
    }
}