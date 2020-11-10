using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    [Serializable]
    public class Country
    {

        public int Id;
        public string Name;
        public string Code;

        public Country(){}

        public Country(int id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }
    }
}
