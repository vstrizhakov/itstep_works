/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package serverex;

import java.io.ByteArrayOutputStream;
import java.io.DataInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.net.Socket;

/**
 *
 * @author PC
 */
public class ReadWriterThread extends Thread {
    private Socket client;
    private byte[] buf = new byte[1024];
    private ByteArrayOutputStream BAOS = new ByteArrayOutputStream();
    
    public ReadWriterThread(Socket client)
    {
        this.client = client;
    }
    
    @Override
    public void run()
    {
        try
        {
            System.out.println("Соединение: " + client.getInetAddress() + ":" + client.getPort());
            DataInputStream DIS = new DataInputStream(client.getInputStream());
            while (true)
            {
                BAOS.reset();
                
                int allLen = DIS.readInt();
                int curLen = 0;

                int filenameLength = DIS.readInt();
                byte[] filenameBytes = new byte[filenameLength];
                DIS.read(filenameBytes, 0, filenameLength);
                
                String filename = new String(filenameBytes);
                System.out.println("Попытка загрузить " + filename);
                
                do
                {
                    int count = client.getInputStream().read(buf, 0, buf.length);
                    if (count == -1)
                        throw new Exception("-1 bytes received");
                    curLen += count;
                    BAOS.write(buf, 0, count);
                } while (curLen < allLen);
                byte[] a = BAOS.toByteArray();
                try
                {
                    FileOutputStream FOS = new FileOutputStream(filename);
                    FOS.write(a, 0, a.length);
                    FOS.close();
                }
                catch (IOException ex) {
                    
                }
                
                
//                String str = new String(a, 0, a.length);
//                System.out.println("Получено от клиента: " + str);
//                
//                str = str.toUpperCase();
//                a = str.getBytes("UTF8");
//                client.getOutputStream().write(a, 0, a.length);
            }
        }
        catch (Exception ex) {
            try
            {
                client.close();
            }
            catch (Exception e) {
                
            }
            System.out.println("Разрыв соединения: " + ex.getMessage());
        }
    }
}
