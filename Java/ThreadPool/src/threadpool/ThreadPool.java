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
public class ThreadPool {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        for (int i = 0; i < 11; i++)
        {
            TestWork tw = new TestWork("Hello, " + i + "th World!");
            try
            {
                while (!Pool.getThreadPool().execTask(tw)) Thread.sleep(100);
            }
            catch (InterruptedException ex) {
                
            }
        }
    }
    
}
