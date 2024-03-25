using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace robo_calendar
{
    internal class Tournament
    {
        string _tourName = "";
        List<Team> _teams = new();
        DateTime _tourDate = new();

        public Tournament(string tournamentName, List<Team> participatingTeams, DateTime tourDate)
        {
            _tourName = tournamentName;
            _teams = participatingTeams;
            _tourDate = tourDate;
        }


    }
}
