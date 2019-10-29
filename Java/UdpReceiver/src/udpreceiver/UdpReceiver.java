/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package udpreceiver;

import java.net.DatagramPacket;
import java.net.DatagramSocket;

/**
 *
 * @author PC
 */
public class UdpReceiver {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        try
        {
            byte[] buf = new byte[1024];
            DatagramPacket packet = new DatagramPacket(buf, buf.length);
            DatagramSocket receiver = new DatagramSocket(7000);
            while (true)
            {
                receiver.receive(packet);
                System.out.println("ПОлучено от: " + packet.getAddress() + ": " + packet.getPort());
                String msg = new String(packet.getData(), 0, packet.getLength(), "UTF8");
                System.out.println(msg);
                System.out.println("====");
            }
        }
        catch (Exception ex)
        {
            System.out.println("Error (" + ex.getClass().getName() + "): " + ex.getMessage());
        }
    }
    
}
