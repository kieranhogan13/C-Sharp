﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication6
{
    class Cat
    {
        public string name;
        public int numLives;
        public bool isAlive;

        public Cat()
        {
            numLives = 9;
            isAlive = true;
        }

        public void Die()
        {
            if (numLives > 0)
            {                
                numLives--;
                Console.WriteLine("Ouch! " + numLives + " left");
            }
            if (numLives == 0)
            {
                isAlive = false;
            }
        }

        public void Meow()
        {
            if (isAlive)
            {
                Console.WriteLine("Meow meow!");
            }
            else
            {
                Console.WriteLine("Im dead!");
            }
        }

    }
}
