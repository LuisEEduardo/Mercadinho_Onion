using Mercadinho.Domain.Repositories;
using System;

namespace Mercearia.Models.SharedContext
{
    public abstract class Base : IEntity
    {
        public Base()
        {
            
        }

        public int Id { get; set; }
    }
}