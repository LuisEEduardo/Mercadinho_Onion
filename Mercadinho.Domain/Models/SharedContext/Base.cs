using Mercadinho.Domain.Repositories;
using System;

namespace Mercearia.Models.SharedContext
{
    public abstract class Base : IEntity
    {
        public Base()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}