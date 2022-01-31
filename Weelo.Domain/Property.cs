using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Domain
{
    public class Property
    {
        public Guid idProperty { get; set; }
        public string nombre { get; set; }
        public string address { get; set; }
        public decimal price { get; set; }
        public string codeInternal { get; set; }
        public int year { get; set; }           
        public Guid idOwner { get; set; }
        public Owner owner { get; set; } 
        public List<PropertyTrace> propertyTraces { get; set; }
        public List<PropertyImage> propertyImages { get; set; }
    }
}
