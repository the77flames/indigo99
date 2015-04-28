using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indigo99.DomainObjects;

namespace Indigo99.BusinessServices
{
    public interface IAuthenticationService
    {
        bool Authenticate(string UserName, string Password, bool IsAdmin = false);
    }
}
