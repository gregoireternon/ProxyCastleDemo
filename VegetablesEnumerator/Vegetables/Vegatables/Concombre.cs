using System;

namespace Vegetables
{
    public class Radis : IVegetable
    {
        public  int Prix { get; set; }
        public  string GetNom()
        {
            return "Concombre";
        }
    }
}
