/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package threadpool;

/**
 *
 * @author PC
 */
public class TestWork implements Runnable {
    private String msg;
    
    public TestWork(String msg)
    {
        this.msg = msg;
    }
    
    @Override
    public void run()
    {
        try
        {
            for (int i = 0; i < 5; i++)
            {
                System.out.println(msg + ", " + Thread.currentThread().getName());
                Thread.sleep(750);
            }
        }
        catch (InterruptedException ex) {
            
        }
    }
}
