using Indigo99.Data;
using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo99.BusinessServices
{
    public class AdminUserManagementService : IAdminUserManagementService
    {
        private AdminUserRepository _AdminUserRepository;

        public AdminUserManagementService(AdminUserRepository adminUserRepository)
        {
            _AdminUserRepository = adminUserRepository;
        }
        
        public void Enroll(AdminUser newAdminUser)
        {
            _AdminUserRepository.Create(newAdminUser);
        }

        public bool CheckAdminUserExist(string email)
        { 
           return _AdminUserRepository.GetAdminUserByEmail(email) != null;
        }




    }
}
