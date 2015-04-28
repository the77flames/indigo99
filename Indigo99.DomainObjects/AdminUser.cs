﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo99.DomainObjects
{
    public class AdminUser : MongoEntity, IPerson
    {
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public string Email { get; set; }        
        public DateTime CreatedDate { get; set; }
    }
}
