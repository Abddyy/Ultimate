using Microsoft.AspNetCore.Mvc;
using Restaurant.Contracts;
namespace ResturnetHost.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrinkController : ControllerBase
    {
        private readonly IDrinkService _drinkService;
        public DrinkController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        [HttpGet("drinks")]
        public ActionResult<IEnumerable<DrinkItemDto>> GetDrinks()
        {
            var drinkDtos = _drinkService.GetDrinkItemDtos();
            return Ok(drinkDtos);
        }

        [HttpPost("drinks")]
        public IActionResult AddDrinks(AddDrinkDto drinkItemDto)
        {
            _drinkService.AddDrinkItem(drinkItemDto);
            return Ok(drinkItemDto);
        }

        [HttpDelete("drinks/{id}")]
        public IActionResult DeleteDrink(int id)
        {
            var result = _drinkService.DeleteDrinkItem(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound(new { Message = $"Drink item with id '{id}' is not found." });
        }

        [HttpPut("drinks/{id}")]
        public IActionResult UpdateDrink(int id, UpdateDrinkDto drinkItemDto)
        {
            var result = _drinkService.UpdateDrinkItem(id, drinkItemDto);
            if (result)
            {
                return Ok(drinkItemDto);
            }
            return NotFound(new { Message = $"Drink item with id '{id}' is not found." });
        }
    }
}
