namespace Smart.Finances.FinGoal.Core.Models.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; protected set; }

        public DateTime CreatedAt { get; protected set; }

        public DateTime? UpdatedAt { get; protected set; }

        public bool IsDeleted { get; protected set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            IsDeleted = false;
        }

        protected void Update()
        {
            UpdatedAt = DateTime.Now;
        }
    }
}
