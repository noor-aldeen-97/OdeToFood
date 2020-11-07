using OdeToFood.Core;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        //IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantByName(string name);
        Restaurant GetRestaurantById(int Id);
        Restaurant Update(Restaurant restaurant);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int Id);
        int GetCountOfRestaurants();
        int Commit();
    }
}
