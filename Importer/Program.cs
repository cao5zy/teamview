using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dev3Lib.Algorithms;

namespace Importer
{
    class Program
    {
        static void Main(string[] args)
        {
            string handlerName = args[0];
            string importedFileName = args[1];

            var importController = new Starter().BuildJIRAImportContainer();

            importController.Import(new JIRAImportModel
            {
                Handler = args[0],
                ImportFile = args[1],
            });

            if (importController.ImportedList.IsNullOrEmpty())
            {
                Console.WriteLine("nothing imported. press any key to continue.");
                Console.Read();
            }
            else
            {
                importController.ImportedList
                    .SafeForEach(n => Console.WriteLine(n));
                Console.WriteLine("items imported successfully");
                Console.Read();
            }
        }
    }
}
