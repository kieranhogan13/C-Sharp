using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SImpleTranslate
{
    class Program
    {
        static void Main(string[] args)
        {

            Application.Run(new Form1());

            Dictionary dictionary = new Dictionary();
            dictionary.Load();

            string toFind = "";
            while (true)
            {
                Console.WriteLine("Enter a word to find:");
                toFind = Console.ReadLine();
                if (toFind == "quit")
                {
                    break;
                }
                while (true)
                {
                    Console.WriteLine("Press E for Irish to English, Press I for English to Irish");
                    string toEnglish = Console.ReadLine();
                    if (toEnglish.ToUpper() == "E")
                    {
                        Console.WriteLine(dictionary.Translate(toFind, true));
                        break;
                    }
                    else if (toEnglish.ToUpper() == "I")
                    {
                        Console.WriteLine(dictionary.Translate(toFind, false));
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}
