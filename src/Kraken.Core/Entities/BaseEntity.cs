﻿namespace Kraken.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            CreatedAt = DateTime.Now;
            IsDeleted = false;
        }

        public Guid? Id { get; set; }

        public DateTime CreatedAt { get; private set; }

        public bool IsDeleted { get; private set; }

        public void SetAsDeleted() => IsDeleted = true;
    }
}