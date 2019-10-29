/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package threads;

/**
 *
 * @author PC
 */
public class MessengerThread extends Thread {
    private Messenger _messenger;
    
    public MessengerThread(Messenger messenger)
    {
        _messenger = messenger;
    }
    
    @Override
    public void run()
    {
        try
        {
            while (true)
            {
                _messenger.PrintFiveMesssages();
            }
        }
        catch (Exception ex) {
            
        }
    }
}
