using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.DTO
{
    public class FilterDto
    {
        public string nameProperty { get; set; }
        public string address { get; set; }
        public decimal minPrice { get; set; }
        public decimal maxPrice { get; set; }
        public int minYear { get; set; }
        public int maxYear { get; set; }
        public string codeInternal { get; set; }
        public Guid idOwner { get; set; }
        public string nameOwner { get; set; }
    }
}
