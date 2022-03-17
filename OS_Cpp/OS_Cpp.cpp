#include <iostream>

const int NUMBEROFOPERATIONS = 100000000;

long f(long arg, int b, int c) {
    if (arg == 0) return 0;
    int a = 0;
    for (int i = 1; i < NUMBEROFOPERATIONS; i++) {
        a += 2 * b + c - i;
    }
    return f(arg - 1, b, c) + a;
}

int main()
{
    
    std::cout << f(11, 3, 6);
}
