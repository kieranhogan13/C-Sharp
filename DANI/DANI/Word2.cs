using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dani
{
    public class Word2
    {
        /*This class deals with all components of my class Word2*/

        private string word; /*Creates a word object and encapsulated to allow reading and writing to*/
        public string Word
        {
            get { return word; }
            set { word = value; }
        }

        public Word2(string word) /*Makes a word2 object to allow the follow word to be entered*/
        {
            this.word = word;
        }
    }
}
