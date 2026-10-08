using System.Diagnostics;

async Task<string> SimulateDownloadAsync(string fileName, int ms)
{
    Console.WriteLine($"Starting {fileName} ({ms} ms)");

    // Fail fast rule for the exercise
    if (fileName.Contains("fail", StringComparison.OrdinalIgnoreCase))
    {
        // small delay to show asynchrony even when failing
        await Task.Delay(150);
        throw new InvalidOperationException($"Download failed for '{fileName}'.");
    }

    // Simulate I/O latency
    await Task.Delay(ms);

    Console.WriteLine($"Finished {fileName}");
    return $"Content of {fileName}";
}

// Optional spinner that proves we aren't blocking the thread while awaiting
async Task SpinnerUntilCompleted(Task t)
{
    var frames = new[] { '|', '/', '-', '\\' };
    var i = 0;
    while (!t.IsCompleted)
    {
        Console.Write($"\rWorking {frames[i++ % frames.Length]}");
        await Task.Delay(100); // yields; caller thread is free between ticks
    }
    Console.WriteLine("\rDone            ");
}

// ------------------------------
// Demos (sequential vs parallel)
// ------------------------------

var sw = Stopwatch.StartNew();
#region sequential
Console.WriteLine("== Sequential downloads ==");
var a = await SimulateDownloadAsync("fileA.txt", 1000);
var b = await SimulateDownloadAsync("fileB.txt", 1200);
sw.Stop();
Console.WriteLine($"Sequential elapsed: {sw.ElapsedMilliseconds} ms\n");
#endregion


#region parallel
// Console.WriteLine("== Parallel downloads (Task.WhenAll) ==");
// sw.Restart();
// var t1 = SimulateDownloadAsync("fileC.txt", 1000);
// var t2 = SimulateDownloadAsync("fileD.txt", 1200);
// var results = await Task.WhenAll(t1, t2);
// sw.Stop();
// Console.WriteLine($"Parallel elapsed:  {sw.ElapsedMilliseconds} ms");
// Console.WriteLine($"Results: [{string.Join(", ", results)}]\n");

#endregion

#region error handling
// Console.WriteLine("== Error handling with async/await ==");
// try
// {
//     var bad = await SimulateDownloadAsync("fail_me.txt", 500);
//     Console.WriteLine(bad); // won't reach here
// }
// catch (Exception ex)
// {
//     Console.WriteLine($"Caught error: {ex.Message}\n");
// }
#endregion

#region spinner
// Console.WriteLine("== Non-blocking spinner while downloads run ==");
// var longTask = Task.WhenAll(
//     SimulateDownloadAsync("fileE.txt", 2000),
//     SimulateDownloadAsync("fileF.txt", 2200)
// );
// var spin = SpinnerUntilCompleted(longTask);
// await Task.WhenAll(longTask, spin);
// Console.WriteLine("All done.");
#endregion
