using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class WillBeMapAttribute :Attribute
    {
        public string MapTo { get; set; }
        public WillBeMapAttribute(string mapTo)
        {
            MapTo = mapTo;
        }
    }
}
