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
public class Event {
    private boolean isWait = false;
    
    public Event(boolean isWait)
    {
        this.isWait = isWait;
    }
    
    public synchronized void setEvent()
    {
        isWait = false;
        notify();
    }
    
    public synchronized void resetEvent()
    {
        isWait = true;
    }
    
    public synchronized void waitEvent() throws InterruptedException
    {
        while (isWait)
        {
            wait();
        }
    }
}
