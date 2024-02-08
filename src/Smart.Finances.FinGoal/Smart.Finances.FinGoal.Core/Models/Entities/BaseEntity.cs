namespace Smart.Finances.FinGoal.Core.Models.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public bool IsDeleted { get; private set; }

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
