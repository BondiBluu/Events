﻿namespace Events

{
    //making a delegate that takes generics to make multiple methods about them
    public delegate int ComparisonOfGeneric<T>(T first, T second);

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class PersonSorter
    {
        //sorting people based on the comparison of the names. Comparison- a delegate that takes two people and returns an int

        public void Sort(Person[] people, Comparison<Person> comparison)
        {
            //making a double loop to compare each person with the other. length -1 and i+1 to have i be the first person and j be the second person and so on
            for (int i = 0; i < people.Length - 1; i++)
            {
                for (int j = i + 1; j < people.Length; j++)
                {
                    //if the comparison is greater than 0, then the first person is greater than the second person
                    if (comparison(people[i], people[j]) > 0)
                    {
                        //storing the person in a temp variable to swap them when the above rings true. Make i a temp, make j actually i, and make j temp, what i was.
                        Person temp = people[i];
                        people[i] = people[j];
                        people[j] = temp;
                    }
                }

            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                Person[] people = new Person[]
                {
                    new Person { Name = "John", Age = 30 },
                    new Person { Name = "Jane", Age = 25 },
                    new Person { Name = "Jack", Age = 40 }
                };

                PersonSorter sorter = new PersonSorter();

                //taking the people array and sorting it by the comparison of the names
                sorter.Sort(people, CompareByAge);

                foreach (Person person in people)
                {
                    Console.WriteLine($"{person.Name} ({person.Age})");
                }

                Console.WriteLine();
                
                sorter.Sort(people, CompareByName);

                foreach (Person person in people)
                {
                    Console.WriteLine($"{person.Name} ({person.Age})");
                }

            }
        }

        static int CompareByAge(Person first, Person second)
        {
            //comparing the ages of the two people
            return first.Age.CompareTo(second.Age);
        }

        static int CompareByName(Person first, Person second)
        {
            //comparing the names of the two people
            return first.Name.CompareTo(second.Name);
        }
    }
}
