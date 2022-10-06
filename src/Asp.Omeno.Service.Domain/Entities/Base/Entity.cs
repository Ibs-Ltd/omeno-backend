using System;

namespace Asp.Omeno.Service.Domain.Entities.Base
{
    public class Entity<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public bool Status { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
