/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package threadsarraysynchronization;

import java.util.Random;

/**
 *
 * @author PC
 */
public class ArrayCounter extends Thread {
    private MyArray _array;
    private Event _event;
    
    public ArrayCounter(MyArray array, Event event)
    {
        _array = array;
        _event = event;
    }
    
    @Override
    public void run()
    {
        while (true)
        {
            try
            {
                _event.waitEvent();
                System.out.println("Counter started");
                int count = 0;
                for (int i = 0; i < MyArray.COUNT; i++)
                {
                    if (_array.getInt(i) % 2 == 0)
                    {
                        count++;
                    }
                    Thread.sleep(10);
                }
                System.out.println("Количество четных элементов: " + count);
                System.out.println("Counter started");
                _event.setEvent();
                Thread.sleep(10);
            }
            catch (InterruptedException ex) {
                
            }
        }
    }
}