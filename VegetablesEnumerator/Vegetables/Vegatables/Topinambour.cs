using System;

namespace Vegetables
{
    public class Topinambour : IVegetable
    {
        public  int Prix { get; set; }
        public  string GetNom()
        {
            
            throw new VegetableException("Nom trop compliqué");
        }
    }
}
