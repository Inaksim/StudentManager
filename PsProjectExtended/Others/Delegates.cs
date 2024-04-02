using Microsoft.Extensions.Logging;
using PsProjectExtended.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsProjectExtended.Others
{
     class Delegates
    {
        public static readonly ILogger logger = LoggerHelper.GetLogger("Hello");
            
        public static void Log(string e)
        {
            logger.LogError(e);
        }

        public static void Log2(string e) 
        {
            Console.WriteLine("-Delegates-");
            Console.WriteLine($"{e}");
            Console.WriteLine("-Delegates-");
        }

    }
}
