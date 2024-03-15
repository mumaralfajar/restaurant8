using restaurant.Models.DTO.Request;
using restaurant.Models.DTO.Response;
using restaurant.Models.DTO;
using restaurant.Models;
using restaurant.Services.Interfaces;
using restaurant.Data;

namespace restaurant.Services
{
    public class FoodService : IFoodService
    {
        private readonly RestaurantDbContext _context;

        public FoodService(RestaurantDbContext context)
        {
            _context = context;
        }

        public ICollection<Food> GetFoods()
        {
            try
            {
                return _context.Foods.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ResponseAPI<FoodResponse> GetDetailFood(int foodId)
        {
            try
            {
                var food = _context.Foods.FirstOrDefault(f => f.FoodId == foodId);
                if (food != null)
                {
                    return new ResponseAPI<FoodResponse>
                    {
                        Data = new FoodResponse
                        {
                            FoodId = food.FoodId,
                            FoodName = food.FoodName,
                            FoodPrice = food.FoodPrice
                        },
                        Message = "Successfully loaded food data"
                    };
                }
                else
                {
                    return new ResponseAPI<FoodResponse>
                    {
                        Message = "Food not found"
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ResponseAPI<FoodResponse> AddFood(FoodRequest request)
        {
            var newFood = new Food
            {
                FoodName = request.FoodName,
                FoodPrice = request.FoodPrice
            };

            try
            {
                _context.Foods.Add(newFood);
                _context.SaveChanges();

                return new ResponseAPI<FoodResponse>
                {
                    Data = new FoodResponse
                    {
                        FoodId = newFood.FoodId,
                        FoodName = newFood.FoodName,
                        FoodPrice = newFood.FoodPrice
                    },
                    Message = "Successfully added food data"
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ResponseAPI<FoodResponse> EditFood(int foodId, FoodRequest request)
        {
            try
            {
                var food = _context.Foods.FirstOrDefault(f => f.FoodId == foodId);
                if (food != null)
                {
                    food.FoodName = request.FoodName;
                    food.FoodPrice = request.FoodPrice;
                    _context.SaveChanges();

                    return new ResponseAPI<FoodResponse>
                    {
                        Data = new FoodResponse
                        {
                            FoodId = food.FoodId,
                            FoodName = food.FoodName,
                            FoodPrice = food.FoodPrice
                        },
                        Message = "Successfully updated food data"
                    };
                }
                else
                {
                    return new ResponseAPI<FoodResponse>
                    {
                        Message = "Food not found"
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ResponseAPI<FoodResponse> DeleteFood(int foodId)
        {
            try
            {
                var food = _context.Foods.FirstOrDefault(f => f.FoodId == foodId);
                if (food != null)
                {
                    _context.Remove(food);
                    _context.SaveChanges();

                    return new ResponseAPI<FoodResponse>
                    {
                        Message = "Successfully deleted food data"
                    };
                }
                else
                {
                    return new ResponseAPI<FoodResponse>
                    {
                        Message = "Food not found"
                    };
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
