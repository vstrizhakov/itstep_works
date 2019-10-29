/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package synchronization;

/**
 *
 * @author PC
 */
public class Calc2 {
    public int summ(int a, int b)
    {
        try
        {
            for (int i = 0; i < 5; i++)
            {
                System.out.println("Вычисляю: " + Thread.currentThread().getName());
                Thread.sleep(1000);
            }
        }
        catch (InterruptedException ex) {
            
        }
        return a + b;
    }
}
