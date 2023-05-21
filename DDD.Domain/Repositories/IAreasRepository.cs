using DDD.Domain.Entities;
using System;
using System.Collections.Generic;

namespace DDD.Domain.Repositories
{
    public interface IAreasRepository
    {
        IReadOnlyList<AreaEntity> GetData();
    }
}
