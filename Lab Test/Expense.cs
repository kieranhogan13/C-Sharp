using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expenses
{
    public class Expense
    {
        private string name;
	    public string Name
	    {
		    get { return name; }
		    set { name = value; }
	    }
        private string party;
	    public string Party
	    {
		    get { return party; }
		    set { party = value; }
	    }
        private string region;

        public string Region
        {
          get { return region; }
          set { region = value; }
        }
        private float returned;
	    public float Returned
	    {
		    get { return returned; }
		    set { returned = value; }
	    }
        private float claimed;
	    public float Claimed
	    {
		    get { return claimed; }
		    set { claimed = value; }
	    }

        public string SearchParty
        {
            get { return party.ToUpper(); }
        }

        public float Total
        {
          get { return claimed - returned; }
        }

        public Expense()
        {
            name = "";
            party = "";
            region = "";
            returned = 0;
            claimed = 0;
        }

        public Expense(string line)
        {
            string[] fields = line.Split('\t');
            name = fields[0];
            party = fields[1];
            region = fields[2];
            returned = float.Parse(fields[3]);
            claimed = float.Parse(fields[4]);
        }

        public override string ToString()
        {
            return name + "\t" + party + "\t" + region + "\t" + returned + "\t" + claimed + "\t" + Total;
        }
    }
}
