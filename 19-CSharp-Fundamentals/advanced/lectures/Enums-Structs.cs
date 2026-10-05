#:property PublishAot=false
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;

DayOfWeek today = DayOfWeek.Wednesday;

// if (today == DayOfWeek.Wednesday)
// {
//     Console.WriteLine($"Today is wednesday");
// }


// switch (today)
// {
//     case DayOfWeek.Friday:
//         Console.WriteLine($"It's friday");
//     default:
//         Console.WriteLine($"");
// }



Console.WriteLine($"{OrderStatus.Paid}");
int number = (int)OrderStatus.Pending;
Console.WriteLine($"{number}");
var fromNumber = (OrderStatus)2;
Console.WriteLine($"{fromNumber}");


var parsed = Enum.Parse<OrderStatus>("Delivered");
Console.WriteLine($"{parsed}");


if (Enum.TryParse("pending", ignoreCase: true, out OrderStatus fromInput))
{
    Console.WriteLine($"{fromInput}");
}


Console.WriteLine($"\nJSON");


var options = new JsonSerializerOptions();
options.Converters.Add(new JsonStringEnumConverter());
Console.WriteLine($"{JsonSerializer.Serialize(OrderStatus.Paid, options)}");



Console.WriteLine($"\n Structs");

var p1 = new Point { X = 5, Y = 10 };
var p2 = new Point { X = 5, Y = 10 };




p1.X = 25;
// Console.WriteLine($"{p1 == p2}");
Console.WriteLine($"{p1.Equals(p2)}");


Console.WriteLine($"\nRecord Struct");
var pR1 = new PointRecord(5, 10);
var pR2 = new PointRecord(5, 10);

// pR1.X = 10;
Console.WriteLine($"{pR1 == pR2}");


Console.WriteLine($"\n Readonly record struct");
var s1 = new Size(100, 200);
var s2 = new Size(100, 200);

var s3 = s1 with { Width = 150 };

Console.WriteLine($"{s1.Width}");
Console.WriteLine($"{s3.Width}");







enum DayOfWeek { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };



// [JsonConverter(typeof(JsonStringEnumConverter<OrderStatus>))]
enum OrderStatus
{
    Pending = 1,
    Paid = 2,
    Shipped = 3,
    Delivered = 4
};


struct Point
{
    public int X;
    public int Y;
}


public record struct PointRecord(int X, int Y);

public readonly record struct Size(int Width, int Height);


