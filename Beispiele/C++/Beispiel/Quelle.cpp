#include <iostream>
#include <thread>
#include <chrono>

long long sum = 0; //Variable zur Speicherung der Summe

void sum_numbers(long long start, long long end)
{
  for (long long i = start; i <= end; i++)
    sum += i;
}

int main()
{
  //Starten der Zeitmessung
  auto start = std::chrono::high_resolution_clock::now();

  //Single-threaded Berechnung
  std::cout << "Single-threaded Berechnung:" << std::endl;
  sum_numbers(1, 1000000);
  std::cout << "Summe: " << sum << std::endl;

  //Berechnung der benötigten Zeit
  auto elapsed = std::chrono::high_resolution_clock::now() - start;
  auto microseconds = std::chrono::duration_cast<std::chrono::microseconds>(elapsed).count();
  std::cout << "Benoetigte Zeit (in Mikrosekunden): " << microseconds << std::endl;

  //Multi-threaded Berechnung
  sum = 0; //Zurücksetzen der Summe
  start = std::chrono::high_resolution_clock::now(); //Neustart der Zeitmessung
  std::cout << "\nMulti-threaded Berechnung:" << std::endl;
  std::thread first(sum_numbers, 1, 500000);     //Thread 1 berechnet die Summe von 1 bis 500000
  std::thread second(sum_numbers, 500001, 1000000);  //Thread 2 berechnet die Summe von 500001 bis 1000000
  first.join();                //Warten auf Thread 1
  second.join();               //Warten auf Thread 2
  std::cout << "Summe: " << sum << std::endl;

  //Berechnung der benötigten Zeit
  elapsed = std::chrono::high_resolution_clock::now() - start;
  microseconds = std::chrono::duration_cast<std::chrono::microseconds>(elapsed).count();
  std::cout << "Benoetigte Zeit (in Mikrosekunden): " << microseconds << std::endl;

  return 0;
}
