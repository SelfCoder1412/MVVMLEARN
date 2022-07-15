using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Controller
{
    class YieldDemo
    {
        internal void MethodAccess()
        {
            foreach (var VARIABLE in funct(2,10))
            {
                Console.WriteLine(VARIABLE);
            }
        }

        private IEnumerable<int> funct(int v1, int v2)
        {
            for (int i = 0; i < v2; i++)
            {
                yield return v1 + 2 * i;
            }
        }
    }
}
