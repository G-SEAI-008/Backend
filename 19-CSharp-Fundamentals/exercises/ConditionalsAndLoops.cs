
Console.Write("Enter your age: ");
string ageInput = Console.ReadLine()!;
if (!int.TryParse(ageInput, out int age))
{
    Console.WriteLine("Invalid age. Using default age = 20");
    age = 20;
}

if (age < 13)
{
    Console.WriteLine("Your are a child");
}
else if (age < 20)
{
    Console.WriteLine("Your are a teenager.");
}
else
{
    Console.WriteLine("You are an adult");
}


string category = (age < 13) ? "Child" : (age < 20) ? "Teenager" : "Adult";
Console.WriteLine($"(Ternary) Category: {category}");

// Switch
// 
Console.WriteLine("Enter a grad (A, B, C, D, F): ");
string grade = (Console.ReadLine() ?? string.Empty).Trim();

// switch (grade)
// {
//     case "A":
//         Console.WriteLine("Excellent");
//         break;
//     case "B":
//         Console.WriteLine("Good");
//         break;
//     case "C":
//         Console.WriteLine("Average");
//         break;
//     case "D":
//         Console.WriteLine("Below average");
//         break;
//     case "F":
//         Console.WriteLine("Fail");
//         break;
//     default:
//         Console.WriteLine("Unknown grade");
//         break;
// }


// bonus switch expression
string message = grade switch
{
    "A" => "Excellent",
    "B" => "Good",
    "C" => "Average",
    "D" => "Below average",
    "F" => "Fail",
    _ => "Hopeless"

};
Console.WriteLine(message);



// while loop

int sum = 0;
int i = 1;
while (i <= 100)
{
    sum += 1;
    i++;
}

Console.WriteLine($"Sum 1..100 = {sum}");


int target = 7;
int guess;
do
{
    Console.WriteLine("Guess a number between 1 and 10: ");
    string input = Console.ReadLine()!;
    if (!int.TryParse(input, out guess))
    {
        Console.WriteLine("Please enter digits only");
        guess = -1;
        continue;
    }

    if (guess < target)
    {
        Console.WriteLine("Too low, try again.");
    }
    else if (guess > target)
    {
        Console.WriteLine("Too high", "try again.");
    }
} while (guess != target);
Console.WriteLine("Correct!");


for (int n = 1; n <= 10; n++)
{
    Console.WriteLine($"7 x {n} = {7 * n}");
}

for (int k = 1; k <= 20; k++)
{
    if (k % 2 == 0) continue;
    if (k == 15) break;
    Console.Write(k + " ");
}
Console.WriteLine("");