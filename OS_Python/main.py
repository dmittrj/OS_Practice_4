NUMBEROFOPERATIONS = 100000000 - 1


def print_hi(name):
    # Use a breakpoint in the code line below to debug your script.
    print(f'Hi, {name}')  # Press Ctrl+F8 to toggle the breakpoint.


def f(arg, b, c):
    if arg == 0:
        return 0;
    a = 0;
    for i in range(0, NUMBEROFOPERATIONS):
        a += 2 * b + c - arg
    return f(arg - 1, b, c) + a


if __name__ == '__main__':
    result = f(8, 1, 2)
    print(result)
