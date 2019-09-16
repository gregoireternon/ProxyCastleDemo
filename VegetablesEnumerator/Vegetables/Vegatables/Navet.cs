using System;

namespace Vegetables
{
    public class Navet : IVegetable
    {
        public virtual string GetNom()
        {
            return "Navet";
        }
    }
}
