using System;

namespace AmazingAnimalWidgets
{
    public interface IAnimalWidget
    {
        string Name { get; }

        int Happiness { get; set; }
    }
}
