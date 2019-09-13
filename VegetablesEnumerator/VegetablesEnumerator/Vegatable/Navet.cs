using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetablesEnumerator.Vegatable
{
    public class Navet : IVegetable
    {
        public virtual string GetNom()
        {
            
            return "Navet";
        }
    }
}
