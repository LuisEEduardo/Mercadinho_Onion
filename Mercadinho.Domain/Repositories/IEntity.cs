using System;

namespace Mercadinho.Domain.Repositories
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
