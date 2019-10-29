/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package threads;

import java.io.InputStreamReader;
import java.io.LineNumberReader;

/**
 *
 * @author PC
 */
public class Threads {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
//        FirstThread ft = new FirstThread();
//        ft.start();
//        
//        try
//        {
//            Thread.sleep(3000);
//        }
//        catch (InterruptedException ie) {}
//        
//        ft.interrupt();
//        
//        try
//        {
//            Thread.sleep(3000);
//        }
//        catch (InterruptedException ie) {}
//        
//        ft.interrupt();
//
//        System.out.println("Good Bye");

//        TestThread tt = new TestThread();
//        Thread T = new Thread(tt);
//        T.start();

//        FirstThread ft = new FirstThread();
//        ft.setDaemon(true);
//        ft.start();
//        System.out.println("Ожидание завершения работы вторичного потока");
//        try
//        {
//            //Thread.sleep(2000);
//            ft.join(3000);
//        }
//        catch (InterruptedException ex) {
//            System.out.println("Ожидание завершилось, первичный поток работает дальше");
//        }
//        if (ft.isAlive())
//        {
//            System.out.println("Вторичный поток НЕ завершил свою работу");
//        }
//        else
//        {
//            System.out.println("Вторичный поток завершил свою работу");
//        }

//        PauseableThread pt = new PauseableThread();
//        pt.start();
//        
//        while (true)
//        {
//            int a = getInt();
//            if (a == 0) break;
//            if (a == 2)
//            {
//                System.out.println("Прерываем работу потока");
//                pt.interrupt();
//                break;
//            }
//            pt.pauseOn();
//            System.out.println("Приостанавливаем работу потока");
//            
//            a = getInt();
//            if (a == 0) break;
//            
//            pt.pauseOff();
//            System.out.println("Возобновляем работу потока");
//        }
//        pt.interrupt();
//        
//        try
//        {
//            Thread.sleep(2000);
//        }
//        catch (InterruptedException ie) {}

        Messenger messenger = new Messenger("Hello, World!");
        MessengerThread[] threads = new MessengerThread[10];
        for (int i = 0; i < 10; i++)
        {
            threads[i] = new MessengerThread(messenger);
            threads[i].start();
        }
        getString();
        for (int i = 0; i < 10; i++)
        {
            threads[i].interrupt();
        }
        System.out.println("Good Bye");
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
