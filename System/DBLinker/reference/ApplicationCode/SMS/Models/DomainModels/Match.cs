using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models.DomainModels
{
    public class Match
    {
        private int _duration;

        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        private Guid _id;

        public Match()
        {
        }
        public Match(Guid ID)
        {
            _id = ID;
        }
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private TeamApplication _teamAppOne;

        public TeamApplication TeamApplicationOne
        {
            get { return _teamAppOne; }
            set { _teamAppOne = value; }
        }
        private TeamApplication _teamAppTwo;

        public TeamApplication TeamApplicationTwo
        {
            get { return _teamAppTwo; }
            set { _teamAppTwo = value; }
        }
        private string _scoreOne;

        public string ScoreOne
        {
            get { return (_scoreOne == "-1")?"N/A":_scoreOne; }
            set { _scoreOne = value; }
        }
        private string _scoreTwo;

        public string ScoreTwo
        {
            get { return (_scoreTwo == "-1")?"N/A":_scoreTwo; }
            set { _scoreTwo = value; }
        }
        private string _location;

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        private DateTime _scheduledDate;

        public DateTime ScheduledDate
        {
            get { return _scheduledDate; }
            set { _scheduledDate = value; }
        }
        private Tournament _tournament;

        public Tournament Tournament
        {
            get { return _tournament; }
            set { _tournament = value; }
        }
        
    }
}