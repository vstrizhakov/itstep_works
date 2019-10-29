/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package synchronization;

import java.io.InputStreamReader;
import java.io.LineNumberReader;

/**
 *
 * @author PC
 */
public class Synchronization {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
//        Calc c = new Calc();
//        ThreadOne t1 = new ThreadOne(c);
//        ThreadOne t2 = new ThreadOne(c);
//        ThreadTwo t3 = new ThreadTwo(c);
//        
//        t1.start();
//        t2.start();
//        t3.start();

//        MyArray arr = new MyArray();
//        ThreadWriter tw1 = new ThreadWriter(arr, 1, 500);
//        ThreadWriter tw2 = new ThreadWriter(arr, 2, 500);
//        
//        tw1.start();
//        tw2.start();

//        try
//        {
//            tw1.join();
//            tw2.join();
//        }
//        catch (InterruptedException ex) {
//            
//        }
//        arr.showArray();

//        Calc2 c = new Calc2();
//        ThreadOne2 t12 = new ThreadOne2(c);
//        ThreadOne2 t22 = new ThreadOne2(c);
//        
//        t12.start();
//        t22.start();

//        MyArray2 arr = new MyArray2();
//        ThreadWriter2 tw1 = new ThreadWriter2(arr, 1, 500);
//        ThreadWriter2 tw2 = new ThreadWriter2(arr, 2, 500);
//        
//        tw1.start();
//        tw2.start();

        Event event = new Event(false);
        FourthThread t = new FourthThread(event, "Hello, World!");
        t.setDaemon(true);
        t.start();
        
        while (true)
        {
            String str = getString();
            if (str.contentEquals("exit")) break;
            
            event.resetEvent();
            
            str = getString();
            if (str.contentEquals("exit")) break;
            
            event.setEvent();
        }
        System.out.println("Good Bye");
    }
    
    public static String getString()
    {        
        String S = "";
        try
        {
            LineNumberReader    LNR = new LineNumberReader(new InputStreamReader(System.in, "CP1251"));
            S = LNR.readLine();
        }
        catch (Exception ioe) 
        {
            S = "";
        }
        return  S;
    }
}
