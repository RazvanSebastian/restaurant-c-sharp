using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.services
{
    class DataBaseSecurityService
    {
        public String HashUserPassword(String plainPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainPassword);
        }

        public Boolean checkPasswordMatching(String plainPassword, String hashPassword)
        {
           return BCrypt.Net.BCrypt.Verify(plainPassword, hashPassword);
        }
    }
}
