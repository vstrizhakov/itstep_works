/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package serverex;

import java.net.InetAddress;
import java.net.ServerSocket;
import java.net.Socket;

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
            ServerSocket server = new ServerSocket(4000, 5, InetAddress.getByAddress(new byte[] { 127, 0, 0, 1 }));
            while (true)
            {
                Socket client = server.accept();
                ReadWriterThread rwt = new ReadWriterThread(client);
                rwt.setDaemon(true);
                rwt.start();
            }
        }
        catch (Exception ex) {
            System.out.println("Error: " + ex.getMessage());
        }
    }
}
