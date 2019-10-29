/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package exceptions;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Iterator;
import java.util.TreeSet;

/**
 *
 * @author PC
 */
public class Exceptions {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        try
        {
            three();
        }
        catch (Exception ex)
        {
            System.out.println("Error: " + ex.getMessage());
            //ex.printStackTrace();
            
            StackTraceElement[] arr = ex.getStackTrace();
            for (StackTraceElement ste : arr)
            {
                System.out.println("Имя файла: " + ste.getFileName());
                System.out.println("Имя класса: " + ste.getClassName());
                System.out.println("Имя метода: " + ste.getMethodName());
                System.out.println("Номер строки: " + ste.getLineNumber());
            }
        }
        
        ArrayList A = new ArrayList();
        A.add(new Point(12, 13));
        A.add(new Point(55, 77));
        Iterator I = A.iterator();
        while (I.hasNext())
        {
            Object obj = I.next();
            System.out.println(obj);
        }
        
        Point[] arr = new Point[(A.size())];
        A.toArray(arr);
        for (Point p : arr)
        {
            System.out.println(p);
        }
        
        TreeSet<Point> H  = new TreeSet<>();
        Point p1 = new Point(1, 2);
        Point p2 = new Point(10, 20);
        Point p3 = new Point(19, 29);
        Point p4 = new Point(1, 2);
        Point p5 = new Point(17, 27);
        
        H.add(p1);
        H.add(p2);
        H.add(p3);
        H.add(p4);
        H.add(p5);
        H.add(p2);
        
        Iterator II = H.iterator();
        while (II.hasNext())
        {
            Object obj = II.next();
            System.out.println(obj);
        }
    }
    
    static void one()
    {
        //two();
    }
    
    static void two() throws Exception
    {
        three();
    }
    
    static void three() throws Exception
    {
        throw new Exception("Просто ошибка");
    }
}
