﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetablesEnumerator.Vegatable
{
    public class Topinambour : IVegetable
    {
        public virtual string GetNom()
        {
            throw new Exception("Nom trop compliqué");
        }
    }
}