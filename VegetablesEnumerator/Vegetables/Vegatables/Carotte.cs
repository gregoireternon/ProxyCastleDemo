using System;

namespace Vegetables
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
