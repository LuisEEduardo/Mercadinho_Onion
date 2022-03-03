using System;

namespace Mercearia.Models.SharedContext
{
    public abstract class Base
    {
        public Base()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}