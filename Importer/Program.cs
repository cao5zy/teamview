using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dev3Lib.Algorithms;

namespace JIRAImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            string importedFileName = args[0];

            var importController = new Starter().BuildJIRAImportContainer();

            importController.Import(new JIRAImportModel
            {
                ImportFile = args[0],
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
