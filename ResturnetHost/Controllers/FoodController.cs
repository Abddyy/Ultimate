using Microsoft.AspNetCore.Mvc;
using Restaurant.Contracts;

namespace Restaurant.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;
        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet("food")]
        public ActionResult<IEnumerable<FoodItemDto>> GetFood()
        {
            var foodDtos = _foodService.GetFoodItems();
            return Ok(foodDtos);
        }

        [HttpPost("food")]
        public IActionResult AddFood(AddFoodDto foodItemDto)
        {
            _foodService.AddFoodItem(foodItemDto);
            return Ok(foodItemDto);
        }

        [HttpDelete("food/{id}")]
        public IActionResult DeleteFood(int id)
        {
            var result = _foodService.DeleteFoodItem(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound(new { Message = $"Food item with id '{id}' is not found." });
        }

        [HttpPut("food/{id}")]
        public IActionResult UpdateFood(int id, UpdateFoodDto updatedFoodItemDto)
        {
            var result = _foodService.UpdateFoodItem(id, updatedFoodItemDto);
            if (result)
            {
                return Ok(updatedFoodItemDto);
            }
            return NotFound(new { Message = $"Food item with id '{id}' is not found." });
        }

    }
}
