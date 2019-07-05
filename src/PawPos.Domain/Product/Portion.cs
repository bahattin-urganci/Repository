using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.Domain.Product
{
    public class Portion
    {
        public int Multiplier { get; set; } = 1;
        public decimal Price { get; set; }
    }
}
