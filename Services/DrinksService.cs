using System;
using System.Collections.Generic;
using System.Linq;
using BurgerShack.Data;
using BurgerShack.Models;

namespace BurgerShack.Services
{
    public class DrinksService
    {
        private readonly FakeDb _repo;

        public Drink AddDrink(Drink drinkData)
        {
            var exists = _repo.Drinks.Find(d => d.Name == drinkData.Name);
            if (exists != null)
            {
                throw new Exception("This drink already exists.");
            }
            drinkData.Id = Guid.NewGuid().ToString();
            _repo.Drinks.Add(drinkData);
            return drinkData;
        }

        public Drink EditDrink(Drink drinkData)
        {
            var drink = _repo.Drinks.Find(d => d.Id == drinkData.Id);
            if (drink == null) { throw new Exception("I DONT LIKE BAD ID's"); }
            drink.Name = drinkData.Name;
            drink.Size = drinkData.Size;
            //drink.Description = sideData.Description;
            //drink.Price = drinkData.Price;
            return drink;
        }

        public Drink DeleteDrink(string id)
        {
            var drink = _repo.Drinks.Find(d => d.Id == id);
            if (drink == null) { throw new Exception("I DONT LIKE BAD ID's"); }
            _repo.Drinks.Remove(drink);
            return drink;
        }

        public List<Drink> GetDrinks()
        {
            return _repo.Drinks;
        }

        public DrinksService(FakeDb repo)
        {
            _repo = repo;
        }
    }
}