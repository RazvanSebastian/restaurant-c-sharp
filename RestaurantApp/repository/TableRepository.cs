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
    class TableRepository : IDisposable,ITableRepository
    {

        private bool disposed = false; // To detect redundant calls
        MyDBContext context;

        public TableRepository(MyDBContext context)
        {
            this.context = context;
        }

        public List<Table> FindOnlyFreeTables()
        {
            var freeTableList = from table in context.Tables where table.Status == "FREE" select table;
            if(freeTableList.Count()!=0)
                 return freeTableList.ToList();
            return null;
        }

        public void UpdateTableStatusById(int id, String status) {
            {
                var tableToFind = from table in context.Tables where id == table.IdTable select table;
                if (tableToFind.Count() != 0)
                {
                    tableToFind.First().Status = status;
                    this.Save();
                }
            }

        }

        private void Save()
        {
            this.context.SaveChanges();
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

    
        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
             GC.SuppressFinalize(this);
        }
    }
}
