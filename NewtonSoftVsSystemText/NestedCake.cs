using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonSoftVsSystemText
{
    public class NestedCake : ICake
    {
        public string? Name { get; set; }
        public int Layers => Cakes.Count;
        public Flavours Flavor { get; set; }
        public List<string> Toppings { get; set; } = new List<string>();
        public List<NestedCake> Cakes { get; set; } = new List<NestedCake>();

        public NestedCake()
        {

        }

        public NestedCake(string? name, List<NestedCake> cakes)
        {
            Name = name ?? "";
            Cakes = cakes ?? new List<NestedCake>();
        }

        public NestedCake(Flavours flavour, List<string> toppings)
        {
            Flavor = flavour;
            Toppings = toppings;
        }

        public void AddCake(NestedCake cake)
        {
            Cakes.Add(cake);
        }

        public void SayGreeting()
        {
            Console.WriteLine("Happy Birthday!");
        }
    }

    public enum Flavours
    {
        Chocolate,
        Vanilla,
        Strawberry,
        RedVelvet,
        Lemon,
        PoppingCandy,
        Hazelnut,
        Carrot
    }
}
