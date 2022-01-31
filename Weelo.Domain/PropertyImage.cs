using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Domain
{
    public class PropertyImage
    {
        public Guid idPropertyImage { get; set; }
        public byte[] file { get; set; }
        public bool enabled { get; set; }
        public Guid idProperty { get; set; }
        public Property property{get; set;}

    }
}
