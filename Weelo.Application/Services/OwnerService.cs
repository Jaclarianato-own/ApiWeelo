using Weelo.Application.Interfaces;
using Weelo.Domain;
using Weelo.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Application.Services
{
    //Autor: Jhonatan Clariana
    public class OwnerService : IBaseService<Owner>
    {
        //Declaring interface ownerRepository
        private readonly IBaseRepository<Owner> ownerRepository;

        //
        //Review:
        //      dependency injection.
        //Parameters:
        // _ownerRepository:
        //      Interface that contains database configuration methods.
        public OwnerService(IBaseRepository<Owner> _ownerRepository)
        {
            ownerRepository = _ownerRepository;
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
            if (null == owner)
                throw new ArgumentNullException("The property is required");

            var result = ownerRepository.Create(owner);
            ownerRepository.SaveChanges();

            return result;
        }

        //
        //Review:
        //  List all owners.
        //Return:
        // return a list of objects of Owner.
        public List<Owner> ListAll()
        {
            return ownerRepository.ListAll();
        }

        public List<Owner> ListWithFilters(Owner entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Owner entity)
        {
            throw new NotImplementedException();
        }
    }
}
