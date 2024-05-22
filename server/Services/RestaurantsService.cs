



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

  // NOTE overload: if you call GetRestaurantById and only supply an interger, this method runs
  // this is a private method, we are dealing with sensitive information, so this only callable by members of the service
  private Restaurant GetRestaurantById(int restaurantId)
  {
    Restaurant restaurant = _repository.GetById(restaurantId);

    if (restaurant == null)
    {
      throw new Exception($"Invalid id: {restaurantId}");
    }

    return restaurant;
  }

  // NOTE overload: if you call GetRestaurantById and supply an interger and a string, this method runs
  internal Restaurant GetRestaurantById(int restaurantId, string userId)
  {
    Restaurant restaurant = GetRestaurantById(restaurantId); // private method only accessible in this class

    if (restaurant.IsShutdown == true && restaurant.CreatorId != userId)
    {
      throw new Exception($"Invalid id: {restaurantId} 😉");
    }

    return restaurant;
  }

  internal Restaurant UpdateRestaurant(Restaurant restaurantData, int restaurantId, string userId)
  {
    Restaurant restaurantToUpdate = GetRestaurantById(restaurantId);  // private method only accessible in this class

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
