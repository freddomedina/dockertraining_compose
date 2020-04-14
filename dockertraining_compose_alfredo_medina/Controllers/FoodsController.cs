using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dockertraining_compose_alfredo_medina.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dockertraining_compose_alfredo_medina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly FoodContext db;

        public FoodsController(FoodContext context)
        {
            db = context;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFood(int id)
        {
            var food = await db.Foods.FindAsync(id);
            if (food == default(Food))
            {
                return NotFound();
            }
            return Ok(food);
        }

        // POST: api/Foods
        [HttpPost]
        public async Task<IActionResult> AddFood([FromBody] Food food)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await db.AddAsync(food);
            await db.SaveChangesAsync();
            return Ok(food.Id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var food = await db.Foods.FindAsync(id);
            if (food == default(Food))
            {
                return NotFound();
            }
            db.Remove(food);
            await db.SaveChangesAsync();
            return Ok(food.Id);
        }
    }
}
