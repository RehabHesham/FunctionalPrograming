using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalPrograming.Concept
{
    internal static class ExtensionFunctions
    {
        public static Func<T1, T3> Compose<T1, T2, T3>(this Func<T1, T2> F, Func<T2, T3> G)
        {
            return (x) => G(F(x));
        }
    }
}
