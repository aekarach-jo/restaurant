using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using restertaunt.Models;
using restertaunt.Services;

namespace restertaunt.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private FoodService _foodService;
        public FoodController(FoodService foodService)
        {
            _foodService = foodService;
        }

    [HttpPost]
    public ActionResult<Food> CreateFood(Food food)
    {
        var data = _foodService.GetAllForApi();
        var num = data.Count();
        var id = "F0" + num.ToString();
        food.Food_id = id;
        food.Status = true;
        food.Amount = 0;
        _foodService.CreateFood(food);
        return food;
    }

    [HttpGet]
    public ActionResult<List<Food>> GetFoodAll() => _foodService.GetFoodAll();

    [HttpGet("{id}")]
    public ActionResult<Food> GetFoodById(string id)
    {
        var data = _foodService.GetFoodById(id);
        if ( data == null ){
            return NotFound();
        }
        return data;
    }

    [HttpPut("{id}")]
    public ActionResult<Food> EditFood(string id, [FromBody] Food food)
    {
        var data = _foodService.GetFoodById(id);
        if (data == null)
        {
            return NotFound();
        }
        food.Food_id = data.Food_id;
        _foodService.UpdateFood(id, food);
        return food;
    }
}
}