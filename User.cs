using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    [Serializable]
    public class User
    {
        public int Id;
        public string Name;
        public int Birthday;
        public int CountryId;
        


        public User() { }
        
        public User(int id, string name, int birthday, int countryId)
        {
            Id = id;
            Name = name;
            Birthday = birthday;
            CountryId = countryId;
            
        }
    }
}
