using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurgerShack.Models;
using BurgerShack.Services;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private readonly DrinksService _dr;

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Drink>> Get()
        {
            return _dr.GetDrinks();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Drink> Post([FromBody] Drink drinkData)
        {
            try
            {
                Drink myDrink = _dr.AddDrink(drinkData);
                return Ok(myDrink);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); //code snippet
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Drink> Put(string id, [FromBody] Drink drinkData)
        {
            try
            {
                drinkData.Id = id;
                var drink = _dr.EditDrink(drinkData);
                return Ok(drinkData);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Drink> Delete(string id)
        {
            try
            {
                var drink = _dr.DeleteDrink(id);
                return Ok(drink);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public DrinksController(DrinksService dr)
        {
            _dr = dr;
        }
    }
}