using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Domain
{
    public class PropertyTrace
    {
        public Guid idPropertyTrace { get; set; }
        public DateTime dateSale { get; set; }
        public string name { get; set; }
        public decimal value { get; set; }
        public decimal tax { get; set; }
        public Guid idProperty { get; set; }
        public virtual Property property {get; set;}
    }
}
