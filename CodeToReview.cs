using System;
// First Issue: It should be using System.Collegctions.Generic;
using System.Collegctions.Generic;
using System.Linq;

namespace Utility.Valocity.ProfileHelper
{
    // It can be Person 
    public class People
    {
        // here it should be  private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-16) or name can be Under15
     private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-15);
     public string Name { get; private set; }
     public DateTimeOffset DOB { get; private set; }
     public People(string name) : this(name, Under16.Date) { }
     public People(string name, DateTime dob) {
         Name = name;
         DOB = dob;
     }}

    public class BirthingUnit
    {
        /// <summary>
        /// MaxItemsToRetrieve
        /// </summary>
        private List<People> _people;

        public BirthingUnit()
        {
            _people = new List<People>();
        }

        /// <summary>
        /// GetPeoples
        /// </summary>
        /// <param name="j"></param>
        /// <returns>List<object></returns>
        public List<People> GetPeople(int i)
        {
            // i can be count
            for (int j = 0; j < i; j++)
            {
                try
                {
                    // Creates a dandon Name
                    string name = string.Empty;
                    // It can be created outside
                    var random = new Random();
                    // It will always be zero so, else case can be removed, because in random first number is inclusive, second one is exclusive
                    if (random.Next(0, 1) == 0) {
                        name = "Bob";
                    }
                    else {
                        name = "Betty";
                    }
                    // Adds new people to the list
                    // 356 should be 365 also here leap year is ignored
                    _people.Add(new People(name, DateTime.UtcNow.Subtract(new TimeSpan(random.Next(18, 85) * 356, 0, 0, 0))));
                }
                catch (Exception e)
                {
                    // Dont think this should ever happen, also here we should throw exception in case if any for more clarification or log in file
                    throw new Exception("Something failed in user creation");
                }
            }
            return _people;
        }

        private IEnumerable<People> GetBobs(bool olderThan30)
        {
            // here again 365 should be there, also x.DOB <= DateTime.Now.Subtract(new TimeSpan(30 * 365, 0, 0, 0))
            return olderThan30 ? _people.Where(x => x.Name == "Bob" && x.DOB >= DateTime.Now.Subtract(new TimeSpan(30 * 356, 0, 0, 0))) : _people.Where(x => x.Name == "Bob");
        }

        public string GetMarried(People p, string lastName)
        {
            if (lastName.Contains("test"))
                return p.Name;
            // this code can be removed since substring data is not assigned to some variable
            if ((p.Name.Length + lastName).Length > 255)
            {
                (p.Name + " " + lastName).Substring(0, 255);
            }

            return p.Name + " " + lastName;
        }
    }
}
