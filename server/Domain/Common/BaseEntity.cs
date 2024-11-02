namespace Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; }  
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime ModifiedAt { get; set; } = DateTime.Now;
}