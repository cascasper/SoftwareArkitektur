using LinQ;

Person[] people = new Person[]
   {
    new Person { Name = "Jens Hansen", Age = 45, Phone = "+4512345678" },
    new Person { Name = "Jane Olsen", Age = 22, Phone = "+4543215687" },
    new Person { Name = "Tor Iversen", Age = 35, Phone = "+4587654322" },
    new Person { Name = "Sigurd Nielsen", Age = 31, Phone = "+4512345673" },
    new Person { Name = "Viggo Nielsen", Age = 28, Phone = "+4543217846" },
    new Person { Name = "Rosa Jensen", Age = 23, Phone = "+4543217846" },   
   };

/*Udregning af den samlede alder for alle mennesker */
int totalAge = people.Sum(person => person.Age);

/* Tælle hvor mange der hedder "Nielsen" */
int countNielsen = people.Count(person => person.Name.Contains("Nielsen"));

/* Find og udskriv den ældste person */
Person oldestPerson = people.OrderByDescending(person => person.Age).FirstOrDefault();

/* find og udskriv navn og telefonnummer på den person, der har telefonnummeret +4543215687 */
var personWithSpecificPhone = people.FirstOrDefault(person => person.Phone == "+4543215687");
if (personWithSpecificPhone != null)
{
    Console.WriteLine($"{personWithSpecificPhone.Name} - {personWithSpecificPhone.Phone}");
}

/* vælg alle personer over 30 år og udskriv navn og alder */
var peopleOver30 = people.Where(person => person.Age > 30);
foreach (var person in peopleOver30)
{
    Console.WriteLine($"{person.Name} - {person.Age}");
}


/* Lav et nyt array med de samme personer, men hvor “+45” er fjernet fra alle telefonnumre */
var modifiedPeople = people.Select(person => new Person
{
    Name = person.Name,
    Age = person.Age,
    Phone = person.Phone.Replace("+45", "")
}).ToArray();

/* Generér en string med navn og telefonnummer på de personer, der er yngre end 30, adskilt med komma */
var youngPeopleInfo = string.Join(", ", people
    .Where(person => person.Age < 30)
    .Select(person => $"{person.Name} - {person.Phone}"));
Console.WriteLine(youngPeopleInfo);