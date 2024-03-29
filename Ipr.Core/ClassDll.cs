using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ipr.Core
{
    
    public class ClassDll
    {
        [DllImport(@"C:\Users\User\source\iprs\SumDll\x64\Release\SumDll.dll", EntryPoint = "string_similarity2")]
        public static unsafe extern int Func1(string var1, string var2);

        [DllImport(@"C:\Users\User\source\iprs\SumDll\x64\Release\SumDll.dll", EntryPoint = "sum")]
        public static extern int Sum(int a, int b);

    }
}
