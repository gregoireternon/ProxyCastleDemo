using System;
using System.Linq;

namespace Vegetables
{
    public class VegetableFactory
    {
        static Type[] vegetableTypes = null;

        static VegetableFactory()
        {
            var type = typeof(IVegetable);

            vegetableTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p != typeof(IVegetable)).ToArray();
        }

        public  IVegetable Provide()
        {


            int choice = new Random().Next(0, vegetableTypes.Length);
            Type vegetableType = vegetableTypes[choice];
            return vegetableType.GetConstructor(new Type[] { }).Invoke(new object[] { }) as IVegetable;
        }
    }
}