#include <iostream>
#include <stdio.h>
#include <windows.h>
#include <fstream>

const int NUMBEROFOPERATIONS = 100000000;

long long f(int arg, int b, int c) {
    if (arg == 0) return 0;
    char curarg = (char)(arg);
    char curb = (char)b;
    char curc = (char)c;
    short ress;

    __asm {
        mov Bl, 2
        mov Dx, 0
        mov ECX, 30000
        L1:
        mov al, curb
            mul bl
            Push dx
            mov dl, curc
            mov dh, 0
            add Ax, Dx
            mov dl, curarg
            mov dh, 0
            sub Ax, Dx
            pop Dx
            add Dx, Ax
            Loop L1
            mov ress, dx
    }
    long long a = ress;
    std::cout << a << std::endl;
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
        }
        else vars[index][symbol++] = p[i];
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
    if (info.is_open())
        info >> p;
    info.close();
    int b;
    int c;
    int i_max;
    parsefile(p, b, c, i_max);
    std::cout << b << c << i_max << std::endl;
    std::cout << "Начинается подсчёт..." << std::endl;
    clock_t ts = clock();
    short result = f(i_max, b, c);
    time = ((float)(clock() - ts)) / CLOCKS_PER_SEC;
    std::cout << "Результат работы программы на ассемблере:" << std::endl;
    std::cout << "  - Ответ: " << result << std::endl;
    std::cout << "  - Время: " << time << " секунд" << std::endl;
    std::ofstream res;
    res.open("OS_CppResult.txt", std::ios_base::trunc | std::ios_base::binary);
    res << result << "," << time;
    res.close();
    return 0;
}











/*
int main() {
	int a;
	char b = 4;
	char c = 5;
	short f = 1;

	__asm {
		mov Bl, 2 //начальное значение стартовой переменной
		mov Dx, 0 //начальное значение переменной, куда будут складываться резы
		mov ECX, 5 //сколько раз повторится цикл
		L1:
		mov al, b //получаем значение b
			mul bl //сейчас в Ax хранится al * bl
			Push dx //запоминаем dx
			mov dl, c //загружаем c в DL
			mov dh, 0
			add Ax, Dx //добавляем с к Ах
			pop Dx
			add Dx, Ax // Dx += Ax
			mov al, 2
			add Bl, Al
			Loop L1
			mov f, dx
	}
	cout << f;
}
*/