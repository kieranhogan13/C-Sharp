using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dori = new Dog();

            dori.age = 3;
            dori.name = "Dori";
            dori.breed = "Mongrel";
            Dog.numLegs = 3;

            Dog misty = new Dog();
            misty.age = 3;
            misty.breed = "King Charles";
            misty.name = "Misty";

            dori.Bark();
            misty.Bark();

            dori.age = 5;
            misty.age = 3;

            misty = dori;
            misty.age = 4;
            

            Console.WriteLine(dori.age);


            Dog mrT = new Dog(7, "Mr T", "King Charles");
            mrT.Bark();

            Cat theo = new Cat();
            theo.name = "Theodore";
            theo.Meow();

            while (theo.isAlive)
            {
                theo.Die();
            }

            Console.ReadLine();
        }
    }
}
