/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package interfaces;

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
    
    public static double readDouble()
    {
        String S = readLine();
        try
        {
            return Double.parseDouble(S);
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
}
