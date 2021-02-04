using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroControl.Models
{
    public class ObiektGospodarczy
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public int GospodarstwoID { get; set; }
        public virtual Gospodarstwo Gospodarstwo { get; set; }
    }
}
