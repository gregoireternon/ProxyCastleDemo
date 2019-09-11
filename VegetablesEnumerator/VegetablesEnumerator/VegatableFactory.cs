using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetablesEnumerator.Vegatable;

namespace VegetablesEnumerator
{
    public  class VegatableFactory
    {
        static Type[] vegetableTypes = new Type[]
        {
            typeof(Carotte),
            typeof(Navet),
            typeof(Topinambour)
        };

        public  IVegetable Provide()
        {
            int choice = new Random().Next(0, vegetableTypes.Length);
            Type vegetableType = vegetableTypes[choice];
            return vegetableType.GetConstructor(new Type[] { }).Invoke(new object[] { }) as IVegetable;
        }

    }
}
