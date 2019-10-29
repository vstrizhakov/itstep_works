/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package threads;

/**
 *
 * @author PC
 */
public class Messenger {
    private String message;
    
    public Messenger(String msg)
    {
        message = msg;
    }
    
    public synchronized void PrintFiveMesssages()
    {
        try
        {
            System.out.println(Thread.currentThread().getName() + " поток начал работу");
            for (int i = 0; i < 5; i++)
            {
                System.out.println(Thread.currentThread().getName() + " поток: " + message + " " + (i + 1));
            }
            System.out.println(Thread.currentThread().getName() + " поток закончил работу");
            Thread.sleep(10);
        }
        catch (InterruptedException ex) {
            
        }
    }
}
