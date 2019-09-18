using System;

namespace Vegetables
{
    public class Navet : IVegetable
    {
        public  int Prix { get; set; }
        public  string GetNom()
        {
            return "Navet";
        }
    }
}
