/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package clientex;

import java.io.ByteArrayOutputStream;
import java.io.DataOutputStream;
import java.io.FileInputStream;
import java.io.InputStreamReader;
import java.io.LineNumberReader;
import java.net.InetAddress;
import java.net.InetSocketAddress;
import java.net.Socket;

/**
 *
 * @author PC
 */
public class ClientEx {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        try
        {
            Socket client = new Socket();
            client.connect(new InetSocketAddress(InetAddress.getByAddress(new byte[] { 127, 0, 0, 1 }), 4000));
            System.out.println("Соединение с сервером успешно установлено");
            
            byte[] buf = new byte[1024];
            ByteArrayOutputStream BAOS = new ByteArrayOutputStream();
            DataOutputStream DOS = new DataOutputStream(client.getOutputStream());
            try
            {
                while (true)
                {
                    BAOS.reset();
//                    System.out.println("Введите строку для отправки на сервер (пустая строка - выход): ");
//                    String msg = getString();
//                    if (msg.isEmpty()) break;
//                    
//                    byte[] a = msg.getBytes("UTF8");
//                    client.getOutputStream().write(a, 0, a.length);
//                    
//                    do
//                    {
//                        int count = client.getInputStream().read(buf, 0, buf.length);
//                        if (count == -1)
//                            throw new Exception("-1 bytes received");
//                        BAOS.write(buf, 0, count);
//                    } while (client.getInputStream().available() > 0);
//                    a = BAOS.toByteArray();
//                    String answer = new String(a, 0, a.length);
//                    System.out.println("Получено от сервера: " + answer);

                    System.out.print("Введите название файла: ");
                    String filename = getString();

                    FileInputStream FIS = new FileInputStream(filename);
                    while (FIS.available() > 0)
                    {
                        int cnt = FIS.read(buf, 0, buf.length);
                        if (cnt == -1) break;
                        BAOS.write(buf, 0, cnt);
                    }
                    FIS.close();
                    
                    byte[] a = BAOS.toByteArray();
                    BAOS.reset();
                    
                    DOS.writeInt(a.length);
                    DOS.flush();

                    byte[] filenameBytes = filename.getBytes("UTF8");
                    DOS.writeInt(filenameBytes.length);
                    DOS.write(filenameBytes);
                    
                    DOS.write(a);
                    break;
                }
                client.close();
            }
            catch (Exception ex) {
                System.out.println("Разрыв соединения с сервером: " + ex.getMessage());
            }
        }
        catch (Exception ex) {
            System.out.println("Ошибка установления соединения с сервером: " + ex.getMessage());
        }
    }
    
    public static String getString()
    {        
        String S = "";
        try
        {
            LineNumberReader    LNR = new LineNumberReader(new InputStreamReader(System.in, "CP1251"));
            S = LNR.readLine();
        }
        catch (Exception ioe) 
        {
            S = "";
        }
        return  S;
    }
}
