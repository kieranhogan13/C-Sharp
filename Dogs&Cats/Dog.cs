using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication6
{
    public class Dog
    {
        public string name;
        public string breed;
        public int age;
        public static int numLegs = 4;

        public Dog()
        {
            age = 0;
            name = "";
            breed = "";
        }

        public Dog(int age, string name, string breed)
        {
            this.age = age;
            this.name = name;
            this.breed = breed;

        }

        public void Bark()
        {
            Console.WriteLine(this.name + " says Woof woof!");
            Console.WriteLine("I have" + numLegs + " legs");

        }
    }
}
