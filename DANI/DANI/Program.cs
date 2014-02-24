using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Speech.Synthesis;      /*Uses library reference for speech synthesis*/

namespace dani
{
    class Program
    {
        /* Kieran Hogan
         * C12561353 
         * DANI
         * 
         * This program works off the basis of using the main program, and two classes. The main program
         * deals with all major functionality, using a variety of methods, and when neccessary uses
         * the classes Word and Word2 to create new objects. Word is every word in the input sentence
         * and Word2 is the word that follows it. This is the easiest way to explain the basic 
         * functionality of the program.
         *
         * I had originally made a field for total, which i calle in certain places to count up the number of 
         * times each word was said, but it caused numerous bugs in the program, which I was unable to fix. 
         * Thus, i left out the counting of each words frequency. This does mean that DANIs responses arent
         * influenced by the number of times I link a certain word to another. However this doesn't seem to
         * reduce his intelligance.
         
         * My secondary function for DANI is made up of two parts. I have a DANI does maths part, and
         * a speech synthesizer part. Due to whatever reason, I could never actually hear DANI speak,
         * althought the code for my synthesizer parts is correct (I think) and compiled and ran without errors. 
         * As a result, I have left the speech synthesis parts commented out with //, in order to distinguish.*/

        public static List<Word> WordList = new List<Word>();   /*Creates a new list for each word*/
        public static List<Word2> Word2List = new List<Word2>();    /*Creates a new List for the second word (word after word)*/
        //public static SpeechSynthesizer Synthesizer = new SpeechSynthesizer();    /*Creates a new instance of the SpeechSynthesizer*/

        static void DANI(string username)   /*Method for DANI main menu*/
        {
            Console.Clear();    /*Clears screen*/
            //Synthesizer.Rate = 1;     /*Sets speech synthesizer rate*/
            //Synthesizer.Volume = 80;  /*Sets speech synthesizer volume*/
            //Synthesizer.Speak("Greetings " + username + "! This is DANI speaking.");  /*Speech synthesizer speaks out the words that dani is saying*/
            //Synthesizer.Speak("This is my main menu. Press the corresponding number for each of my functions."); /*Speech synthesizer speaks out the words that dani is saying*/
            Console.WriteLine("Dani: Greetings " + username + "! This is DANI speaking. This is my main menu.");
            Console.WriteLine("Dani: Press the corresponding number for each of my functions:\n");
            while (true)    /*Loops menu until system exit*/
            {
                Console.WriteLine("1. Talk to DANI \n2. Maths with DANI \n3. Quit [or enter \"quit\"]");
                string menu = Console.ReadLine();
                switch (menu)   /*switch case for each menu option*/
                {
                    case "1":
                        talkToDani(username);   /*Calls talk to DANI method, passing in username string*/
                        break;
                    case "2":
                        mathsWithDani(username);    /*Calls maths with DANI method, passing in username string*/
                        break;
                    case "3":
                        System.Environment.Exit(0);     /*Quits the program entirely*/
                        break;
                    case "quit":
                        System.Environment.Exit(0);     /*Quits the program entirely*/
                        break;
                }
            }
        }
        /*Basic Dani Speaking Method*/
        static void talkToDani(string username)
        {
            Console.Clear();    /*Clears the screen*/
            //Synthesizer.Speak("Talk to me and I will learn from what you say, and answer you.");  /*Speech synthesizer speaks out the words that dani is saying*/
            Console.WriteLine("\nDani: Talk to me and I will learn from what you say, and answer you. \n[Tell dani \"quit\" to return to menu] [also please dont use punctuation] \n\n");
            while (true)
            {
                Console.Write(username + ": ");
                string sentence = Console.ReadLine(); /*Reads in string*/
                if (sentence.ToLower() == "quit")   /*if quit is the string entered, quits back to menu*/
                {
                    Console.Clear();    /*Clears the screen*/
                    break;
                }
                string[] individualWords = sentence.Split(' '); /*Parses the sentence into array of word strings*/
                wordCollection(individualWords);  /*Calls the method word collection, passing in the array of strings called words*/
                Reply();    /*Calls the reply method to give the user a reply*/
            }
        }

        /*Word Collection method*/
        static void wordCollection(string[] individualWords)
        {
            int i, j;   /*Ints for loops*/
            for (i = 0; i < individualWords.Count(); i++) /*Main loop to add the array of words individualWords to the lists*/
            {
                if (individualWords[i] != "") /*Looks for any possible empty strings*/
                {
                    if (WordList.Count() == 0) /*If the WordList is empty (ie hasnt run before)*/
                    {
                        if (individualWords.Count() == 1 )  /*If the Word.Count is 1 (ie has no follower)*/
                        {
                            WordList.Add(new Word(individualWords[i])); /*Adds a single word to new object list, when no word following*/
                        }
                        else /*Otherwise*/
                        {
                            if (individualWords.Count() > 1) /*If the Word.Count is greater than 1*/
                            {
                                WordList.Add(new Word(individualWords[i])); /*Adds the word to new object Word list*/
                                Word2List.Add(new Word2(individualWords[i + 1])); /*Adds the next word to new object Word2 list*/
                            }
                        }
                    }
                    else /*Otherwise*/
                    {
                        bool newWord = true; /*Defaults newWord to true*/
                        for (j = 0; j < WordList.Count(); j++)
                        {
                            if (individualWords[i] == WordList[j].Word1) /*If its not a new word (ie they're equal)*/
                            {
                                newWord = false;    /*newWord becomes false*/
                                if (i != (individualWords.Count() - 1)) /*If i does not equal count-1 (ie not the last word in the array)*/
                                {
                                    if ((WordList[j].Word2List.Count()) > 0)/*If the found word has words linked from Word2 already (following words)*/
                                    {
                                        WordList[j].Word2List.Add(new Word2(individualWords[(i + 1)])); /*Adds the next word to new object Word2 list*/
                                    }
                                }
                            }
                        }
                        if (newWord == true)/*If newWord = true, ie it is a newWord*/
                        {
                            if ((individualWords.Count() - 1) == i) /*If the Word.Count is 1 (ie has no follower)*/
                            {
                                WordList.Add(new Word(individualWords[i])); /*Adds a single word to new object list, when no word following*/
                            }
                            else /*Otherwise*/
                            {
                                if (individualWords.Count() > 1) /*If the Word.Count is greater than 1*/
                                {
                                    WordList.Add(new Word(individualWords[i])); /*Adds the word to new object Word list*/
                                    Word2List.Add(new Word2(individualWords[i + 1])); /*Adds the next word to new object Word2 list*/
                                }
                            }
                        }
                    }
                }
            }
        }

        /*Reply method*/
        static void Reply()
        {
            int i, j;   /*ints for loops*/
            Random rndnumber = new Random();    /*Creates a random number called rndnumber*/
            Random rndword = new Random();      /*Creates a random number called rndword*/
            j = rndnumber.Next(1, 4);           /*Picks the rndnumber, anywhere between 1 and 4, this is determining the length of the reply sentence*/
            string randomWord2String = "";   /*Makes the word that follows your word blank, in case there is none in the list*/
            Console.Write("Dani: ");       /*Creates DANI reply dialog interface*/
            for (i = 0; i < j; i++)     /*Loops the random word for the random number of times*/
            {
                int k = rndword.Next(WordList.Count());     /*Picks the random word number for k (which is a word from WordList)*/
                int l = rndword.Next(Word2List.Count());    /*Picks the random word number for l (which is a word from Word2List)*/
                string randomWordString = WordList[k].Word1;    /*Lets the random word number k equal to its counterpart in the WordList*/
                if (Word2List.Count() > 0)      /*If there is a following word present in Word2List*/
                {
                    randomWord2String = Word2List[l].Word;  /*Lets the random word number l equal to its counterpart in the Word2List*/
                }
                //Synthesizer.Speak(randomWordString + " " + randomWord2String + " ");  /*Speech synthesizer speaks out the words that dani is saying*/
                Console.Write(randomWordString + " " + randomWord2String + " ");   /*Returns a sentence part, with a random word from WordList and its following word from Word2List*/
            }
            Console.WriteLine(); /*Move down a line*/
        }

        /*Calculator mode method*/
        static void mathsWithDani(string username)
        {
            Console.Clear();
            //Synthesizer.Speak("So " + username + ", I bet you didn't know I'm really good at basic maths!");  /*Speech synthesizer speaks out the words that dani is saying*/
            Console.Write("Dani: So " + username + ", I bet you didn't know I'm really good at basic maths!\n");
            while (true)
            {
                decimal number1, number2, answer;   /*declaring decimal numbers*/
                string function;    /*string for the operand*/
                Console.Write("Dani: Give me a number to start with: \n");
                Console.Write(username + ": ");
                number1 = Convert.ToDecimal(Console.ReadLine());    /*converts input to decimal*/
                Console.Write("Dani: Would you like to +, -, /, or *: \n");
                Console.Write(username + ": ");
                function = Console.ReadLine();  /*Reads in function*/
                Console.Write("Dani: And give me your second number: \n");
                Console.Write(username + ": ");
                number2 = Convert.ToDecimal(Console.ReadLine());    /*converts input to decimal*/
                switch (function)   /*Swtich cases for dealing with different operands*/
                {
                    case "+":
                        answer = number1 + number2;     /*case for adding*/
                        break;
                    case "-":
                        answer = number1 - number2;     /*case for taking away*/
                        break;
                    case "*":
                        answer = number1 * number2;     /*case for multiplying*/
                        break;
                    case "/":
                        answer = number1 / number2;     /*case for dividing*/
                        break;
                    default:
                        answer = 0;                     /*default answer is set to return 0*/
                        break;
                }
                //Synthesizer.Speak("Hmmmmmm, let me think a moment.....");  /*Speech synthesizer speaks out the words that dani is saying*/
                Console.Write("Dani: Hmmmmmm, let me think a moment.....\n\n");
                Console.WriteLine(number1.ToString() + " " + function + " " + number2.ToString() + " = " + answer.ToString());      /*calculation*/
                //Synthesizer.Speak("Too easy, want to ask me another?);  /*Speech synthesizer speaks out the words that dani is saying*/
                Console.Write("\nDani: Too easy, want to ask me another? \n[Enter \"no\", or simply hit enter to ask again]\n");
                Console.Write(username + ": ");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "no")   /*Gives users the option to go again or to return to the menu*/
                {
                    Console.Clear();
                    break;
                }
            }
        }

        /*Main*/
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter your name or \"quit\" to quit: "); /*Prompts for username*/
                string username = Console.ReadLine();   /*Accepts a username from user*/
                if (username.ToLower() == "quit") /*Gives users a chance to quit, by giving username "quit" */
                {
                    break;
                }
                DANI(username);     /*Calls DANI method, and passes in string username to give personal experience*/
            }
        }
    }
}
