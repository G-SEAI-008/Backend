// datatypes
// numbers
// int
using System.Globalization;
using System.Text;

int count = 12;
Console.WriteLine($"{default(int)}");
Console.WriteLine($"{sizeof(int)}");
Console.WriteLine($"Max int: {int.MaxValue:N0}");
Console.WriteLine($"Min int: {int.MinValue:N0}");

// long
long worldPopulation = 12030020200;
Console.WriteLine($"\nLong");
Console.WriteLine($"{default(long)}");
Console.WriteLine($"{sizeof(long)}");
Console.WriteLine($"Max long: {long.MaxValue:N0}");
Console.WriteLine($"Min long: {long.MinValue:N0}");


// float
float price = 12.5F;
Console.WriteLine($"\nFloat");
Console.WriteLine($"{default(float)}");
Console.WriteLine($"{sizeof(float)}");
Console.WriteLine($"Max float: {float.MaxValue:N0}");
Console.WriteLine($"Min float: {float.MinValue:N0}");
// double
double degrees = 34.5D;
Console.WriteLine($"\nDouble");
Console.WriteLine($"{default(double)}");
Console.WriteLine($"{sizeof(double)}");
Console.WriteLine($"Max double: {double.MaxValue:N0}");
Console.WriteLine($"Min double: {double.MinValue:N0}");

// decimal
decimal salary = 1000000000.23M;
Console.WriteLine($"\nDecimal");
Console.WriteLine($"{default(decimal)}");
Console.WriteLine($"{sizeof(decimal)}");
Console.WriteLine($"Max decimal: {decimal.MaxValue:N0}");
Console.WriteLine($"Min decimal: {decimal.MinValue:N0}");


var myAge = 24;

Console.WriteLine($"Age: {myAge}");


int a = 10; int b = 3;
Console.Write("\n"); Console.WriteLine(a + b);
Console.WriteLine(a - b);
Console.WriteLine(a * b);
Console.WriteLine(a / b);
Console.WriteLine(a % b);

Console.WriteLine((double)a / b);

Console.WriteLine(a > 5);
Console.WriteLine(a < 5);
Console.WriteLine(a == b);
Console.WriteLine(a != b);

Console.WriteLine(a > 5 && b < 10);
Console.WriteLine(a > 5 || b < 10);
Console.WriteLine(!(a == 5));

Console.WriteLine($"counter");
int counter = 0;
Console.WriteLine($"{counter}");
counter += 5;
Console.WriteLine($"{counter}");
counter = 10;
Console.WriteLine($"{counter}");
counter /= 2;
Console.WriteLine($"{counter}");
counter++;
Console.WriteLine($"{counter}");


double score = 7.85D;
int truncated = (int)score;
Console.WriteLine($"{truncated}");

var result = (double)10 / 3;
Console.WriteLine($"{result}");


try
{
    checked
    {
        int max = int.MaxValue;
        int boom = max + 1;
        Console.WriteLine($"What is happening?");
    }
}
catch (OverflowException)
{
    Console.WriteLine($"Overflow caught");

}


int max2 = int.MaxValue;
int wrapped = max2 + 1; // wraps to negative in unchecked context
Console.WriteLine($"Unchecked wrap-around result: {wrapped}");


string status = myAge > 18 ? "go" : "don't go";

// strings

string regular = "Hello World";
char letter = 'A';

string path = @"C:\User\Name\Documents";

string raw = """
"Hello", said the program.
        This supports multi-line
""";
Console.WriteLine($"{raw}");


// interpolation
string name = "Alice";
string interpolated = $"User: {name}";

string concat = "Hello " + name;

string phrase = "The quick brown fox jumps";

bool hasFox = phrase.Contains("fox");
int index = phrase.IndexOf("brown");
bool starts = phrase.StartsWith("The");


string emptyText = "";
string whiteSpaceText = "    ";

bool checkEmpty = string.IsNullOrEmpty(emptyText);
bool checkBlank = string.IsNullOrWhiteSpace(whiteSpaceText);


string input = "    c# Programming  ";

string upper = input.ToUpper();
string trimmed = input.Trim();

string replaced = input.Replace("C#", ".NET");

string removed = trimmed.Remove(0, 3);


string text = "Hello World";

int length = text.Length;

char firstChar = text[0];
string subString = text.Substring(0, 5);



string fruits = "apple,banana,orange";

string[] items = fruits.Split(",");
string combined = string.Join(" | ", items);
Console.WriteLine($"{combined}");



// comparing
string text2 = "HELLO WORLD";

Console.WriteLine($"{text == text2}");
Console.WriteLine($"{text.Equals(text2)}");
Console.WriteLine($"{text.Equals(text2, StringComparison.OrdinalIgnoreCase)}");


Console.WriteLine($"{CultureInfo.CurrentCulture.Name}");



string[] logEntries = ["User logged in", "Updated profile", "Exported report", "User logged out"];

var sb = new StringBuilder();

string start = "";


for (int i = 0; i < logEntries.Length; i++)
{
    sb.Append($"Entry: {logEntries[i]}\n");
    start += $"Entry: {logEntries[i]}\n";
}

string finalString = sb.ToString();

Console.WriteLine($"{finalString}");


// condition ? trueVal: falseVal


string result3 = null ?? "maybe";


object data = "Hello C#";

// compile time datatype
// runtime data type


if (data is string message)
{
    Console.WriteLine($"{message.ToUpper()}");

}
else
{
    Console.WriteLine($"{data}");

}


string userAge = "20";

bool isValid = int.TryParse(userAge, out int userAgeInt);
Console.WriteLine($"{userAgeInt}");
