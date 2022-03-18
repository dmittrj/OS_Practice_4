package com.dmittrj;



public class Main {
    static int NUMBEROFOPERATIONS = 100000000;
    public static long f(long arg, int b, int c) {
        if (arg == 0) return 0;
        int a = 0;
        for (int i = 1; i < NUMBEROFOPERATIONS; i++) {
            a += 2 * b + c - i;
        }
        return f(arg - 1, b, c) + a;
    }

    public static void main(String[] args) {
        System.out.println(f(10, 5, 7));
    }
}
