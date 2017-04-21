using RestaurantApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.repository.inter
{
    interface IFoodStuffRepository : IDisposable
    {
        void InserFoodStuff(FoodStuff newFood);
        List<FoodStuff> FindAll();
        void UpdateFoodStuff(FoodStuff foodUpdated);
        void DeleteById(int id);
    }
}
