using BurgerShack.Models;

namespace BurgerShack.Models
{

    public enum DrinkSizes
    {
        Small = 1,
        Medium,
        Large,
        XLarge
    }
    public class Drink
    {
        public string Id { get; set; }
        public string Name { get; set; }
        //public string Description { get; set; }
        private decimal _BasePrice = 1;

        public DrinkSizes Size { get; set; }

        public decimal Price
        {
            get
            {
                return _BasePrice + (decimal)Size;
            }
        }

    }
}

