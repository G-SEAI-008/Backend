/* arrays  T[]
 feste Länge

 */


/* List<T>
 * basieren auf Arrays - flexible zu vergrößern
*/



// int[] scores = [1, 2, 3, 4, 5];
// int currentSize = 5;

// int thirdScore = scores[2];
// Console.WriteLine($"{thirdScore}");

// PrintArray(scores, 5);

// void PrintArray(int[] arr, int size)
// {
//     for (int i = 0; i < size; i++)
//     {
//         Console.WriteLine($"{arr[i]}");
//     }
// }
// ;


// scores[1] = 90;

// int target = 90;
// int foundIndex = -1;

// for (int i = 0; i < currentSize; i++)
// {
//     if (scores[i] == target)
//     {
//         foundIndex = i;
//         break;
//     }
// }

// Console.WriteLine($"Target value at index {foundIndex}");



// List

// List<string> inventory = ["Health Potion", "Icon Shield"];


// inventory.Add("Steel Sword");
// inventory.Add("Mana Potion");

// inventory.Insert(1, "Antidote");


// foreach (var el in inventory)
// {
//     Console.WriteLine($"{el}");
// }

// Console.WriteLine($"Access by index");
// Console.WriteLine($"{inventory[0]}");


// bool hasSchield = inventory.Contains("Iron Shield");
// int swordIndex = inventory.IndexOf("Steel Sword");

// inventory[2] = "Tower Shield";


// inventory.Remove("Health Potion");

// inventory.RemoveAt(0);




Student firstStudent = new(1, "Karl", 3.2);
Console.WriteLine($"{firstStudent}");


GradeBookManager manager = new();

manager.AddStudent(new Student(2, "Hannah", 1.2));

manager.DisplayAll();



class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Grade { get; set; }


    public Student(int id, string name, double grade)
    {
        Id = id;
        Name = name;
        Grade = grade;
    }


    public override string ToString()
    {
        return $"[ID: {Id}] Name: {Name} | Grade: {Grade}";
    }
}



class GradeBookManager
{
    private readonly List<Student> _students = new List<Student>();

    public bool AddStudent(Student student)
    {

        if (student == null) return false;

        if (FindIndexById(student.Id) != -1)
        {
            Console.WriteLine($"Student already exists");
            return false;
        }

        _students.Add(student);
        Console.WriteLine($"Student added");

        return true;
    }


    public Student? GetStudentById(int id)
    {
        int index = FindIndexById(id);
        if (index == -1)
        {
            return null;
        }
        return _students[index];
    }

    public void DisplayAll()
    {
        if (_students.Count == 0)
        {
            Console.WriteLine($"No student records found");
            return;
        }

        foreach (var student in _students)
        {
            Console.WriteLine($"{student}");
        }
    }


    private int FindIndexById(int id)
    {
        for (int i = 0; i < _students.Count; i++)
        {
            if (_students[i].Id == id)
            {
                return i;
            }
        }
        return -1;
    }
}