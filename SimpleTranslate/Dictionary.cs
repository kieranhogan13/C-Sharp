using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SImpleTranslate
{
    class Dictionary
    {
        public Word[] words;
        public string fileName;

        public Dictionary()
        {
            words = new Word[10];
            fileName = "words.txt";
        }

        public void Load()
        {
            string line;

            //string theFile = File.ReadAllText(fileName);
            //string[] lines = theFile.Split("\n");
            //for (int i = 0; i < lines.Length; i++)
            //{
            //    string[] awords = line.Split(',');
            //    words[i] = new Word(awords[0], awords[1]);
            //}

            StreamReader file = new System.IO.StreamReader("words.txt");
            int i = 0;
            while ((line = file.ReadLine()) != null)
            {
                string[] awords = line.Split(',');
                words[i ++] = new Word(awords[0], awords[1]);
            }
            file.Close();
        }

        public string Translate(string toFind, bool toEnglish)
        {
            foreach (Word word in words)
            {
                if (toEnglish)
                {
                    if (toFind == word.Irish)
                    {
                        return word.English;
                    }
                }
                else
                {
                    if (toFind == word.English)
                    {
                        return word.Irish;
                    }
                }
            }
            return "Not found";
        }
    }
}
