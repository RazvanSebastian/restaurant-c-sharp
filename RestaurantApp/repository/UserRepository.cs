using RestaurantApp.data_base_configuration;
using RestaurantApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.repository
{
    class UserRepository : IUserRepository, IDisposable
    {

        MyDBContext context;
        private bool disposed = false;

        public UserRepository(MyDBContext context)
        {
            this.context = context;
        }

        public void InsertUser(User user)
        {
            context.Users.Add(user);
            this.Save();
        }

        public User FindByUserName(String userName)
        {
            var userSearched = from user in context.Users where user.UserName == userName select user;
            if (userSearched.Count() != 0)
                return userSearched.First();
            else
                return null;     
        }

        public int Count()
        {
            return context.Users.Count();
        }

        public List<User> FindAll()
        {
            var userList = from user in context.Users select user;
            return userList.ToList();
        }

        public void UpdateUserByUserUpdated(User userUpdated)
        {
            var userToUpdate=from user in context.Users where user.IdUser == userUpdated.IdUser select user;
            if (userToUpdate.Count() != 0)
            {
                userToUpdate.First().UserName = userUpdated.UserName;
                userToUpdate.First().LastName = userUpdated.LastName;
                userToUpdate.First().FirstName = userUpdated.FirstName;
                userToUpdate.First().Password = userUpdated.Password;
                this.Save();
            }
        }

        public void DeleteUserById(int Id)
        {
            var userToDelete = from user in context.Users where user.IdUser == Id select user;
            if (userToDelete.Count() != 0)
            {
                context.Users.Remove(userToDelete.First());
                this.Save();
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
