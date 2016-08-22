using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SImpleTranslate
{
    class Word
    {
        private string english;
        public string English
        {
            get { return english; }
            set { english = value; }
        }
        private string irish;
        public string Irish
        {
            get { return irish; }
            set { irish = value; }
        }
        public Word(string english, string irish)
        {
            this.english = english;
            this.irish = irish;
        }
    }
}
