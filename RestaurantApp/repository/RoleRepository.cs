using RestaurantApp.data_base_configuration;
using RestaurantApp.model;
using RestaurantApp.repository.inter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RestaurantApp.model.Role;

namespace RestaurantApp.repository
{
    class RoleRepository:IDisposable,IRoleRepository
    {

        MyDBContext context;
        private bool disposed = false;

        public RoleRepository(MyDBContext context)
        {
            this.context = context;
        }
       

        public void InsertRole(Role role)
        {
            context.Roles.Add(role);
            this.Save();
            context.Database.Connection.Close();
        }

        public Role FindRoleByGrade(Grade Grade)
        {
            string GradeAsString;
            switch (Grade)
            {
                case Grade.ADMIN: { GradeAsString = "ADMIN"; break; }
                case Grade.USER: { GradeAsString = "USER"; break; }
                default: GradeAsString = "USER"; break;
            }

            var roleToGet = from role in context.Roles where role.Authority == GradeAsString select role;
            return roleToGet.First();
        }

        public int Count()
        {
            return context.Roles.Count();
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
