using System;

namespace Vegetables
{
    public class Concombre : IVegetable
    {
        public  int Prix { get; set; }
        public  string GetNom()
        {
            return "Concombre";
        }
    }
}
