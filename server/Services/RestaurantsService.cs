



using Microsoft.AspNetCore.Http.HttpResults;

namespace help_reviews.Services;

public class RestaurantsService
{
  private readonly RestaurantsRepository _repository;

  public RestaurantsService(RestaurantsRepository repository)
  {
    _repository = repository;
  }

  internal Restaurant CreateRestaurant(Restaurant restaurantData)
  {
    Restaurant restaurant = _repository.Create(restaurantData);
    return restaurant;
  }

  internal List<Restaurant> GetAllRestaurants()
  {
    List<Restaurant> restaurants = _repository.GetAll();
    return restaurants;
  }

  internal Restaurant GetRestaurantById(int restaurantId)
  {
    Restaurant restaurant = _repository.GetById(restaurantId);
    if (restaurant == null)
    {
      throw new Exception($"Invalid id: {restaurantId}");
    }
    return restaurant;
  }

  internal Restaurant UpdateRestaurant(Restaurant restaurantData, int restaurantId, string userId)
  {
    Restaurant restaurantToUpdate = GetRestaurantById(restaurantId);

    if (restaurantToUpdate.CreatorId != userId)
    {
      throw new Exception("NOT YOUR RESTAURANT!");
    }

    restaurantToUpdate.IsShutdown = restaurantData.IsShutdown ?? restaurantToUpdate.IsShutdown;
    restaurantToUpdate.Description = restaurantData.Description ?? restaurantToUpdate.Description;

    Restaurant updatedRestaurant = _repository.Update(restaurantToUpdate);

    return updatedRestaurant;
  }
}
