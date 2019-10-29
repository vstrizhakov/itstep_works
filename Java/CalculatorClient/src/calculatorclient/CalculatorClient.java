/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package calculatorclient;

import java.io.*;
import java.net.*;

/**
 *
 * @author PC
 */
public class CalculatorClient {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        try
        {
            Socket client = new Socket();
            client.connect(new InetSocketAddress(InetAddress.getByAddress(new byte[] { 127, 0, 0, 1 }), 5000));
            System.out.println("Соединение с сервером успешно установлено");
            
            byte[] buf = new byte[2048];
            ByteArrayOutputStream BAOS = new ByteArrayOutputStream();
            DataInputStream DIS = new DataInputStream(client.getInputStream());
            DataOutputStream DOS = new DataOutputStream(client.getOutputStream());
            try
            {
                while (true)
                {
                    System.out.print("Выберите операцию (PLUS - 1, MINUS - 2, MULTIPLE - 3, DIVIDE - 4, Выйти - 0):");
                    String operation = getString().toUpperCase();
                    if (operation.contentEquals("0")) break;
                    switch (operation)
                    {
                        case "1":
                            operation = "PLU1S";
                            break;
                        case "2":
                            operation = "MINUS";
                            break;
                        case "3":
                            operation = "MULTIPLE";
                            break;
                        case "4":
                            operation = "DIVIDE";
                            break;
                    }
                    System.out.print("Введите первое число: ");
                    double firstNumber = getDouble();
                    System.out.print("Введите второе число: ");
                    double secondNumber = getDouble();
                    
                    String request = operation + "|" + firstNumber + "&" + secondNumber;
                    byte[] requestBytes = request.getBytes("UTF8");
                    
                    DOS.writeInt(requestBytes.length);
                    DOS.write(requestBytes);
                    
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
                    System.out.println("Результат: " + packageString);
                }
            }
            catch (Exception ex) {
                System.out.println("Ошибка: " + ex.getMessage());
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
    
    public static double getDouble()
    {
        try
        {
            return Double.parseDouble(getString());
        }
        catch (Exception ie) 
        {
            return 0;
        }
    }
}
