// Document hierarchy
var doc = new Document("Project Overview");
var report = new Report("Q2 Results", "Amira");
var invoice = new Invoice("INV-2025-001", 1299.99m);

Document[] docs = { doc, report, invoice };
foreach (var d in docs) d.PrintInfo(); // virtual dispatch to overrides

Console.WriteLine();

// Shape hierarchy: hiding vs overriding
Shape s1 = new Shape();
Shape s2 = new Square();
Shape s3 = new Circle();
Circle c = new Circle();

s1.Draw();        // Shape.Draw
s2.Draw();        // Square.Draw (overridden)
s3.Draw();        // Shape.Draw (because Circle hides, base ref calls base)
c.Draw();         // Circle.Draw (hidden method visible via Circle ref)

Console.WriteLine();

// Membership hierarchy
Membership m1 = new Membership("Lina");
Membership m2 = new StandardMembership("Jonas");
Membership m3 = new PremiumMembership("Aisha");
Membership m4 = new LifetimeMembership("Omar");

foreach (var m in new[] { m1, m2, m3, m4 })
{
    Console.WriteLine($"{m.MemberName}: {m.GetBenefits()}");
}
class Document
{
    public string Title { get; set; }

    public Document(string title)
    {
        Title = title;
    }
    public virtual void PrintInfo()
    {
        Console.WriteLine($"Title: {Title}");
    }
}

class Report : Document
{
    public string Author { get; set; }

    public Report(string title, string author) : base(title)
    {
        Author = author;
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Author: {Author}");

    }
}

class Invoice : Document
{
    public decimal Amount { get; set; }

    public Invoice(string title, decimal amount) : base(title)
    {
        Amount = amount;
    }


    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Amount: {Amount}");
    }
}



class Shape
{
    public virtual void Draw() => Console.WriteLine("Shape.Draw");
}


class Circle : Shape
{
    public new void Draw() => Console.WriteLine("Circle.Draw (hidden)");
}

class Square : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Square.Draw (overridden)");
    }
}


class Membership
{
    public string MemberName { get; set; }

    public Membership(string name)
    {
        MemberName = name;
    }

    public virtual string GetBenefits()
    {
        return "Acces to members' newsletter";
    }
}

class StandardMembership : Membership
{
    public StandardMembership(string name) : base(name) { }
    public override string GetBenefits()
    {
        return "Newsletter + Standard support";
    }
}

class PremiumMembership : Membership
{
    public PremiumMembership(string name) : base(name) { }

    public override string GetBenefits() => "Newsletter + Priority support + Lounge access";
}

sealed class LifetimeMembership : Membership
{
    public LifetimeMembership(string name) : base(name) { }

    public sealed override string GetBenefits() => "All benefits for life + Concierge";
}