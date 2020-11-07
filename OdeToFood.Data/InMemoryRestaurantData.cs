﻿using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData: IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1,Name="Scott's Pizza",Location="Maryland",Cuisine=CuisineType.Italian },
                new Restaurant{Id=2,Name="Cinnamon Club",Location="London",Cuisine=CuisineType.Jordan },
                new Restaurant{Id=3,Name="La Costa",Location="California",Cuisine=CuisineType.Mexican }
            };
        }

        public Restaurant GetRestaurantById(int Id)
        {
            return restaurants.SingleOrDefault(m => m.Id == Id);
        }

        //public IEnumerable<Restaurant> GetAll()
        //{
        //    return from r in restaurants 
        //           orderby r.Name 
        //           select r;
        //}

        public IEnumerable<Restaurant> GetRestaurantByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
        public int Commit()
        {
            return 0;
        }
        public Restaurant Update(Restaurant restaurant)
        {
            var restaurntUpdate = GetRestaurantById(restaurant.Id);

            if (restaurntUpdate != null)
            {
                restaurntUpdate.Name = restaurant.Name;
                restaurntUpdate.Location = restaurant.Location;
                restaurntUpdate.Cuisine = restaurant.Cuisine;
            }

            return restaurntUpdate;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Delete(int Id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == Id);

            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }
    }
}
