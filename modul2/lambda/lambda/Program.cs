using System;
using System.Linq;

public class Person
{
    public int Age { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
}

public class BubbleSort
{
    private static void Swap(Person[] array, int i, int j)
    {
        Person temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    public static void Sort(Person[] array, Func<Person, Person, int> compareFn)
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            for (int j = 0; j <= i - 1; j++)
            {
                if (compareFn(array[j], array[j + 1]) > 0)
                {
                    Swap(array, j, j + 1);
                }
            }
        }
    }
}

public class Program
{
    public static Func<Person[], Person[]> CreateSorter(Func<Person, Person, int> compareFn)
    {
        return (people) =>
        {
            Person[] sortedPeople = (Person[])people.Clone();
            BubbleSort.Sort(sortedPeople, compareFn);
            return sortedPeople;
        };
    }

    public static void Main()
    {
        // Initialiserer et eksempel array af Person objekter
        Person[] people = new Person[] {
            new Person { Age = 30, Name = "Alice", PhoneNumber = "555-1234" },
            new Person { Age = 25, Name = "Bob", PhoneNumber = "555-2345" },
            new Person { Age = 28, Name = "Charlie", PhoneNumber = "555-3456" }
        };

        // Lambda-funktioner til sammenligning
        Func<Person, Person, int> compareByAge = (p1, p2) => p1.Age.CompareTo(p2.Age);
        Func<Person, Person, int> compareByName = (p1, p2) => string.Compare(p1.Name, p2.Name);
        Func<Person, Person, int> compareByPhone = (p1, p2) => string.Compare(p1.PhoneNumber, p2.PhoneNumber);

        // Sortering af arrayet ved hjælp af de definerede lambda-funktioner
        BubbleSort.Sort(people, compareByAge);
        Console.WriteLine("Sorted by Age:");
        foreach (var person in people)
        {
            Console.WriteLine($"{person.Name} - Age: {person.Age}, Phone: {person.PhoneNumber}");
        }

        BubbleSort.Sort(people, compareByName);
        Console.WriteLine("\nSorted by Name:");
        foreach (var person in people)
        {
            Console.WriteLine($"{person.Name} - Age: {person.Age}, Phone: {person.PhoneNumber}");
        }

        BubbleSort.Sort(people, compareByPhone);
        Console.WriteLine("\nSorted by Phone Number:");
        foreach (var person in people)
        {
            Console.WriteLine($"{person.Name} - Age: {person.Age}, Phone: {person.PhoneNumber}");
        }

        // Opgave 5: Anvendelse af CreateSorter funktionen
        var peopleSortAge = CreateSorter(compareByAge);
        var sortedPeopleByAge = peopleSortAge(people);

        Console.WriteLine("\nSorted by Age using CreateSorter:");
        sortedPeopleByAge.ToList().ForEach(p => Console.WriteLine($"{p.Age} {p.Name}"));
    }
}