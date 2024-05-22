using help_reviews.Interfaces;

namespace help_reviews.Repositories;

public class RestaurantsRepository : IRepository<Restaurant>
{
  private readonly IDbConnection _db;

  public RestaurantsRepository(IDbConnection db)
  {
    _db = db;
  }

  private Restaurant PopulateCreator(Restaurant restaurant, Profile creator)
  {
    restaurant.Creator = creator;
    return restaurant;
  }

  public Restaurant Create(Restaurant data)
  {
    string sql = @"
    INSERT INTO
    restaurants(name, description, isShutdown, creatorId, imgUrl)
    VALUES(@Name, @Description, @IsShutdown, @CreatorId, @ImgUrl);

    SELECT
    restaurants.*,
    accounts.*
    FROM restaurants
    JOIN accounts ON accounts.id = restaurants.creatorId
    WHERE restaurants.id = LAST_INSERT_ID();";

    Restaurant restaurant = _db.Query<Restaurant, Profile, Restaurant>(sql, PopulateCreator, data).FirstOrDefault();

    return restaurant;
  }


  public void Destroy(int id)
  {
    throw new NotImplementedException();
  }

  public List<Restaurant> GetAll()
  {
    string sql = @"
    SELECT
    restaurants.*,
    accounts.*
    FROM restaurants
    JOIN accounts ON accounts.id = restaurants.creatorId;";

    List<Restaurant> restaurants = _db.Query<Restaurant, Profile, Restaurant>(sql, PopulateCreator).ToList();

    return restaurants;
  }

  public Restaurant GetById(int id)
  {
    throw new NotImplementedException();
  }

  public Restaurant Update(Restaurant data)
  {
    throw new NotImplementedException();
  }
}