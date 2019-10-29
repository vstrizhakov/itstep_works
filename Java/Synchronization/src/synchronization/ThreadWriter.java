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
public class ThreadWriter extends Thread {
    private MyArray array;
    private int value;
    private int count;
    
    public ThreadWriter(MyArray arr, int value, int count)
    {
        array = arr;
        this.value = value;
        this.count = count;
    }
    
    @Override
    public void run()
    {
        try
        {
            array.writeToArray(value, count);
        }
        catch (InterruptedException ex) {
            System.out.println("Поток превран: " + Thread.currentThread().getName());
        }
    }
}
