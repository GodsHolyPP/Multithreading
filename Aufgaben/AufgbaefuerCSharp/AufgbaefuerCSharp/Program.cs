using System;
using System.Threading;

class ThreadExample
{
  static void Main()
  {
    Console.WriteLine("Calculating factorials...");

    int number1 = 5;
    int number2 = 8;

    Thread t1 = new Thread(() => Factorial(number1));
    Thread t2 = new Thread(() => Factorial(number2));
    //Starte hier die Threads
    //Starte hier die Threads

    // Definiere die Reihenfolgde der Threads
    // Definiere die Reihenfolgde der Threads

    Console.WriteLine("Factorials calculated!");
  }

  static void Factorial(int number)
  {
    int result = 1;
    for (int i = 1; i <= number; i++)
    {
      result *= i;
    }
    Console.WriteLine("Factorial of " + number + " is: " + result);
  }
}
