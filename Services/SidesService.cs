using System;
using System.Collections.Generic;
using System.Linq;
using BurgerShack.Data;
using BurgerShack.Models;

namespace BurgerShack.Services
{
    public class SidesService
    {
        private readonly FakeDb _repo;

        public Side AddSide(Side sideData)
        {
            var exists = _repo.Sides.Find(b => b.Name == sideData.Name);
            if (exists != null)
            {
                throw new Exception("This side already exists.");
            }
            sideData.Id = Guid.NewGuid().ToString();
            _repo.Sides.Add(sideData);
            return sideData;
        }

        public Side EditSide(Side sideData)
        {
            var side = _repo.Sides.Find(s => s.Id == sideData.Id);
            if (side == null) { throw new Exception("I DONT LIKE BAD ID's"); }
            side.Name = sideData.Name;
            side.Description = sideData.Description;
            side.Price = sideData.Price;
            return side;
        }

        public Side DeleteSide(string id)
        {
            var side = _repo.Sides.Find(s => s.Id == id);
            if (side == null) { throw new Exception("I DONT LIKE BAD ID's"); }
            _repo.Sides.Remove(side);
            return side;
        }

        public List<Side> GetSides()
        {
            return _repo.Sides;
        }

        public SidesService(FakeDb repo)
        {
            _repo = repo;
        }
    }
}