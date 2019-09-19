using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crucifere.Crucifere
{
    public class Navet:ICrucifere
    {
        public int Prix { get; set; }
        public string GetNom()
        {
            return "Navet";
        }
    }
}
