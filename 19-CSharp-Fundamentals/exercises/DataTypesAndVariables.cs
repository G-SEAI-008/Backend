int myAge = 35;
long worldPopulation = 12020;
float price = 12.5F;
double degrees = 34.5D;

Console.WriteLine($"Age: {myAge} World Population: {worldPopulation} Price: {price} Degress: {degrees}");

Console.Write($"Age: {myAge} World Population: {worldPopulation} Price: {price} Degress: {degrees}");

// writeline ends a newline at the end of the string

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

double distanceToSunKM = 1.5e8;
Console.WriteLine("distance to sun " + distanceToSunKM);
double electronMass = 9.109e-31;
Console.WriteLine($"electronMass {electronMass}");



int result1 = 2 + 3 * 4;
int result2 = (2 + 3) * 4;
Console.WriteLine($"Result1 {result1}");
Console.WriteLine($"Result2 {result2}");


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

Console.WriteLine($"score");

double score = 7.85D;
int truncated = (int)score;
Console.WriteLine($"{truncated}");
double rounded = Math.Round(score, 1);
Console.WriteLine($"{rounded}");
float scoreF = (float)score;
Console.WriteLine($"{scoreF}");

try
{
    checked
    {
        int max = int.MaxValue;
        Console.WriteLine($"Max int: {max}");
        // The next line will throw OverflowException if executed in checked context
        int boom = max + 1;
        Console.WriteLine($"This will not print (boom={boom})");
    }
}
catch (OverflowException)
{
    Console.WriteLine("Overflow caught in checked context");
}


unchecked
{
    int max = int.MaxValue;
    int wrapped = max + 1; // wraps to negative in unchecked context
    Console.WriteLine($"Unchecked wrap-around result: {wrapped}");
}

Console.WriteLine($"float vs double precision");

float f = 0.1F + 0.2F;
double d = 0.1D + 0.2D;
Console.WriteLine($"f{f} - d {d}");
Console.WriteLine($"{f == d}");


Console.WriteLine($"Mini Challenge");
double weightKg = 80.0D;
double heightM = 1.80D;

double bmi = weightKg / Math.Pow(heightM, 2);
Console.WriteLine($"bmi: {bmi}");


string status = bmi is > 25 or < 18.5 ? "not normal" : "normal";
Console.WriteLine($"BMI Status: {status}");



