package com.dmittrj;

import javax.xml.parsers.ParserConfigurationException;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.Scanner;

public class OS_File {

    File file;
    //Data info = new Data();

    OS_File(String filename){
        file = new File(Main.PATH + filename);
    }

    String open() {
        String textFromFile = "";
        System.out.println(">>>" + file.getAbsolutePath());
        try (FileInputStream fin = new FileInputStream(file)) {
            //System.out.print("Содержимое: ");
            int i = -1;
            while ((i = fin.read()) != -1) { // * В цикле читаем содержимое файла посимвольно
                textFromFile += (char) i;
                //System.out.print((char) i); // * Выводим в консоль
            }
            //System.out.println("\n" + textFromFile);
            fin.close();
            return textFromFile;
        } catch (IOException ex) {
            System.out.println(ex.getMessage());
        }
        return "";
    }

    void create(String res, String time) throws IOException {
        file.createNewFile();
        try (FileOutputStream fos = new FileOutputStream(file)) { // * Открываем поток записи для нашего файла
            // * Конструкция типа try-with-resources, в круглых скобках объявляем
            // * переменные, которые далее можем использовать в теле обработки
            // * Конкретно здесь создается экземпляр класса для записи байтов в файл
            byte[] buffer = (res + "," + time).getBytes(); // * Переводим некие данные нашего объекта в последовательность байтов
            // * Происходит запись всей длины массива
            // * байтов в файл со смещением равным нулю
            fos.write(buffer, 0, buffer.length);
            fos.close(); // * Закрываем поток
        } catch (IOException ex) {
            System.out.println(ex.getMessage()); // * [1]
        }
    }

}
