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
        
        public static string APIUrlCustomization(decimal objectToCustomize)
        {
            if (objectToCustomize.ToString().Contains(','))
            {
                var stringArray = objectToCustomize.ToString().Split(',');
                return $"{stringArray[0]}.{stringArray[1]}";
            }

            return objectToCustomize.ToString();
        }
    }
}
