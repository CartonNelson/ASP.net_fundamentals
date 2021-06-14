using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Modelo
{
    public static class ExceptionPrinter
    {
        public static void Print(Exception e)
        {
            Console.WriteLine($"Message: { e.Message }");
        }
    }
}
