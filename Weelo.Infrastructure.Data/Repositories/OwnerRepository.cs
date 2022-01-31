using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Domain;
using Weelo.Domain.Interfaces.Repositories;
using Weelo.Infrastructure.Data.Contexts;

namespace Weelo.Infrastructure.Data.Repositories
{
    //Autor: Jhonatan Clariana
    public class OwnerRepository : IBaseRepository<Owner>
    {
        //Declaring propertyContext
        private PropertyContext db;

        //
        //Review:
        //      dependency injection.
        //Parameters:
        // PropertyContext:
        //      Context to work with database.
        public OwnerRepository(PropertyContext _propertyContext)
        {
            db = _propertyContext;
        }

        //
        //Review:
        //      Create a new owner.
        //Parameters:
        // Owner:
        //      Property object to create.
        //Return:
        //  Owner:
        //      return an object property.
        public Owner Create(Owner owner)
        {
            owner.IdOwner = Guid.NewGuid();
            db.owners.Add(owner);
            return owner;
        }

        //
        //Review:
        //  List all owners.
        //Return:
        // return a list of objects of Owner.
        public List<Owner> ListAll()
        {
            return db.owners.ToList();
        }

        public List<Owner> ListWithFilters(Owner entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(Owner entity)
        {
            throw new NotImplementedException();
        }
    }
}
