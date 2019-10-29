/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package strings;

import java.io.InputStreamReader;
import java.io.LineNumberReader;
import java.util.Calendar;

/**
 *
 * @author PC
 */
public class Strings {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
//        String s1 = "Hello";
//        String s2 = getString();
//        if (s1.contentEquals(s2)) {
//            System.out.println("Строки равны");
//        } else {
//            System.out.println("Строки НЕ равны");
//        }
//
//        byte[] a = new byte[]
//        {
//            (byte) 0xD0, (byte) 0x90,
//            (byte) 0xD0, (byte) 0x91,
//            (byte) 0xD0, (byte) 0xA4,
//        };
//        
//        try
//        {
//            String str = new String(a, 0, a.length, "UTF8");
//            System.out.println(str);
//        }
//        catch (Exception ex)
//        {
//            System.out.println("Ошибка: " + ex.getMessage());
//        }
//        
//        String string = "soigjseoirgjwoei r 223-235-55-33 sd[foigjwepoirj wier 346-980-12-73 dgheryjrtherth";
//        String numbersS = string.replaceAll("\\d{3}-\\d{3}-\\d{2}-\\d{2}", "[WARNING]");
//        System.out.println(numbersS);

//        String tmp = "";
//        long begTime = System.currentTimeMillis();
//        
//        for (int i = 0; i < 100000; i++)
//        {
//            tmp += "Hello";
//        }
//        long endTime = System.currentTimeMillis();
//        System.out.println("Затрачено времени: " + (endTime - begTime));

//        StringBuilder tmp = new StringBuilder();
//        long begTime = System.currentTimeMillis();
//        
//        for (int i = 0; i < 100000; i++)
//        {
//            tmp.append("Hello");
//        }
//        String strtmp = tmp.toString();
//        long endTime = System.currentTimeMillis();
//        System.out.println("Затрачено времени: " + (endTime - begTime));

    Money money = new Money(12, 45);
    System.out.println(money);
    money.setGrn(23);
    System.out.println(money);
    }

    public static String getString() {
        String S = "";
        try {
            LineNumberReader LNR = new LineNumberReader(new InputStreamReader(System.in, "CP1251"));
            S = LNR.readLine();
        } catch (Exception ioe) {
            S = "";
        }
        return S;
    }

    public static int getInt() {
        try {
            return Integer.parseInt(getString());
        } catch (Exception ie) {
            return 0;
        }
    }
}
