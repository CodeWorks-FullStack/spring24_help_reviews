using help_reviews.Interfaces;

namespace help_reviews.Repositories;

public class ReportsRepository : IRepository<Report>
{
  private readonly IDbConnection _db;

  public ReportsRepository(IDbConnection db)
  {
    _db = db;
  }

  private Report PopulateCreator(Report report, Profile creator)
  {
    report.Creator = creator;
    return report;
  }

  public Report Create(Report data)
  {
    string sql = @"
    INSERT INTO
    reports(title, body, restaurantId, creatorId, imgUrl)
    VALUES(@Title, @Body, @RestaurantId, @CreatorId, @ImgUrl);

    SELECT
    reports.*,
    accounts.*
    FROM reports
    JOIN accounts ON accounts.id = reports.creatorId
    WHERE reports.id = LAST_INSERT_ID();";

    Report report = _db.Query<Report, Profile, Report>(sql, PopulateCreator, data).FirstOrDefault();

    return report;
  }

  public void Destroy(int id)
  {
    throw new NotImplementedException();
  }

  public List<Report> GetAll()
  {
    throw new NotImplementedException();
  }

  public Report GetById(int id)
  {
    throw new NotImplementedException();
  }

  public Report Update(Report data)
  {
    throw new NotImplementedException();
  }

  internal List<Report> GetReportsByRestaurantId(int restaurantId)
  {
    string sql = @"
    SELECT
    reports.*,
    accounts.*
    FROM reports
    JOIN accounts ON accounts.id = reports.creatorId
    WHERE reports.restaurantId = @restaurantId
    ORDER BY reports.createdAt;";

    List<Report> reports = _db.Query<Report, Profile, Report>(sql, PopulateCreator, new { restaurantId }).ToList();

    return reports;
  }
}