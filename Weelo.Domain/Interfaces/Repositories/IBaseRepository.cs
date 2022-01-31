using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity>
        : ICreate<TEntity>, IUpdate<TEntity>, IRead<TEntity>, ITransactional<TEntity>
    {

    }
}
