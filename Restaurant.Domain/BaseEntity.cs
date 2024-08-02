public abstract class BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int? DeleteAt { get; set; } = null;
    public bool IsDeleted { get; private set; } = false;
    public DateTime CreationTime { get; set; } = DateTime.Now;
    public DateTime? DeletedTime { get; private set; } = null;

    public void MarkAsDeleted()
    {
        this.DeleteAt = null;
        this.IsDeleted = true;
        this.DeletedTime = DateTime.Now;
    }

}