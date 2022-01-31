using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Domain.Interfaces;

namespace Weelo.Application.Interfaces
{
    //Autor: Jhonatan Clariana
    interface IBaseService<TEntity>
        :ICreate<TEntity>,IUpdate<TEntity>, IRead<TEntity>
    {

    }
}
