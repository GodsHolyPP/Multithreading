using System;
using System.Threading;
using System.Diagnostics;

class MainClass
{
  static long sum = 0; //Variable zur Speicherung der Summe
  static Stopwatch stopWatch = new Stopwatch();
  public static void Main(string[] args)
  {
    //Starten der Zeitmessung
    stopWatch.Start();

    //Single-threaded Berechnung
    Console.WriteLine("Single-threaded Berechnung:");
    SumNumbers(1, 1000000);
    Console.WriteLine("Summe: " + sum);

    //Berechnung der benötigten Zeit
    stopWatch.Stop();
    TimeSpan ts = stopWatch.Elapsed;
    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
        ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
    Console.WriteLine("Benötigte Zeit : " + elapsedTime);

    //Multi-threaded Berechnung
    sum = 0; //Zurücksetzen der Summe
    stopWatch.Reset();
    stopWatch.Start();
    Console.WriteLine("\nMulti-threaded Berechnung:");
    Thread first = new Thread(() => SumNumbers(1, 500000));
    first.Start();
    Thread second = new Thread(() => SumNumbers(500001, 1000000));
    second.Start();
    first.Join();
    second.Join();
    Console.WriteLine("Summe: " + sum);

    //Berechnung der benötigten Zeit
    stopWatch.Stop();
    ts = stopWatch.Elapsed;
    elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
        ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
    Console.WriteLine("Benötigte Zeit : " + elapsedTime);
  }

  public static void SumNumbers(long start, long end)
  {
    for (long i = start; i <= end; i++)
      sum += i;
  }
}
