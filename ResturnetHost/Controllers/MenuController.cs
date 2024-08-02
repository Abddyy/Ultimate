using Microsoft.AspNetCore.Mvc;
using Restaurant.Contracts;
using System.Collections.Generic;

namespace Restaurant.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IFoodService _foodService;
        private readonly IDrinkService _drinkService;

        public MenuController(IFoodService foodService, IDrinkService drinkService)
        {
            _foodService = foodService;
            _drinkService = drinkService;
        }

        [HttpGet("food")]
        public ActionResult<IEnumerable<FoodItemDto>> GetFood()
        {
            var foodDtos = _foodService.GetFoodItems();
            return Ok(foodDtos);
        }

        [HttpGet("drinks")]
        public ActionResult<IEnumerable<DrinkItemDto>> GetDrinks()
        {
            var drinkDtos = _drinkService.GetDrinkItemDtos();
            return Ok(drinkDtos);
        }

        [HttpPost("food")]
        public IActionResult AddFood(AddFoodDto foodItemDto)
        {
            _foodService.AddFoodItem(foodItemDto);
            return Ok(foodItemDto); // Return the created item directly
        }

        [HttpPost("drinks")]
        public IActionResult AddDrinks(AddDrinkDto drinkItemDto)
        {
            _drinkService.AddDrinkItem(drinkItemDto);
            return Ok(drinkItemDto); // Return the created item directly
        }

        [HttpDelete("food/{name}")]
        public IActionResult DeleteFood(string name)
        {
            var result = _foodService.DeleteFoodItem(name);
            if (result)
            {
                return NoContent(); // Return 204 No Content
            }
            return NotFound(new { Message = $"Food item with name '{name}' is not found." });
        }

        [HttpDelete("drinks/{name}")]
        public IActionResult DeleteDrink(string name)
        {
            var result = _drinkService.DeleteDrinkItem(name);
            if (result)
            {
                return NoContent();
            }
            return NotFound(new { Message = $"Drink item with name '{name}' is not found." });
        }

        [HttpPut("food/{name}")]
        public IActionResult UpdateFood(string name, UpdateFoodDto updatedFoodItemDto)
        {
            var result = _foodService.UpdateFoodItem(name, updatedFoodItemDto);
            if (result)
            {
                return Ok(updatedFoodItemDto);
            }
            return NotFound(new { Message = $"Food item with name '{name}' is not found." });
        }

        [HttpPut("drinks/{name}")]
        public IActionResult UpdateDrink(string name, UpdateDrinkDto drinkItemDto)
        {
            var result = _drinkService.UpdateDrinkItem(name, drinkItemDto);
            if (result)
            {
                return Ok(drinkItemDto); // Return the updated item directly
            }
            return NotFound(new { Message = $"Drink item with name '{name}' is not found." });
        }
    }
}
