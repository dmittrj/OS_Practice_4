package com.dmittrj;


import javax.swing.filechooser.FileSystemView;
import javax.xml.parsers.ParserConfigurationException;
import java.io.File;
import java.io.IOException;

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

    private static void ParseFile(String info) {

    }


    static void getInfoAboutRoots() { // * Функция вывода информации о логических дисках
        String result = "";
        System.out.println("1. Информация о логических дисках устройства:");
        var i = 0;
        for (File f : File.listRoots()) {
            i++;
            result += i + ": ";
            result += FileSystemView.getFileSystemView().getSystemDisplayName(f); // * Название диска
            result += " | ";
            result += FileSystemView.getFileSystemView().getSystemTypeDescription(f); // * Тип диска
            result += " | ";
            result += String.format("%.2f", (f.getTotalSpace() / (Math.pow(1024, 3)))) + " GB"; // * Объем диска
            result += "\n";
        }

        System.out.println(result);
    }

    public static long f(long arg, int b, int c) {
        if (arg == 0) return 0;
        int a = 0;
        for (int i = 1; i < NUMBEROFOPERATIONS; i++) {
            a += 2 * b + c - i;
        }
        return f(arg - 1, b, c) + a;
    }

    public static void main(String[] args) throws ParserConfigurationException, IOException {
        //System.out.println(f(10, 5, 7));
        ReadFile();
        ParseFile(info);
        System.in.read();
    }

}
