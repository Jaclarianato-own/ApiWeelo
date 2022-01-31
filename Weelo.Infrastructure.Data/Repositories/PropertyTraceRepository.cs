using Weelo.Domain;
using Weelo.Domain.Interfaces.Repositories;
using Weelo.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Weelo.Infrastructure.Data.Repositories
{
    //Autor: Jhonatan Clariana
    public class PropertyTraceRepository : IBaseRepository<PropertyTrace>
    {
        //Declaring propertyContext
        private PropertyContext db;

        //
        //Review:
        //      dependency injection.
        //Parameters:
        // PropertyContext:
        //      Context to work with database.
        public PropertyTraceRepository(PropertyContext _db)
        {
            db = _db;
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
            propertyTrace.idPropertyTrace = Guid.NewGuid();
            db.propertyTraces.Add(propertyTrace);
            return propertyTrace;
        }

        //
        //Review:
        //  List all property trace.
        //Return:
        // return a list of objects of PropertyTrace.
        public List<PropertyTrace> ListAll()
        {
            var properties = db.propertyTraces.ToList();

            return properties;
        }

        public List<PropertyTrace> ListWithFilters(PropertyTrace entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(PropertyTrace entity)
        {
            throw new NotImplementedException();
        }
    }
}
