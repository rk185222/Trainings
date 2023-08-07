using AmazingAnimalWidgets;
using System;

namespace DefaultInterfaceMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            var dog = new DogWidget();
            var cat = new CatWidget();
            var hamster = new HamsterWidget();

            var animals = new IAnimalWidget[] { dog, cat, hamster };

            foreach (var animal in animals)
            {
                Console.WriteLine($"Happiness level for {animal.Name}: {animal.Happiness}");
            }
        }
    }
}
