using RestaurantApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.repository.inter
{
    interface IOrderRepository : IDisposable
    {
        void InsertOrder(Order newOrder);
        void RemoveUserFieldByUserId(int id);
        List<Order> FindOrdersByUserId(int id);
        void ChangeStatusById(int id, string status);
    }
}
