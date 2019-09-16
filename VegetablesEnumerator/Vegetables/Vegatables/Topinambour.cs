using System;

namespace Vegetables
{
    public class Topinambour : IVegetable
    {
        public virtual string GetNom()
        {
            
            throw new Exception("Nom trop compliqué");
        }
    }
}
