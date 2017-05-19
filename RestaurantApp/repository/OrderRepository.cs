using RestaurantApp.data_base_configuration;
using RestaurantApp.model;
using RestaurantApp.repository.inter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.repository
{
    class OrderRepository : IOrderRepository,IDisposable
    {
        MyDBContext context;
        private bool disposed = false;

        public OrderRepository(MyDBContext context)
        {
            this.context = context;
        }

        public void InsertOrder(Order newOrder)
        {
            context.Orders.Add(newOrder);
            this.Save();
        }

        public void RemoveUserFieldByUserId(int id)
        {
            var listToRemove = from order in context.Orders where order.User.IdUser == id select order;
            if (listToRemove.Count() != 0)
                foreach (Order o in listToRemove)
                    o.User = null;
            this.Save();
        }

        public List<Order> FindOrdersByUserId(int id)
        {
            var userOrder = from order in context.Orders where order.User.IdUser == id select order;
            if (userOrder.Count() != 0)
                return userOrder.ToList();
            return null;
        }

        public void ChangeStatusById(int id,string status)
        {
            var orders = from order in context.Orders where order.IdOrder == id select order;
            if (orders.Count() != 0)
            {
                orders.First().Status = status;
                if (status.Equals("COMPLETED"))
                {
                    orders.First().Table = null;
                    this.Save();
                }
            }
        }

        private void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
