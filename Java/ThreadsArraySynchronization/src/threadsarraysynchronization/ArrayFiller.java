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
public class ArrayFiller extends Thread {
    private MyArray _array;
    private Event _event;
    
    public ArrayFiller(MyArray array, Event event)
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
                _event.waitEvent();
                System.out.println("Filler started");
                for (int i = 0; i < MyArray.COUNT; i++)
                {
                    Random rand = new Random();
                    _array.insertInt(i, rand.nextInt() % 100);
                    //System.out.print(_array.getInt(i) + " ");
                    Thread.sleep(10);
                }
                System.out.println("Filler ended");
                _event.setEvent();
                _event.setEvent();
                Thread.sleep(10);
            }
            catch (InterruptedException ex) {
                
            }
        }
    }
}
