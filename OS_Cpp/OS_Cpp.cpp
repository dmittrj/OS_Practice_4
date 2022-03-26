#include <iostream>
#include <stdio.h>
#include <windows.h>
#include <fstream>

const int NUMBEROFOPERATIONS = 100000000;

long long f(long arg, int b, int c) {
    if (arg == 0) return 0;
    long long a = 0;
    for (int i = 1; i < NUMBEROFOPERATIONS; i++) {
        a += (long long)2 * (long long)b + (long long)c - (long long)arg;
    }
    return f(arg - 1, b, c) + a;
}

int parse(char c[]) {
    int a = 0;
    for (int i = strlen(c) - 1; i >= 0; i--) {
        int power = 1;
        for (int j = 0; j < strlen(c) - i - 1; j++) power *= 10;
        if ((c[i] >= '0') && (c[i] <= '9')) a += (c[i] - 48) * power;
    };
    return a;
}

void parsefile(char p[], int& b, int& c, int& i_max) {
    int index = 0;
    int symbol = 0;
    char vars[3][10];
    for (int i = 0; i < 3; i++)
        for (int j = 0; j < 10; j++)
            vars[i][j] = '\0';
    for (int i = 0; i < strlen(p); i++) {
        char temp = p[i];
        if (temp == ',') {
            index++;
            symbol = 0;
        } else vars[index][symbol++] = p[i];
    }
    b = parse(vars[0]);
    c = parse(vars[1]);
    i_max = parse(vars[2]);
}

int main()
{
    setlocale(LC_ALL, "Russian");
    float time;
    std::ifstream info;
    info.open("OS_Info.txt", std::ios_base::in);
    char* p = new char[20];
    if (info.is_open()) {
        info >> p;
    }
    else {
        std::cout << "Программа OS_Cpp готова. Вы можете её закрыть\n\n";
        return 0;
    }
    info.close();
    int b;
    int c;
    int i_max;
    parsefile(p, b, c, i_max);
    std::cout << "Начинается подсчёт..." << std::endl;
    clock_t ts = clock();
    long long result = f(i_max, b, c);
    time = ((float)(clock() - ts)) / CLOCKS_PER_SEC;
    std::cout << "Результат работы программы на C++:" << std::endl;
    std::cout << "  - Ответ: " << result << std::endl;
    std::cout << "  - Время: " << time << " секунд" << std::endl;
    std::ofstream res;
    res.open("OS_CppResult.txt", std::ios_base::trunc | std::ios_base::binary);
    res << result << "," << time;
    res.close();
    return 0;
}
