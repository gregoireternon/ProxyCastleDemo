using System;

namespace Vegetables
{
    public interface IVegetable
    {
        int Prix { get; set; }

        string GetNom();
    }
}
