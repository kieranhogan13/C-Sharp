using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Expenses
{
    class Program
    {
        static Expense[] expenses;

        static void LoadExpenses(string filename)
        {
            string[] lines = System.IO.File.ReadAllLines(filename);
            expenses = new Expense[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                expenses[i] = new Expense(lines[i]);
            }
        }

        static void PrintExpenses(string party, bool search)
        {
            float total = 0.0f;
            float min = float.MaxValue;
            float max = float.MinValue;
            int minIndex = 0, maxIndex = 0;
            bool found = false;
            for (int i = 0; i < expenses.Length; i++)
            {
                if( search == true )
                    if (expenses[i].SearchParty == party)
                    {
                        Console.WriteLine(expenses[i]);
                        total += expenses[i].Total;
                        if (expenses[i].Total > max)
                        {
                            max = expenses[i].Total;
                            maxIndex = i;
                        }
                        if (expenses[i].Total < min)
                        {
                            min = expenses[i].Total;
                            minIndex = i;
                        }
                    }
                    else if (expenses[i].region.IndexOf == false)
                    {
                        found = true;
                        Console.WriteLine(expenses[i]);
                        total += expenses[i].Total;
                        if (expenses[i].Total > max)
                        {
                            max = expenses[i].Total;
                            maxIndex = i;
                        }
                        if (expenses[i].Total < min)
                        {
                            min = expenses[i].Total;
                            minIndex = i;
                        }
                    }
                }
            }
            if (found)
            {
                Console.WriteLine("Total claimed for party: " + party + " was " + total);
                Console.WriteLine("Minimum claimed from party: " + party + " was " + expenses[minIndex].Total + " by " + expenses[minIndex].Name);
                Console.WriteLine("Maximum claimed from party: " + party + " was " + expenses[maxIndex].Total + " by " + expenses[maxIndex].Name);
            }
            else
            {
                Console.WriteLine("Party " + party  + " not found");
            }
        }

        static void Main(string[] args)
        {
            LoadExpenses("expenses.txt");
            while (true)
            {
                Console.WriteLine("Enter C to search by first 3 letters of the constituency or P to search by party or \"quit\" to quit");
                string menu = Console.ReadLine();
                bool search = true;
                if (menu.ToLower() == "quit")
                {
                    break;
                }
                else if(menu.ToLower() == "c")
                {
                    Console.WriteLine("Enter the first three letters of a constituency or “quit” to quit");
                    string cons = Console.ReadLine();
                    search = false;
                    if (cons.ToLower() == "quit")
                    {
                        break;
                    }
                    PrintExpenses(cons.ToUpper());
                }
                else if (menu.ToLower() == "p")
                {
                    Console.WriteLine("Enter the first three letters of a party or “quit” to quit");
                    string party = Console.ReadLine();
                    if (party.ToLower() == "quit")
                    {
                        break;
                    }
                    PrintExpenses(party.ToUpper()); 
                }
            }
        }
    }
}
