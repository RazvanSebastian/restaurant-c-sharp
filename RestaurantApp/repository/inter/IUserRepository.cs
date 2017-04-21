using RestaurantApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RestaurantApp.model.Role;

namespace RestaurantApp.repository
{
    interface IUserRepository : IDisposable
    {      
        int Count();
        User FindByUserName(String userName);
        List<User> FindAll();
        void UpdateUserByUserUpdated(User userUpdated);
        void InsertUser(User user);
        void DeleteUserById(int Id);
    }
}
