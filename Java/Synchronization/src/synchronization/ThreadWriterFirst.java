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
public class ThreadWriterFirst extends Thread {
    private MyArrayThree A;
    private Event E;
    private int value;
    private int count;
    
    public ThreadWriterFirst(MyArrayThree A, Event E, int value, int count)
    {
        this.A = A;
        this.E = E;
        this.value = value;
        this.count = count;
    }
    
    @Override
    public void run()
    {
        try
        {
            System.out.println("Первый поток начал работу");
            for (int i = 0;i < count; i++)
            {
                A.putValue(value);
                Thread.sleep(10);
            }
            System.out.println("Певрый поток завершил работу");
            E.setEvent();
        }
        catch (InterruptedException ex) {
            
        }
    }
}
