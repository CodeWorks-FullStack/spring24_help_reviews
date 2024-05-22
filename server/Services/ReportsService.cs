

namespace help_reviews.Services;

public class ReportsService
{
  private readonly ReportsRepository _repository;
  private readonly RestaurantsService _restaurantsService;

  public ReportsService(ReportsRepository repository, RestaurantsService restaurantsService)
  {
    _repository = repository;
    _restaurantsService = restaurantsService;
  }

  internal Report CreateReport(Report reportData)
  {
    Restaurant restaurant = _restaurantsService.GetRestaurantById(reportData.RestaurantId, reportData.CreatorId);

    if (reportData.CreatorId == restaurant.CreatorId)
    {
      throw new Exception($"Hey there {restaurant.Creator.Name}, you can't leave a report for {restaurant.Name}, because you own it! That is a conflict of interest");
    }

    Report report = _repository.Create(reportData);
    return report;
  }

  internal List<Report> GetReportsByRestaurantId(int restaurantId, string userId)
  {
    // We just care about running the checks in the other service for this request
    _restaurantsService.GetRestaurantById(restaurantId, userId);


    List<Report> reports = _repository.GetReportsByRestaurantId(restaurantId);
    return reports;
  }
}
