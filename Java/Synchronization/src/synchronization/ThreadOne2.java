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
public class ThreadOne2 extends Thread {
    private final Calc2 calc;
    public ThreadOne2(Calc2 c)
    {
        calc = c;
    }
    
    @Override
    public void run()
    {
        System.out.println("Поток " + Thread.currentThread().getName() + " начал арботать");
        synchronized(calc)
        {
            System.out.println("Поток " + Thread.currentThread().getName() + " получил доступ");
            int res = calc.summ(4, 5);
            System.out.println("Поток " + Thread.currentThread().getName() + " получил результат: " + res);
        }
    }
}
