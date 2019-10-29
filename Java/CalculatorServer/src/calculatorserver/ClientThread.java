/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package calculatorserver;

import java.io.*;
import java.net.*;

/**
 *
 * @author PC
 */
public class ClientThread extends Thread
{
    private Socket _client;
    
    public ClientThread(Socket client)
    {
        _client = client;
    }
    
    @Override
    public void run()
    {
        try
        {
            System.out.println("Соединение: " + _client.getInetAddress() + ":" + _client.getPort());
            byte[] buf = new byte[2048];
            ByteArrayOutputStream BAOS = new ByteArrayOutputStream();
            DataInputStream DIS = new DataInputStream(_client.getInputStream());
            DataOutputStream DOS = new DataOutputStream(_client.getOutputStream());
            while (true)
            {
                BAOS.reset();
                int packageLength = DIS.readInt();
                int currentLength = 0;
                do
                {
                    int count = DIS.read(buf, 0, buf.length);
                    if (count == -1)
                    {
                        throw new Exception("");
                    }
                    currentLength += count;
                    BAOS.write(buf, 0, count);
                } while (currentLength < packageLength);
                
                byte[] packageBytes = BAOS.toByteArray();
                String packageString = new String(packageBytes);
                System.out.println(packageString);
                
                String[] packageParts = packageString.split("\\|");
                if (packageParts.length != 2)
                {
                    throw new Exception("Wrong protocol");
                }
                
                String command = packageParts[0];
                
                String[] operands = packageParts[1].split("&");
                if (operands.length != 2)
                {
                    throw new Exception("Not enough operands");
                }
                
                double a = Double.valueOf(operands[0]);
                double b = Double.valueOf(operands[1]);
                double c = 0;
                String error = "";
                
                switch (command)
                {
                    case "PLUS":
                    {
                        c = a + b;
                        break;
                    }
                    case "MINUS":
                    {
                        c = a - b;
                        break;
                    }
                    case "MULTIPLE":
                    {
                        c = a * b;
                        break;
                    }
                    case "DIVIDE":
                    {
                        if (b != 0)
                        {
                            c = a / b;
                        }
                        else
                        {
                            error = "Can't divide by zero";
                        }
                        break;
                    }
                    default:
                        error = "Unknown command";
                        break;
                }

                String answer = "";
                if (error.contentEquals(""))
                {
                    System.out.println(c);
                    answer = Double.toString(c);
                }
                else
                {
                    answer = error;
                }
                
                byte[] answerBytes = answer.getBytes("UTF8");
                DOS.writeInt(answerBytes.length);
                DOS.write(answerBytes);
            }
        }
        catch (Exception ex) {
            try
            {
                _client.close();
            }
            catch (Exception x) {
                
            }
            System.out.println("Разрыв соединения: " + ex.getMessage());
        }
    }
}
