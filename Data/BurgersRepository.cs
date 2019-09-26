using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Data
{
    public class BurgersRespository
    {
        private readonly IDbConnection _db;

        public Burger Create(Burger burgerData)
        {

            var sql = @"INSERT INTO burgers
            (id, name, description, price)
            VALUES
            (@Id, @Name, @Description, @Price);";

            _db.Execute(sql, burgerData);
            return burgerData;
        }

        public BurgersRespository(IDbConnection db)
        {
            _db = db;
        }
    }
}