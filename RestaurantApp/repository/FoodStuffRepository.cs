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
    class FoodStuffRepository : IDisposable,IFoodStuffRepository
    {
        MyDBContext context;
        private bool disposed = false;

        public FoodStuffRepository(MyDBContext contex)
        {
            this.context = contex;
        }

        public void InserFoodStuff(FoodStuff newFood)
        {
            context.FoodStuffs.Add(newFood);
            this.Save();
        }

        public List<FoodStuff> FindAll()
        {
            var foodList = from food in context.FoodStuffs select food;
            return foodList.ToList();
        }

        public void UpdateFoodStuff(FoodStuff foodUpdated)
        {
            var foodToUpdate = from food in context.FoodStuffs where food.IdFood == foodUpdated.IdFood select food;
            if (foodToUpdate.Count() != 0)
            {
                foodToUpdate.First().Name = foodUpdated.Name;
                foodToUpdate.First().Details = foodUpdated.Details;
                foodToUpdate.First().Price = foodUpdated.Price;
                foodToUpdate.First().Weigth = foodUpdated.Weigth;
                foodToUpdate.First().PreparationTime = foodUpdated.PreparationTime;
                foodToUpdate.First().ImageContent = foodUpdated.ImageContent;
                this.Save();
            }           
        }

        public void DeleteById(int id)
        {
            var foodToDelete = from food in context.FoodStuffs where food.IdFood == id select food;
            if (foodToDelete.Count() != 0)
                context.FoodStuffs.Remove(foodToDelete.First());
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
