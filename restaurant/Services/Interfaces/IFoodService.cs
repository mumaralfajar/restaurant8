using restaurant.Models.DTO.Request;
using restaurant.Models.DTO.Response;
using restaurant.Models.DTO;
using restaurant.Models;

namespace restaurant.Services.Interfaces
{
    public interface IFoodService
    {
        ICollection<Food> GetFoods();
        ResponseAPI<FoodResponse> GetDetailFood(int foodId);
        ResponseAPI<FoodResponse> AddFood(FoodRequest request);
        ResponseAPI<FoodResponse> EditFood(int foodId, FoodRequest request);
        ResponseAPI<FoodResponse> DeleteFood(int foodId);
    }
}
