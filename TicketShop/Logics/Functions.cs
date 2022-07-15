using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShop.Logics
{
    public class Functions
    {
        public static string TicketCodeGenerator()
        {
            var code = new Random();
            return $"{code.Next(1000, 9999)}-{code.Next(1000, 9999)}-{code.Next(1000, 9999)}";
        }
    }
}
