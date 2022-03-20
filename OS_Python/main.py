import time

NUMBEROFOPERATIONS = 100000000


def f(arg, b, c):
    if arg == 0:
        return 0
    a = 0
    for i in range(1, NUMBEROFOPERATIONS):
        a += 2 * b + c - arg
    return f(arg - 1, b, c) + a


def parse(filestring):
    str_nums = ["", "", ""]
    x = 0
    for st in filestring:
        if st == ",":
            x += 1
        else:
            str_nums[x] += st
    return int(str_nums[0]), int(str_nums[1]), int(str_nums[2])


if __name__ == '__main__':
    file = open("OS_Info.txt")
    string_from_file = file.read()
    file.close()
    fb, fc, fi_max = parse(string_from_file)
    print("Начинается подсчёт...")
    start_time = time.monotonic()
    result = f(fi_max, fb, fc)
    end_time = time.monotonic()
    all_time = end_time - start_time
    print("Результат работы программы на Python:")
    print("  - Ответ: " + str(result))
    print("  - Время: " + str(round(all_time, 2)) + " секунд")
    res_file = open("OS_PythonResult.txt", 'w')
    res_file.write(str(result) + "," + str(round(all_time, 2)))
    res_file.close()
    input()
