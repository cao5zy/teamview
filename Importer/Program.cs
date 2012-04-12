using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Importer
{
    class Program
    {
        static void Main(string[] args)
        {
            string reporterName = args[0];
            string handlerName = args[1];
            string importedFileName = args[2];

            var importController = new Starter().BuildJIRAImportContainer();

        }
    }
}
