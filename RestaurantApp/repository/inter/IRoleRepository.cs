using RestaurantApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RestaurantApp.model.Role;

namespace RestaurantApp.repository.inter
{
    interface IRoleRepository : IDisposable
    {
        void InsertRole(Role role);
        Role FindRoleByGrade(Grade Grade);
        int Count();
    }
}
