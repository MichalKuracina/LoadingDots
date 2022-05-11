# LoadingDots

Make your console applications interactive with loading animation!

Gif preview: 

![loadingdots](https://user-images.githubusercontent.com/31184485/167894158-dbc2eef7-21b7-43c8-8930-fc233acc7f45.gif)


# Example

``` csharp
using LoadingDots;
using System;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dots = new Dots("Downloading file");
            dots.Start();

            try
            {
                // do stuff
                dots.End();
            }
            catch (Exception)
            {
                dots.End("Failed");
            }

            Console.WriteLine("");
            Console.WriteLine($"Downloaded in {dots.Elapsed.TotalMilliseconds} milliseconds.");
            Console.WriteLine($"Started {dots.Started.ToString("HH:mm:ss:ff")}");
            Console.WriteLine($"Ended {dots.Ended.ToString("HH:mm:ss:ff")}");
            Console.WriteLine($"Action '{dots.Action}'");
            Console.WriteLine($"Speed '{dots.Speed}'");
        }
    }
}

```

# Console output
```
Downloading file OK

Downloaded in 7595.0666 milliseconds.
Started 17:49:07:95
Ended 17:49:13:97
Action 'Downloading file'
Speed '250'
```

# Frameworks
`netcoreapp3.1.`, `net5.0`, `net6.0`
