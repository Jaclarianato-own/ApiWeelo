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
    public class PropertyImageService : IBaseService<PropertyImage>
    {
        //Declaring interface propertyImageRepository
        private readonly IBaseRepository<PropertyImage> propertyImageRepository;

        //
        //Review:
        //  dependency injection.
        //Parameters:
        // _iPropertyImageRepository:
        //  Interface that contains database configuration methods.
        public PropertyImageService(IBaseRepository<PropertyImage> _propertyImageRepository)
        {
            propertyImageRepository = _propertyImageRepository;
        }

        //
        //Review:
        //  Create a new propertyImage.
        //Parameters:
        // Property:
        //  PropertyImage object to create.
        //Return:
        // return an object propertyImage.
        public PropertyImage Create(PropertyImage propertyImage)
        {
            if (null == propertyImage)
                throw new ArgumentNullException("The property is required");

            var result = propertyImageRepository.Create(propertyImage);
            propertyImageRepository.SaveChanges();

            return result;
        }

        //
        //Review:
        //  List all property images.
        //Return:
        // return a list of objects of PropertyImage.
        public List<PropertyImage> ListAll()
        {
            return propertyImageRepository.ListAll();
        }

        public List<PropertyImage> ListWithFilters(PropertyImage entity)
        {
            throw new NotImplementedException();
        }

        public void Update(PropertyImage entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
