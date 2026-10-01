
var employees = new List<Employee>
{
    new Employee { Id = 1, Name = "Aisha", Department = "Engineering" },
    new Employee { Id = 2, Name = "Jonas", Department = "Design" },
    new Employee { Id = 3, Name = "Priya", Department = "Engineering" },
    new Employee { Id = 4, Name = "Luca", Department = "Marketing" },
};

var assignments = new List<ProjectAssignment>
{
    new ProjectAssignment { EmployeeId = 1, Project = "Website Redesign" },
    new ProjectAssignment { EmployeeId = 1, Project = "Payment Gateway" },
    new ProjectAssignment { EmployeeId = 2, Project = "Website Redesign" },
    new ProjectAssignment { EmployeeId = 3, Project = "Data Migration" },
    new ProjectAssignment { EmployeeId = 4, Project = "Social Media Campaign" },
};



var employeesProjects = employees.Join(assignments, e => e.Id, a => a.EmployeeId, (e, a) => new { e.Name, a.Project });

foreach (var el in employeesProjects)
{
    Console.WriteLine($"{el.Name} -> {el.Project}");
}

var employeeProjectsQuery = from e in employees
                            join a in assignments on e.Id equals a.EmployeeId
                            select new { e.Name, a.Project };

// Group by

Console.WriteLine($"\nGroup By");

var employeesByDpt = employees.GroupBy(e => e.Department);
foreach (var g in employeesByDpt)
{
    Console.WriteLine($"{g.Key}");
    foreach (var e in g)
    {
        Console.WriteLine($"\t{e.Name}");
    }
}


var assignmentsProjects = assignments.GroupBy(a => a.Project);

foreach (var group in assignmentsProjects)
{
    Console.WriteLine($"{group.Key}");

    foreach (var el in group)
    {
        Console.WriteLine($"\t Employee ID: {el.EmployeeId}");
    }

}


var groupJoin = employees.GroupJoin(assignments, e => e.Id, a => a.EmployeeId, (e, asg) => new { e.Name, Projects = asg });

foreach (var group in groupJoin)
{
    Console.WriteLine($"{group.Name}");

    foreach (var p in group.Projects)
    {
        Console.WriteLine($"\t{p.Project}");
    }
}

var deptCounts = employees.GroupBy(e => e.Department).Select(g => new { Department = g.Key, Count = g.Count() });

foreach (var d in deptCounts)
{
    Console.WriteLine($"{d.Department}: {d.Count}");
}

var projectEmployees = assignments.Join(employees, a => a.EmployeeId, e => e.Id, (a, e) => new { a.Project, e.Name }).GroupBy(x => x.Project);

foreach (var g in projectEmployees)
{
    Console.WriteLine($"{g.Key}");

    foreach (var e in g)
    {
        Console.WriteLine($"\t{e.Name}");
    }
}