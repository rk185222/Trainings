using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{


    [Export(typeof(ICalculator))]
    public class MySimpleCalculator : ICalculator
    {
        //[ImportingConstructor]
        // public MySimpleCalculator(int a)
        // {
        //     Console.WriteLine(nameof(MySimpleCalculator));
        // }

        public string Calculate(string input)
        {
            Console.WriteLine(nameof(Calculate) + " " + input);
            Console.WriteLine(nameof(Calculate) + " -new2-" + input);
            return input;
        }
        public string Calculate2(string input)
        {
            Console.WriteLine(nameof(Calculate2) + " " + input);
            return input;
        }
    }
}
