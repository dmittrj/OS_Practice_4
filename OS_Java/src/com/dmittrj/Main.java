package com.dmittrj;


import javax.swing.filechooser.FileSystemView;
import javax.xml.parsers.ParserConfigurationException;
import java.io.File;
import java.io.IOException;

import static java.lang.Integer.parseInt;

public class Main {

    public static final String PATH = "./resources/";
    private static final int NUMBEROFOPERATIONS = 100000000;
    static String info;


    static void ReadFile() throws ParserConfigurationException, IOException {
        OS_File nFile = new OS_File("OS_Info.txt");
        info = nFile.open();
        //nFile.write();
        //nFile.read();
        //nFile.delete();
    }

    private static Argums ParseFile(String info) {
        String[] values = info.split(",");
        //System.out.println("Parsed:" + values[0] + "<<");
        int b = parseInt(values[0]);
        //System.out.println("Got:" + b + "<<");
        //System.out.println("Parsed:" + values[1] + "<<");
        int c = parseInt(values[1]);
        //System.out.println("Got:" + c + "<<");
        //System.out.println("Parsed:" + values[2].split("\r")[0] + "<<");
        int i_max = parseInt(values[2].split("\r")[0]);
        //System.out.println("Got:" + i_max + "<<");
        return new Argums(b, c, i_max);
    }

    public static long f(long arg, int b, int c) {
        if (arg == 0) return 0;
        long a = 0;
        for (int i = 1; i < NUMBEROFOPERATIONS; i++) {
            a += 2 * b + c - arg;
        }
        return f(arg - 1, b, c) + a;
    }

    public static void main(String[] args) throws ParserConfigurationException, IOException {
        //System.out.println(f(10, 5, 7));
        ReadFile();
        Argums v = ParseFile(info);
        long result = f(v.i_max, v.b, v.c);
        System.out.println(result);
    }

}
