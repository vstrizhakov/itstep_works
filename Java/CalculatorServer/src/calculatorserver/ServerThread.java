/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package calculatorserver;

import java.net.*;

/**
 *
 * @author PC
 */
public class ServerThread extends Thread {
    @Override
    public void run()
    {
        try
        {
            ServerSocket listener = new ServerSocket(5000, 5, InetAddress.getByAddress(new byte[] { 127, 0, 0, 1 }));
            while (true)
            {
                Socket client = listener.accept();
                ClientThread clientThread = new ClientThread(client);
                clientThread.setDaemon(true);
                clientThread.start();
            }
        }
        catch (Exception ex) {
            System.out.println("Error: " + ex.getMessage());
        }
    }
}
