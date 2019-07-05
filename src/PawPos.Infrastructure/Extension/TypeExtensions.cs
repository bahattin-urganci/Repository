using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PawPos.Infrastructure.Extension
{
    public static class TypeExtensions
    {
        public static Dictionary<string, Type> GetCommonValueOfAttributeToDict(this IEnumerable<Type> types)
        {
            Dictionary<string, Type> _dict = new Dictionary<string, Type>();

            foreach (var item in types)
            {
                foreach (var prop in item.CustomAttributes)
                {
                    _dict.Add(prop.ConstructorArguments.First().Value.ToString(), item);
                }
            }

            return _dict;
        }
    }
}
