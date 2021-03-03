using System;
using System.Runtime.InteropServices;

namespace CsharpClient
{
    class Program
    {
        // You can omit the .dll extension. This is advised for cross-platform builds.
        [DllImport("Core", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int add(int a, int b);

        static void Main(string[] args)
        {
            int res = add(5, 4);
            Console.WriteLine(res);
        }
    }
}
