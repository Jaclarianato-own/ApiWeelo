using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Domain.Interfaces
{
    public interface IUpdate<TEntity>
    {
        void Update(TEntity entity);
    }
}
