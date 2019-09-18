using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegetables
{
    public class VegetableException:Exception
    {
        public VegetableException(string message) :base(message)
        {

        }
    }
}
