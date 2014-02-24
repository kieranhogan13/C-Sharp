using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dani
{
    public class Word
    {
        /*This class deals with all components of my class Word*/

        private string word; /*Creates a word object and encapsulated to allow reading and writing to*/
        public string Word1
        {
            get { return word; }    /*read and write parameters*/
            set { word = value; }
        }

        public List<Word2> Word2List; /*Makes list Word2List public*/

        public Word(string word) /*Creates a field and encapsulated to allow reading and writing to*/
        {
            this.word = word;   /*qualifies word (has a similar name)*/
            Word2List = new List<Word2>();  /*Creates object of type Word2 class inside object Word*/
        }

        //private int total;    /*Originally planned on using a system for counting instances of word, but removed because of bugs*/

        //public int Total
        //{
        //    get { return total; }
        //    set { total = value; }
        //}
    }
}
