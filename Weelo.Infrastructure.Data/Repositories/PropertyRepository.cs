using Weelo.Domain;
using Weelo.Domain.Interfaces.Repositories;
using Weelo.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.DTO;

namespace Weelo.Infrastructure.Data.Repositories
{
    //Autor: Jhonatan Clariana
    public class PropertyRepository : IBaseRepository<Property>
    {
        //Declaring propertyContext
        private PropertyContext db;

        //
        //Review:
        //      dependency injection.
        //Parameters:
        // PropertyContext:
        //      Context to work with database.
        public PropertyRepository(PropertyContext _db)
        {
            db = _db;
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
            property = setGuids(property);

            db.properties.Add(property);

            return property;
        }

        //
        //Review:
        //  Set all the Guids.
        //Parameters:
        // Property:
        //  Property object to create.
        //Return:
        // return an object property.
        private Property setGuids(Property property)
        {
            property.idProperty = Guid.NewGuid();

            if (null != property.owner)
            {
                if (property.owner.IdOwner == Guid.Empty)
                {
                    property.owner.IdOwner = property.idOwner = Guid.NewGuid();
                }
                else
                {
                    property.idOwner = property.owner.IdOwner;
                }
            }

            if (null != property.propertyImages)
            {
                property.propertyImages.ForEach(image =>
                {
                    image.idPropertyImage = Guid.NewGuid();
                    image.idProperty = property.idProperty;
                });
            }

            if (null != property.propertyTraces)
            {
                property.propertyTraces.ForEach(trace =>
                {
                    trace.idPropertyTrace = Guid.NewGuid();
                    trace.idProperty = property.idProperty;

                });
            }

            return property;
        }

        //
        //Review:
        //  List all properties.
        //Return:
        // return a list of objects of Property.
        public List<Property> ListAll()
        {
            var properties = db.properties.Include(c => c.owner).ToList();

            foreach (var p in properties)
            {
                p.owner.properties.Clear();
            }

            return properties;
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
            var properties = db.properties
                .Where(x =>

                (!string.IsNullOrEmpty(filter.nameProperty) && x.nombre.Contains(filter.nameProperty)) ||
                (!string.IsNullOrEmpty(filter.address) && x.address.Contains(filter.address)) ||
                (!string.IsNullOrEmpty(filter.codeInternal) && x.codeInternal.Contains(filter.codeInternal)) ||
                (x.price < filter.maxPrice && x.price > filter.minPrice) ||
                (x.year < filter.maxYear && x.year > filter.minYear)

            ).ToList();


            return properties;
        }

        //
        //Review:
        //   Save the changes in database.
        public void SaveChanges()
        {
            db.SaveChanges();
        }

        //
        //Review:
        //  Update a Property.
        //Parameters:
        // property:
        //  Property object to update.
        public void Update(Property property)
        {
            var selectedProperty = db.properties.Where(x => x.idProperty == property.idProperty).FirstOrDefault();

            if (null != selectedProperty)
            {
                selectedProperty.nombre = null != property.nombre ? property.nombre : selectedProperty.nombre;
                selectedProperty.price = 0 != property.price ? property.price : selectedProperty.price;
                selectedProperty.year = 0 != property.year ? property.year : selectedProperty.year;
                selectedProperty.address = null != property.address ? property.address : selectedProperty.address;
                selectedProperty.codeInternal = null != property.codeInternal ? property.codeInternal : selectedProperty.codeInternal;

                db.Entry(selectedProperty).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                throw new ArgumentException($"The idProperty: {property.idProperty} don't exists");
            }
        }

        //
        //Review:
        //  Update the price of Property.
        //Parameters:
        // Property
        //  Property object to create.
        public void UpdatePrice(Property property)
        {
            var selectedProperty = db.properties.Where(x => x.idProperty == property.idProperty).FirstOrDefault();

            if (null != selectedProperty)
            {
                selectedProperty.price = property.price;

                db.Entry(selectedProperty).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }
    }
}
