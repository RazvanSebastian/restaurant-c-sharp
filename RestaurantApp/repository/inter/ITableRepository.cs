using RestaurantApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.repository.inter
{
    interface ITableRepository : IDisposable
    {
        List<Table> FindOnlyFreeTables();
        void UpdateTableStatusById(int id, String status);
    }
}
