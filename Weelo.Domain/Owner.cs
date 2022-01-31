using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Domain
{

    public class Owner
    {
        public Guid IdOwner { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public byte[] photo { get; set; }
        public DateTime birthday { get; set; }
        public List<Property> properties { get; set; }

    }

}
