using System;

namespace NRInvest.Domain.Entities
{
    public abstract class Entity
    {
        public Entity()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}