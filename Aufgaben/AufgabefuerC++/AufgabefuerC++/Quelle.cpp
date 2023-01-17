#include <iostream>
#include <thread>

int n = 1000;
int sum1 = 0;
int sum2 = 0;

void calculateSum1() {
  for (int i = 1; i <= n / 2; i++)
    sum1 += i;
}

void calculateSum2() {
 // Definiere diese Funktion
}

int main() {
  std::cout << "Calculating sum of first " << n << " natural numbers..." << std::endl;
  std::thread t1(calculateSum1);
  std::thread t2(calculateSum2);
        //Hier Fehlen zwei Zeilen Code die die Reihenfolge der Threads regeln 
        //Hier Fehlen zwei Zeilen Code die die Reihenfolge der Threads regeln 
  int totalSum = sum1 + sum2;
  std::cout << "Sum: " << totalSum << std::endl;
  return 0;
}
