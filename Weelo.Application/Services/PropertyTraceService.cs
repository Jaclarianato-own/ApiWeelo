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
    public class PropertyTraceService : IBaseService<PropertyTrace>
    {
        //Declaring interface propertyTraceRepository
        private readonly IBaseRepository<PropertyTrace> propertyTraceRepository;

        //
        //Review:
        //  dependency injection.
        //Parameters:
        // _iPropertyTraceRepository:
        //  Interface that contains database configuration methods.
        public PropertyTraceService(IBaseRepository<PropertyTrace> _propertyTraceRepository)
        {
            propertyTraceRepository = _propertyTraceRepository;
        }

        //
        //Review:
        //  Create a new propertyTrace.
        //Parameters:
        // Property:
        //  PropertyTrace object to create.
        //Return:
        // return an object propertyTrace.
        public PropertyTrace Create(PropertyTrace propertyTrace)
        {
            if (null == propertyTrace)
                throw new ArgumentNullException("The property is required");

            var result = propertyTraceRepository.Create(propertyTrace);
            propertyTraceRepository.SaveChanges();

            return result;
        }

        //
        //Review:
        //  List all property trace.
        //Return:
        // return a list of objects of PropertyTrace.
        public List<PropertyTrace> ListAll()
        {
            return propertyTraceRepository.ListAll();
        }


        public List<PropertyTrace> ListWithFilters(PropertyTrace entity)
        {
            throw new NotImplementedException();
        }

        public void Update(PropertyTrace entity)
        {
            throw new NotImplementedException();
        }
    }
}
