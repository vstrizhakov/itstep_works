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
public class TestThread implements Runnable {
    @Override
    public void run()
    {
        try
        {
            for (int i = 0; i < 10; i++)
            {
                System.out.println("Работает поток: " + Thread.currentThread().getName());
                Thread.sleep(750);
            }
        }
        catch (InterruptedException ex) {
            System.out.println("Поток остановлен: " + Thread.currentThread().getName());
        }
    }
}
