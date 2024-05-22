namespace help_reviews.Models;

public class Restaurant : RepoItem<int>
{
  public string Name { get; set; }
  public string ImgUrl { get; set; }
  public int Visits { get; set; }
  public bool IsShutdown { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }

}