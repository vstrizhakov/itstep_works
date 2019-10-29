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
public class ThreadOne extends Thread {
    private Calc calc;
    
    public ThreadOne(Calc c)
    {
        this.calc = c;
    }
    
    @Override
    public void run()
    {
        System.out.println("Поток " +  Thread.currentThread().getName() + " начал работу");
        int res = calc.summ(4, 5);
        System.out.println("Поток " +  Thread.currentThread().getName() + " закончил работу: " + res);
    }
}
