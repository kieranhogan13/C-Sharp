using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GAA_Scores
{
    class TeamScore
    {
        private string teamName;

        public string TeamName
        {
          get { return teamName; }
          set { teamName = value; }
        }

        private string goals;

        public string Goals
        {
          get { return goals; }
          set { goals = value; }
        }

        private string points;

        public string Points
        {
          get { return points; }
          set { points = value; }
        }

        private string TotalScore;
        {
            get
            {
                return ( goals * 3 ) + points;
            }
        }

        public TeamScore()
            : this (", 0 , 0)
        {

        }        

        public TeamScore ( string teamName, int goals, int points)
        {
            this.teamName = teamName;
            this.goals = goals;
            this.points = points;
        }

        public override string ToString()
        {
            return teamName + "\t" + goals + "\t" + points + "\t" totalscore;
        }
    }
}
