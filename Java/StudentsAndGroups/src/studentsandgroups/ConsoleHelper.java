/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package studentsandgroups;

import java.io.InputStreamReader;
import java.io.LineNumberReader;

/**
 *
 * @author PC
 */
public class ConsoleHelper {
    public static String readLine() {
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
            return Integer.parseInt(readLine());
        } catch (Exception ie) {
            return 0;
        }
    }

    public static double getDouble() {
        try {
            return Double.parseDouble(readLine());
        } catch (Exception ie) {
            return 0;
        }
    }
    
    public static void write(String str)
    {
        System.out.print(str);
    }
    
    public static void writeLine(String str)
    {
        System.out.println(str);
    }
}
