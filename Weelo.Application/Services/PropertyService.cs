using Weelo.Application.Interfaces;
using Weelo.Domain;
using Weelo.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Infrastructure.Data.Repositories;
using Weelo.DTO;

namespace Weelo.Application.Services
{
    //Autor: Jhonatan Clariana
    public class PropertyService : IBaseService<Property>
    {
        //Declaring interface propertyRepository
        private readonly IBaseRepository<Property> iPropertyRepository;

        //Declaring ownerRepository
        private readonly PropertyRepository propertyRepository;

        //
        //Review:
        //      dependency injection.
        //Parameters:
        // _iPropertyRepository:
        //      Interface that contains database configuration methods.
        public PropertyService(IBaseRepository<Property> _iPropertyRepository)
        {
            iPropertyRepository = _iPropertyRepository;
            propertyRepository = (PropertyRepository)_iPropertyRepository;
        }

        //
        //Review:
        //  Create a new property.
        //Parameters:
        // Property:
        //  Property object to create.
        //Return:
        // return an object property.
        public Property Create(Property property)
        {
            if (null == property)
                throw new ArgumentNullException("The property is required");

            validatePriceGreaterZero(property);
            validateYearGreaterZero(property);

            var result = iPropertyRepository.Create(property);

            iPropertyRepository.SaveChanges();

            return result;
        }

        //
        //Review:
        //  List all properties.
        //Return:
        // return a list of objects of Property.
        public List<Property> ListAll()
        {
            return iPropertyRepository.ListAll();
        }

        //
        //Review:
        //   List properties according filters.
        //Parameters:
        // FilterDto:
        //  Property object to create.
        //Return:
        // retrun a list of objects of Property.
        public List<Property> ListWithFilters(FilterDto filter)
        {
            if (null == filter)
                throw new ArgumentNullException("The property is required");

            var result = propertyRepository.ListWithFilters(filter);

            return result;
        }

        //
        //Review:
        //  Update a Property.
        //Parameters:
        // property:
        //  Property object to update.
        public void Update(Property property)
        {
            if (null == property)
                throw new ArgumentNullException("The property is required");

            validatePriceGreaterZero(property);
            validateYearGreaterZero(property);

            iPropertyRepository.Update(property);
            iPropertyRepository.SaveChanges();
        }

        //
        //Review:
        //  Update the price of Property.
        //Parameters:
        // Property
        //  Property object to create.
        public void UpdatePrice(Property property)
        {
            validatePriceGreaterZero(property);
            validateYearGreaterZero(property);

            propertyRepository.UpdatePrice(property);
            propertyRepository.SaveChanges();
        }

        //
        //Review:
        //  Validate if the inserted price is greater than zero.
        //Parameters:
        // Property:
        //  Property object that contain the price.
        private void validatePriceGreaterZero(Property property)
        {
            if (property.price < 0)
                throw new ArgumentException("price must be greater than zero");
        }

        //
        //Review:
        //  Validate if the inserted year is greater than zero.
        //Parameters:
        // Property:
        //  Property object that contain the year.
        private void validateYearGreaterZero(Property property)
        {
            if (property.year < 0)
                throw new ArgumentException("price must be greater than zero");
        }
    }
}
