// Task
// Task<T>
// 


class Program
{
    public static async Task Main(string[] args)
    {

        Console.WriteLine($"Starting the application....\n");
        Console.WriteLine($"Requesting user data...");


        // wait for result
        // var user = await FetchUserDataAsync();
        // Console.WriteLine($"Result: {user}");

        // var backgroundTask = FetchUserDataAsync();
        // DoSomethingElse();
        // var user = await backgroundTask;
        // Console.WriteLine($"{user}");


        // string backgroundTask1 = await FetchUserDataAsync();
        // string backgroundTask2 = await FetchUserDataAsync();
        // string backgroundTask3 = await FetchUserDataAsync();
        // Console.WriteLine($"{backgroundTask1}");
        // Console.WriteLine($"{backgroundTask2}");
        // Console.WriteLine($"{backgroundTask3}");


        // var fetchAllUser = await Task.WhenAll(FetchUserDataAsync(), FetchUserDataAsync(), FetchUserDataAsync());


        // foreach (var r in fetchAllUser)
        // {
        //     Console.WriteLine($"{r}");
        // }


        // var fetchingAllAgain = Task.WhenAll(FetchUserDataAsync(), FetchUserDataAsync(), FetchUserDataAsync());
        // var spinner = Loader(fetchingAllAgain);
        // await Task.WhenAll(fetchingAllAgain, spinner);


        var todos = await FetchDataAsync("https://jsonplaceholder.typicode.com/todos");
        Console.WriteLine($"{todos}");
    }




    static async Task<string> FetchUserDataAsync()
    {
        Console.WriteLine($"Request started");
        await Task.Delay(6000);
        Console.WriteLine($"Data received");
        return "User Karl";
    }

    static void DoSomethingElse()
    {
        Console.WriteLine($"\nDo stuff...");
        Console.WriteLine($"Do more stuff...\n");
    }


    static async Task Loader(Task t)
    {
        var frames = new[] { ".", "-", "*", "-" };
        var i = 0;

        while (!t.IsCompleted)
        {
            Console.Write($"{frames[i % frames.Length]} \r");
            i++;
            await Task.Delay(100);
        }
    }

    static async Task<object> FetchDataAsync(string url)
    {
        using var client = new HttpClient();
        var data = await client.GetStringAsync(url);
        return data;
    }
}