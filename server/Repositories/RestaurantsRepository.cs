using help_reviews.Interfaces;

namespace help_reviews.Repositories;

public class RestaurantsRepository : IRepository<Restaurant>
{
  private readonly IDbConnection _db;

  public RestaurantsRepository(IDbConnection db)
  {
    _db = db;
  }

  public Restaurant Create(Restaurant data)
  {
    throw new NotImplementedException();
  }


  public void Destroy(int id)
  {
    throw new NotImplementedException();
  }

  public List<Restaurant> GetAll()
  {
    throw new NotImplementedException();
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