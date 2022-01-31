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
    //Autor: Jhonatan Clariana
    public class PropertyImageRepository : IBaseRepository<PropertyImage>
    {
        //Declaring propertyContext
        private PropertyContext db;

        //
        //Review:
        //      dependency injection.
        //Parameters:
        // PropertyContext:
        //      Context to work with database.
        public PropertyImageRepository(PropertyContext _db)
        {
            db = _db;
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
            propertyImage.idPropertyImage = Guid.NewGuid();
            var b = db.propertyImages.Add(propertyImage);
            return propertyImage;
        }

        //
        //Review:
        //  List all property images.
        //Return:
        // return a list of objects of PropertyImage.
        public List<PropertyImage> ListAll()
        {
            return db.propertyImages.ToList();
        }

        public List<PropertyImage> ListWithFilters(PropertyImage entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(PropertyImage entity)
        {
            throw new NotImplementedException();
        }
    }
}
