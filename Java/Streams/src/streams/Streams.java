/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package streams;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;

/**
 *
 * @author PC
 */
public class Streams {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
//        byte[] A = new byte[]{
//            10, 20, 30, 40, 50, 60, 70, 80, 90, 10, 20, 30, 40, 50, 60, 70, 80, 90,};
//
//        try {
//            ByteArrayInputStream BAIS = new ByteArrayInputStream(A);
//            byte[] buf = new byte[4];
//            while (true) {
//                int cnt = BAIS.read(buf, 0, buf.length);
//                System.out.println("Прочитано: " + cnt);
//                if (cnt == -1) {
//                    break;
//                }
//
//                for (int i = 0; i < cnt; i++) {
//                    System.out.println("buf[" + i + "] = " + buf[i]);
//                }
//            }
//            BAIS.close();
//        } catch (Exception ex) {
//
//        }
//        System.out.println("Good Bye");

//        try {
//            ByteArrayOutputStream BAOS = new ByteArrayOutputStream();
//            byte[] B = new byte[]{10, 20, 30, 40, 50, 60};
//            BAOS.write(B, 0, B.length);
//
//            BAOS.write(new byte[]{7, 8, 9, 10, 11});
//            BAOS.write(99);
//
//            byte[] a = BAOS.toByteArray();
//            for (int i = 0; i < a.length; i++) {
//                System.out.println("a[" + i + "] = " + a[i]);
//            }
//        } catch (Exception ex) {
//
//        }

//        ByteArrayOutputStream BAOS = new ByteArrayOutputStream();
//        DataOutputStream DOS = new DataOutputStream(BAOS);
//        try {
//            int a = 123456;
//            DOS.writeInt(a);
//            
//            double w = 5.6789;
//            DOS.writeDouble(w);
//            
//            String c = "Hello, World!";
//            DOS.writeUTF(c);
//            
//            boolean d = true;
//            DOS.writeBoolean(d);
//
//            byte[] b = BAOS.toByteArray();
//            for (int i = 0; i < b.length; i++) {
//                System.out.println("b[" + i + "] = " + b[i]);
//            }
//            DOS.close();
//            
//            ByteArrayInputStream BAIS = new ByteArrayInputStream(b);
//            DataInputStream DIS = new DataInputStream(BAIS);
//            
//            int a1 = DIS.readInt();
//            double d1 = DIS.readDouble();
//            String s1 = DIS.readUTF();
//            boolean b1 = DIS.readBoolean();
//            
//            DIS.close();
//            
//            System.out.println("a1 = " + a1);
//            System.out.println("d1 = " + d1);
//            System.out.println("s1 = " + s1);
//            System.out.println("b1 = " + b1);
//        } catch (IOException ex) {
//
//        } catch (Exception ex) {
//            try {
//                DOS.close();
//            } catch (Exception e) {
//
//            }
//        }

//        try {
//            FileOutputStream FOS = new FileOutputStream("test.txt");
//            byte[] buf = new byte[]{10, 20, 30, 40, 50};
//            FOS.write(buf, 0, buf.length);
//            FOS.close();
//
//            FileInputStream FIS = new FileInputStream("test.txt");
//            byte[] b = new byte[4];
//
//            while (true) {
//                int cnt = FIS.read(b, 0, b.length);
//                System.out.println("Прочитано байт: " + cnt);
//                if (cnt == -1) {
//                    break;
//                }
//                for (int i = 0; i < cnt; i++) {
//                    System.out.println("b[" + i + "] = " + b[i]);
//                }
//            }
//            FIS.close();
//        } catch (FileNotFoundException fnfe) {
//            System.out.println("Файл не найден: " + fnfe.getMessage());
//        } catch (IOException ex) {
//            System.out.println("Ошибка ввода/вывода: " + ex.getMessage());
//        }

//        DataOutputStream DOS = null;
//        try {
//            FileOutputStream FOS = new FileOutputStream("test2.txt");
//            DOS = new DataOutputStream(FOS);
//            int a = 123456;
//            DOS.writeInt(a);
//            
//            double w = 5.6789;
//            DOS.writeDouble(w);
//            
//            String c = "Hello, World!";
//            DOS.writeUTF(c);
//            
//            boolean d = true;
//            DOS.writeBoolean(d);
//
//            DOS.close();
//            
//            FileInputStream FIS = new FileInputStream("test2.txt");
//            DataInputStream DIS = new DataInputStream(FIS);
//            
//            int a1 = DIS.readInt();
//            double d1 = DIS.readDouble();
//            String s1 = DIS.readUTF();
//            boolean b1 = DIS.readBoolean();
//            
//            DIS.close();
//            
//            System.out.println("a1 = " + a1);
//            System.out.println("d1 = " + d1);
//            System.out.println("s1 = " + s1);
//            System.out.println("b1 = " + b1);
//        } catch (IOException ex) {
//
//        } catch (Exception ex) {
//            try {
//                if (DOS != null) DOS.close();
//            } catch (Exception e) {
//
//            }
//        }

        try
        {
            FileInputStream FIS = new FileInputStream("hello.java");
            ByteArrayOutputStream BAOS = new ByteArrayOutputStream();
            byte[] buf = new byte[512];
            
            while (true)
            {
                int cnt = FIS.read(buf, 0, buf.length);
                System.out.println("Прочитано байт: " + cnt);
                if (cnt == -1) break;
                BAOS.write(buf, 0, cnt);
            }
            FIS.close();
            
            byte[] a = BAOS.toByteArray();
            BAOS.close();
            
            String content = new String(a, 0, a.length, "UTF8");
            System.out.println(content);
        }
        catch (Exception ex) {
            
        }
    }
}
