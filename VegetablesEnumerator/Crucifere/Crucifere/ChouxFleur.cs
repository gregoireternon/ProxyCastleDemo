﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vegetables;

namespace Crucifere.Crucifere
{
    public class ChouxFleur : ICrucifere
    {
        public int Prix { get; set; }
        public string GetNom()
        {
            return "Choux fleur";
        }
    }
}
