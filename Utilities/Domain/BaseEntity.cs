namespace Utilities.Domain
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public bool IsActive { get; set; }

        public void InitializeBase()
        {
            Created = DateTime.Now;
            IsActive = true;
        }
    }
}
