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
public class PoolItemThread extends Thread {
    private Runnable task;
    
    public synchronized void startTask(Runnable task)
    {
        this.task = task;
        notify();
    }
    
    private synchronized void checkTask() throws InterruptedException
    {
        while (task == null)
        {
            wait();
        }
    }
    
    public boolean isHandleTask()
    {
        return task != null;
    }
    
    @Override
    public void run()
    {
        try
        {
            while (true)
            {
                System.out.println("Поток из пула " + getName() + " ждет задачу");
                checkTask();
                
                System.out.println("ПОток из пула " + getName() + " получил задачу");
                
                try
                {
                    task.run();
                }
                catch (Throwable ex) {
                }
                task = null;
                System.out.println("Поток из пула " + getName() + " выполнил задчу");
            }
        }
        catch (InterruptedException ex) {
            
        }
    }
}
