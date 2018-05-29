using System;
using System.Collections.Generic;

namespace Services
{
    public interface IServiceResult<TEntity>
        where TEntity : class
    {
        bool IsSucceeded { get; }
        bool IsExists { get; }

        int Count { get; }

        IList<TEntity> Entities { get; }

        TEntity Entity { get; }

        Exception Exception { get; }
    }
}
