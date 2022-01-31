using Weelo.Domain;
using Weelo.Domain.Interfaces.Repositories;
using Weelo.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Infrastructure.Data.Repositories
{
    public class UserRepository : IBaseRepository<User>
    {

        private PropertyContext db;

        public UserRepository(PropertyContext _propertyContext)
        {
            db = _propertyContext;
        }
        public User Create(User entity)
        {
            entity.idUser = Guid.NewGuid();
            var c = db.users.Add(entity);
            return entity;
        }

        public List<User> ListAll()
        {
            throw new NotImplementedException();
        }

        public List<User> ListWithFilters(User entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
