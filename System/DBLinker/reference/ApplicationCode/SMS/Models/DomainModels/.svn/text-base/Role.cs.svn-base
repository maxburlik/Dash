using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models.DomainModels
{
    public class Role
    {
        private string _name = "";
        private List<AvailableFunction> _availableFunctions;

        public List<AvailableFunction> AvailableFunctions
        {
            get { return _availableFunctions; }
            set { _availableFunctions = value; }
        }

        public string RoleName
        {
            get { return _name; }
            set { _name = value; }
        }
        private Guid _id;
        public Guid ID
        {
            get { return _id; }
        }
        private string _desc = "";

        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }

        public Role() { }
        public Role(Guid ID, string Name, string Description)
        {
            _id = ID;
            RoleName = Name;

            _availableFunctions = new List<AvailableFunction>();
        }
  
    }

    public class AvailableFunction
    {
        private Guid _id;
        private string _functionName;

        public string FunctionName
        {
            get { return _functionName; }
            set { _functionName = value; }
        }

        public AvailableFunction(Guid ID, String Name)
        {
            this.FunctionName = Name;
            _id = ID;
        }

        public Guid ID
        {
            get { return _id; }        
        }
    }

}