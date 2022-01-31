using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Application.Services;
using Weelo.Domain;
using Weelo.DTO;
using Weelo.Infrastructure.Data.Contexts;
using Weelo.Infrastructure.Data.Repositories;

namespace Weelo.Test.ApplicationTest
{
    [TestFixture]
    public class PropertyTest
    {
        PropertyService CreateService()
        {
            PropertyContext db = new PropertyContext();
            PropertyRepository repo = new PropertyRepository(db);
            PropertyService servcie = new PropertyService(repo);

            return servcie;
        }

        Property PropertyTestDefault()
        {
            return new Property()
            {
                nombre = "nombreTest",
                address = "addressTest",
                codeInternal = "codeInternalTest",
                //Guid referenced to a owner instace test.
                idOwner = Guid.Parse("b50e292f-6ec0-4790-96f9-8d49e917c693")
            };

        }

        FilterDto FilterDtoTestDefault()
        {
            return new FilterDto()
            {
                nameProperty = "nombreTeost"
       
            };

        }

        [Test]
        public void CreateProperty_property_property()
        {
            var property = PropertyTestDefault();

            Assert.AreSame(CreateService().Create(property), property);
        }

        [Test]
        public void CreateProperty_nullProperty_throwArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => CreateService().Create(null));
        }

        [Test]
        public void CreateProperty_nullRequierdField_trowDbUpdateException()
        {
            var property = PropertyTestDefault();

            property.nombre = null;

            Assert.Throws<DbUpdateException>(() => CreateService().Create(property));
        }

        [Test]
        public void CreateProperty_idOwnerDontExist_trowDbUpdateException()
        {
            var property = PropertyTestDefault();

            property.idOwner = Guid.Parse("b50e292f-6ec0-4790-96f9-8d49e917c999");

            Assert.Throws<DbUpdateException>(() => CreateService().Create(property));
        }

        [Test]
        public void CreatePriceProperty_propertyPriceYearLessZero_throw()
        {
            var property = PropertyTestDefault();
            property.price = -1000;
            property.year = -3;

            Assert.Throws<ArgumentException>(() => CreateService().Update(property));
        }

        [Test]
        public void GetFilteredProperties_filter_exception()
        {
            try
            {
                CreateService().ListWithFilters(FilterDtoTestDefault());
            }
            catch (Exception e)
            {
                Assert.Fail();
            }            
        }

        [Test]
        public void GetFilteredProperties_nullFilter_properties()
        {
            Assert.Throws<ArgumentNullException>(() => CreateService().ListWithFilters(null));
        }

        [Test]
        public void UpdateProperty_property_ok()
        {
            var property = PropertyTestDefault();

            property.idProperty = Guid.Parse("4ec9f9a0-dbc8-4db1-8ac8-945034ef0f5a");
            property.nombre = "name updated";
            try
            {
                CreateService().Update(property);
            }
            catch
            {
                Assert.Fail();
            }            
        }

        [Test]
        public void UpdateProperty_nullProperty_void()
        {
            Assert.Throws<ArgumentNullException>(() => CreateService().Update(null));
        }

        [Test]
        public void UpdateProperty_idPropertyDontExist_void()
        {
            var property = PropertyTestDefault();

            property.idProperty = Guid.Parse("d697a8b5-204e-438d-bfd3-44d16aae7111");
            property.nombre = "name updated";

            Assert.Throws<ArgumentException>(() => CreateService().Update(property));
        }

        [Test]
        public void UpdatePriceProperty_property_ok()
        {
            var property = PropertyTestDefault();

            property.idProperty = Guid.Parse("4ec9f9a0-dbc8-4db1-8ac8-945034ef0f5a");
            property.price = 1000;
            try
            {
                CreateService().Update(property);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test]
        public void UpdatePriceProperty_propertyPriceYearLessZero_throw()
        {
            var property = PropertyTestDefault();

            property.idProperty = Guid.Parse("4ec9f9a0-dbc8-4db1-8ac8-945034ef0f5a");
            property.price = -1000;
            property.year = -3;

            Assert.Throws<ArgumentException>(() => CreateService().Update(property));
        }
    }
}
