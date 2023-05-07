using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using InterfaceLibrary;

namespace MEF_ConsoleApp
{
    internal class TestMEF
    {
        private CompositionContainer _container;

        [Import(typeof(ICalculator))]
        public ICalculator calculator;

        public void Start()
        {
            try
            {
                // An aggregate catalog that combines multiple catalogs.
                var catalog = new AggregateCatalog();
                // Adds all the parts found in the same assembly as the Program class.
                //catalog.Catalogs.Add(new AssemblyCatalog(typeof(MyLibrary.ICalculator).Assembly));

                catalog.Catalogs.Add(
                new DirectoryCatalog(
                "R:\\Sandbox\\Training\\Trainings\\C#\\MEF_ConsoleApp\\MEF_ConsoleApp\\Extensions\\Debug\\net6.0"));

                // Create the CompositionContainer with the parts in the catalog.
                _container = new CompositionContainer(catalog);
                _container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }
    }
}
