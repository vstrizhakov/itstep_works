/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package udpsender;

import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;

/**
 *
 * @author PC
 */
public class UdpSender {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        try
        {
            String message = "Здесь есть натуральные блондины?";
            byte[] a = message.getBytes("UTF8");
            DatagramPacket packet = new DatagramPacket(a, a.length, InetAddress.getByAddress(new byte[] { 10, 3, (byte)255, (byte)255}), 7000);
            DatagramSocket sender = new DatagramSocket();
            while (true)
            {
                sender.send(packet);
                System.out.println("Sended");
                Thread.sleep(100);
            }
            //sender.close();
        }
        catch (Exception ex) {
            System.out.println("Error (" + ex.getClass().getName() + "): " + ex.getMessage());
        }
    }
    
}
