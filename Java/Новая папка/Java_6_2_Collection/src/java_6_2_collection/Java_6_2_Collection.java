/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package java_6_2_collection;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Iterator;
import java.util.TreeSet;

/**
 *
 * @author 09220
 */
public class Java_6_2_Collection {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        ArrayList A = new ArrayList();   //не типизированный
        A.add(new MyPoint (12, 13));
        A.add(new Object());
        A.add(new MyPoint (49, 47));

        Iterator I = A.iterator();
        while (I.hasNext()) {
            Object obj = I.next();
            System.out.println(obj);
        }
        System.out.println();
        ArrayList<MyPoint> A2 = new ArrayList<>();   //типизированный
        A2.add(new MyPoint (12, 19));
        A2.add(new MyPoint (49, 47));
        A2.add(new MyPoint (87, 21));
        A2.add(new MyPoint (69, 52));

        Iterator<MyPoint> I2 = A2.iterator();
        
        while (I2.hasNext()) {
            MyPoint obj = I2.next();
            System.out.println(obj);
        }
        MyPoint[] arr = new MyPoint[A2.size()];
        A2.toArray(arr);
        for(MyPoint p:arr)
            System.out.println(p);
        
        //////HashSet, TreeSet
        System.out.println("---------------------------------");
        HashSet<MyPoint> H = new HashSet<>();
        MyPoint P1 = new MyPoint(1, 7);
        MyPoint P2 = new MyPoint(8, 5);
        MyPoint P3 = new MyPoint(8, 14);
        MyPoint P4 = new MyPoint(1, 7);
        MyPoint P5 = new MyPoint(10, 4);

        H.add(P1);
        H.add(P2);
        H.add(P3);
        H.add(P4); // добавиться, так как объект другой
        H.add(P5);
        
        H.add(P2); // не добавиться так как он уже есть в коллекции
        
        Iterator<MyPoint> I3 = H.iterator();

        while(I3.hasNext())
        {
            System.out.println(I3.next());
        }
        
        System.out.println("--");
        TreeSet<MyPoint> H1 = new TreeSet<>(); // MyPoint - должен реализовать интерфейс Comparable
      

        H1.add(P1);
        H1.add(P2);
        H1.add(P3);
        H1.add(P4); // НЕ добавиться
        H1.add(P5);
        
        H1.add(P2); // НЕ добавиться так как он уже есть в коллекции
        
        I3 = H1.iterator();

        while(I3.hasNext())
        {
            System.out.println(I3.next());
        }
    }
    
}
