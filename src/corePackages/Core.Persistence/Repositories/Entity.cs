namespace Core.Persistence.Repositories;

public class Entity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
}