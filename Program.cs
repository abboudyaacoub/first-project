using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {

            int m = 1;
            do
            {
                String n;
                Console.WriteLine("create user put 1 ");
                Console.WriteLine("find user by Name or Id put 2 ");
                Console.WriteLine("find all user for a specific country code sorted by Name or Birthdate put 3 ");
                n = Console.ReadLine();
                int number = Int32.Parse(n);


                if (number == 1)
                {
                    string Id;
                    String name;
                    string birthday;
                    string countryid;

                    Console.WriteLine("Enter your Id:");
                    Id = Console.ReadLine();
                    int id = Int32.Parse(Id);
                    Console.WriteLine("Enter your name:");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter your birthday:");
                    birthday = Console.ReadLine();
                    int Birth = Int32.Parse(birthday);
                    Console.WriteLine("Enter your Countryid:");
                    countryid = Console.ReadLine();
                    int Countryid = Int32.Parse(countryid);



                    List<User> user = new List<User>();
                    try
                    {
                        string listofuser = File.ReadAllText(@"user");
                        user = JsonConvert.DeserializeObject<List<User>>(listofuser);
                    }
                    catch (Exception)
                    {
                        string user1 = JsonConvert.SerializeObject(user);
                        File.WriteAllText(@"user", user1);
                    }
                    user.Add(new User(id, name, Birth, Countryid));
                    string Json = JsonConvert.SerializeObject(user);
                    File.WriteAllText(@"user", Json);


                }
                else if (number == 2)
                {
                    string SearchName = Console.ReadLine();


                    string listofemployees = File.ReadAllText(@"user");

                    List<User> user = JsonConvert.DeserializeObject<List<User>>(listofemployees);
                    user = user.FindAll(x => SearchByName(SearchName,x));

                    foreach (User u in user)
                    {
                        Console.WriteLine(u.Name);
                    }

                    string Searchid = Console.ReadLine();
                    int SearchId = Int32.Parse(Searchid);
                    List<User> ser = JsonConvert.DeserializeObject<List<User>>(listofemployees);
                    ser = ser.FindAll(x => x.Id == SearchId);

                    foreach (User u in ser)
                    {
                        Console.WriteLine(u.Name);
                    }

                }

                else if (number == 3)
                {
                    string code = Console.ReadLine();

                    string listofcountry = File.ReadAllText(@"country");

                    List<Country> country = JsonConvert.DeserializeObject<List<Country>>(listofcountry);

                    country = country.FindAll(x => x.Code == code);

                    foreach (Country u in country)
                    {
                        Console.WriteLine(u.Name + u.Id);
                    }

                    string searchID = Console.ReadLine();
                    int SearchID = Int32.Parse(searchID);

                    string listof = File.ReadAllText(@"user");

                    List<User> user = JsonConvert.DeserializeObject<List<User>>(listof);
                    user = user.FindAll(x => x.CountryId == SearchID);

                    foreach (User u in user)
                    {
                        Console.WriteLine(u.Name + u.Birthday);
                    }


                }

                else
                {
                    System.Environment.Exit(0);
                }
            }
            while (m != 0);

        }

        private static bool SearchByName(string keyword, User user)
        {
            if (string.IsNullOrEmpty(keyword) || user == null)
            {
                return false;
            }

            return user.Name.ToLower().Contains(keyword.ToLower().Trim());
        }

    }
}
