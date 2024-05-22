namespace help_reviews.Interfaces;
// NOTE interface is a contract, whenever a type implements an interface, it must support the listed members in the definition
public interface IRepository<T>
{
  public List<T> GetAll();
  public T GetById(int id);
  public T Create(T data);
  public void Destroy(int id);
  public T Update(T data);
}