/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package classes;

import classes.Street.House;
import java.lang.reflect.Field;
import java.lang.reflect.Method;

/**
 *
 * @author PC
 */
public class Classes {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
//        MyNumber n = new MyNumber(7);
//        MyNumber z = new MyNumber(7);
//        
//        if (n.equals(n))
//        {
//            System.out.println("TRUE");
//        }
//        else
//        {
//            System.out.println("FALSE");
//        }
//        
//        Class<?> C = n.getClass();
//        System.out.println("Имя Класса: " + C.getName());
//        Field[] arrF = C.getDeclaredFields();
//        for (Field F : arrF)
//            System.out.println(F);
//        Method[] arrM = C.getMethods();
//        for (Method M : arrM)
//            System.out.println(M);
//        
//        Street R = new Street("Рекордная");
//        Street.House H1 = R.addHouse("20-a");
//        Street.House H2 = R.addHouse("18");
//        
//        System.out.println(H1);
//        System.out.println(H2);
//        System.out.println("=====");
//        System.out.println(R);
//        
//        Subscriber sub = new Subscriber("Bill Gates");
//        sub.readLetter(new Letter("Поздравление", "Поздравленяем с Новім Годом!\nСП-2811")
//        {
//            @Override
//            public void showLetter()
//            {
//                System.out.println("***************************************");
//                System.out.println("**************" + this.title);
//                System.out.println("***************************************");
//                System.out.println("**************" + this.text);
//            }
//        });

        Street street = new Street("ул. Рекордная");
        street.addHouse("18");
        street.addHouse("20-а");
        House house = street.getHouse("18");
        house.addApartment(12);
        house.addApartment(34);
        house.addApartment(290);
        house.addApartment(7);
        house.addApartment(56);
        house.addApartment(89);
        house.addApartment(134);
        house.addApartment(211);
        house.addApartment(92);
        
        house.prinInfo();
    }
    
}
