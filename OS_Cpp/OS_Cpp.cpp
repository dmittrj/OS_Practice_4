#include <iostream>

const int NUMBEROFOPERATIONS = 100000000;

int f(int arg, int b, int c) {
    if (arg == 0) return 0;
    int a = 0;
    for (int i = 1; i < NUMBEROFOPERATIONS; i++) {
        a += 2 * b + c - i;
    }
    return f(arg - 1, b, c) + a;
}

int main()
{

    std::cout << "Hello World!\n";
}
