/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dz_java_5_1;

import java.io.InputStreamReader;
import java.io.LineNumberReader;

/**
 *
 * @author 09220
 */
public class DZ_Java_5_1 {
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args)
    {
        try
        {
            Money M1 = new Money(1000, 0);
            Money M2;
        
            System.out.println("Ваша сумма: "+M1);
            B:
            while(true)
            {
                System.out.println("1. Сложить.");
                System.out.println("2. Вычесть.");
                System.out.println("0. Выйти.");
                int n = getInt();
                switch(n)
                {
                    case 1:
                    System.out.println("Введите грн. и коп.");
                    M2 = new Money(getInt(), getInt());
                    M1=Money.sumMoney(M1, M2);
                    System.out.println(M1);
                        break;
                    case 2:
                    System.out.println("Введите грн. и коп.");
                    M2 = new Money(getInt(), getInt());
                    M1=Money.subMoney(M1, M2);
                    System.out.println(M1);
                        break;
                    default:
                        break B;
                }
            }
        }
        catch(Exception e)
        {
            e.printStackTrace();
        }
        
        
    }
    public static String getString()
{        
        String  S   = "";
        try
        {
            LineNumberReader    LNR = new LineNumberReader(new InputStreamReader(System.in, "CP1251"));
            S   = LNR.readLine();
        }
        catch (Exception ioe) 
        {
            S   = "";
        }
        return  S;
}
public static int getInt()
{
        try
        {
            return Integer.parseInt(getString());
        }
        catch (Exception ie) 
        {
            return 0;
        }
}
}
