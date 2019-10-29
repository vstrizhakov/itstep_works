/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package threadsarraysynchronization;

/**
 *
 * @author PC
 */
public class Event {
    private int _capacity;
    private int _current = 0;
    
    public Event(int capacity, int current)
    {
        _capacity = capacity;
    }
    
    public synchronized void setEvent()
    {
        _current--;
        notify();
    }
    
    public synchronized void resetEvent()
    {
        _current = 0;
    }
    
    public synchronized void waitEvent() throws InterruptedException
    {
        while (_current == _capacity)
        {
            wait();
        }
        _current++;
    }
}