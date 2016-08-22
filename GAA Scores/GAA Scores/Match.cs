using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GAA_Scores
{
    public class Match
    {
        private TeamScore home;

        internal TeamScore Home
        {
            get { return home; }
            set { home = value; }
        }
        private TeamScore away;

        internal TeamScore Away
        {
            get { return away; }
            set { away = value; }
        }

        public Match()
        {
            home = new TeamScore();
            away = new TeamScore();
        }

        public override string ToString()
        {
            return home + "\t" + away + "\t"

        public override string ToString()
        {
            return home + "\t" + away + "\t" + ;
        }
    }
}
