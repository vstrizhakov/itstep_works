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
public class FourthThread extends Thread {
    private Event event;
    private String msg;
    
    public FourthThread(Event e, String m)
    {
        event = e;
        msg = m;
    }
    
    @Override
    public void run()
    {
        try
        {
            while (true)
            {
                event.waitEvent();
                System.out.println(msg);
                Thread.sleep(500);
            }
        }
        catch (InterruptedException ex) {
            System.out.println("Поток прерван");
        }
    }
}
