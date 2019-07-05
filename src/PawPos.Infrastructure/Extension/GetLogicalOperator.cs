using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.Infrastructure.Extension
{
    public static class GetLogicalOperator
    {
        public static bool StringToLogicalOperator<T>(this string op, T left, T right) where T : IComparable<T>
        {
            switch (op)
            {
                case "<": return left.CompareTo(right) < 0;
                case ">": return left.CompareTo(right) > 0;
                case "<=": return left.CompareTo(right) <= 0;
                case ">=": return left.CompareTo(right) >= 0;
                case "==": return left.Equals(right);
                case "!=": return !left.Equals(right);
                default: throw new ArgumentException("Geçersiz Karşılaştırma Operatörleri kullanıldu {0}", op);
            }
        }
    }
}
