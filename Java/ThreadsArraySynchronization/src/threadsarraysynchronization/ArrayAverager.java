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
public class ArrayAverager extends Thread {
    private MyArray _array;
    private Event _event;
    
    public ArrayAverager(MyArray array, Event event)
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
                System.out.println("Averager started");
                int sum = 0;
                for (int i = 0; i < MyArray.COUNT; i++)
                {
                    sum += _array.getInt(i);
                    Thread.sleep(10);
                }
                System.out.println("Сумма чисел массива равна: " + sum);
                System.out.println("Averager Ended");
                _event.setEvent();
                Thread.sleep(10);
            }
            catch (InterruptedException ex) {
                
            }
        }
    }
}