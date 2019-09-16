using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetablesEnumerator.Vegatable
{
    public class Carotte : IVegetable
    {
        public  int Prix { get; set; }
        

        public  string GetNom()
        {
            
            return "Carotte";
        }
    }
}
