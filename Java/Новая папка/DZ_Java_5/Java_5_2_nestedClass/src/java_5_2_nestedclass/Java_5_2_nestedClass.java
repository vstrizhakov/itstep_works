/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package java_5_2_nestedclass;

/**
 *
 * @author 09220
 */
public class Java_5_2_nestedClass {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
       // Street.House H = new Street.House("20-а") // ошибка компиляции
        try
        {
            Street R = new Street("Рекордная");
            Street.House H1 = R.addHouse("20-a");
            Street.House H2 = R.addHouse("18");
            Street.House H3 = R.addHouse("18");

            Street.House.Flat F1 = H1.add(12);
            Street.House.Flat F2 = H1.add(15);
            Street.House.Flat F3 = H1.add(15);

            System.out.println(H1);
            System.out.println(H2);
            System.out.println("=====");
            System.out.println(R);
            System.out.println("=====");
            System.out.println(F1);
            System.out.println(F2);
        }
        catch(Exception e)
        {
            e.printStackTrace();
        }
        


    }
    
}
