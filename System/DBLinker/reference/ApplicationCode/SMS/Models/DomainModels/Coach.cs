using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models.DomainModels
{
    public class Coach:Person
    {
        private List<Team> _teams;

        public List<Team> Teams
        {
            get { return _teams; }
            set { _teams = value; }
        }
    }
}