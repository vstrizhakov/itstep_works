 /*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dz_java_5_2;

import java.io.InputStreamReader;
import java.io.LineNumberReader;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map.Entry;
import java.util.TreeMap;

/**
 *
 * @author User
 */
public class DZ_Java_5_2
{

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args)
    {
        TreeMap<NumberCar, Car> mapCar = new TreeMap<NumberCar, Car>();
        
        Car C1 = new Car("Mersedes", "Black", 2015, 6.4, new NumberCar( "AH","9999", "АБ"));
        Car C2 = new Car("Lexus", "White", 2016, 5.4, new NumberCar("AH","5642", "АБ"));
        Car C3 = new Car("Mazda", "Black", 2014, 7.4, new NumberCar( "СА","1111", "АА"));
        Car C4 = new Car("BMW", "Gray", 2018, 9.4, new NumberCar( "AИ","2323", "ББ"));

        mapCar.put(C1.getNumber(),C1);
        mapCar.put(C2.getNumber(),C2);
        mapCar.put(C3.getNumber(),C3);
        mapCar.put(C4.getNumber(),C4);
       

        StringBuilder sb;
        String model="";
        String color = "";
        int year = 0;
        Car car;
        double engineCapacity = 0;
        NumberCar key;
BR:
        while(true)
        {
            
            System.out.println("\n1. Добавить автомобиль.");
            System.out.println("2. Удалить автомобиль.");
            System.out.println("3. Редактировать автомобиль.");
            System.out.println("4. Найти по номеру.");
            System.out.println("5. Список автомобилей.");
            System.out.println("0. Выход.");
            
            System.out.println("");
            System.out.print("Ваш выбор: ");
            int n = getInt();

            switch(n)
            {
                case 1:
                    car = newCar();
                    mapCar.put(car.getNumber(), car);
                    break;
                case 2:
                    if(mapCar.size() == 0)
                    {
                        System.out.println("Список пуст!!");
                        break;
                    }
                    sb = new StringBuilder();
                    for(NumberCar k:mapCar.keySet())
                        sb.append("\n"+k);
                    System.out.print("Введите номер из представленных\n"+sb.toString());
                    
                    key = inputNumber();
                    if(!mapCar.containsKey(key))
                        System.out.println("\nНет такого ключа!!\n");
                    else
                        mapCar.remove(key);
                    break;               
                case 3:
                    System.out.println("\nВыберите машину из представленных:");
                    for(Entry entry: mapCar.entrySet()) 
                        System.out.println(entry.getValue()+"\n");

                    System.out.print("Ваш выбор: ");
                    key =  inputNumber();
                    if(!mapCar.containsKey(key))
                    {
                        System.out.println("\nНет такого ключа!!\n");
                        break;
                    }
                    car = mapCar.get(key);
                    
                    System.out.println("Выберите что отредактировать:");
                    System.out.println("1) Марка: "+mapCar.get(key).model);
                    System.out.println("2) Цвет: "+mapCar.get(key).color);
                    System.out.println("3) Год: "+mapCar.get(key).year);
                    System.out.println("4) Объем двигателя: "+mapCar.get(key).engineCapacity);
                    color = car.color;
                    model = car.model;
                    year = car.year;
                    engineCapacity = car.engineCapacity;
                    int m = getInt();
                    switch(m)
                    {
                        case 1:
                            System.out.print("новое значение: ");
                            model = getString();
                            model = model.trim();
                            break;
                        case 2:
                            System.out.print("новое значение: ");
                            color = getString();
                            color = getString();
                            break;
                        case 3:
                            System.out.print("новое значение: ");
                            year = getInt();
                            break;
                        case 4:
                            System.out.print("новое значение: ");
                            engineCapacity = getDouble();
                            break;
                        default:
                            System.out.println("\nТакого варианта нет");
                            break;
                    }
                    if(model.isEmpty() && color.isEmpty())
                        System.out.println("\nНе все поля заполнены\n");
                    else
                    {
                       car.color = color;
                       car.model = model;
                       car.year = year;
                       car.engineCapacity = engineCapacity;
                    }
                    break;                
                case 4:
                    System.out.println("\nВыберите машину из представленных:");
                    for(Entry entry: mapCar.entrySet()) 
                        System.out.println(entry.getValue()+"\n");
                    key =  inputNumber();
                    Car val = keyEntry(mapCar,key);
                    if(val != null)
                        System.out.println(val);                  
                    break;                
                case 5:
                    for(Entry entry: mapCar.entrySet()) {
                        System.out.println(entry.getValue()+"\n");
                    }
                    break;  
                default:
                    break BR;
            }
           
        }
    }
//    public static boolean containsKeyMap(TreeMap<NumberCar, Car> M, NumberCar N)
//    {
//        for(NumberCar c:M.keySet())
//            if(c.equals(N)) 
//                return true;
//        
//        return false;
//    }
    public static Car keyEntry(TreeMap<NumberCar, Car> mapCar, NumberCar key)
    {
        if(!mapCar.containsKey(key))
        {
            System.out.println("\nНет такого ключа!!\n");
            return null;
        }
        return mapCar.get(key);
    }
    public static Car newCar()
    {
        String model;
        String color;
        int year;
        double engineCapacity;
        String[] arrN;
        while(true)
        {
            System.out.print("-> Марка: ");
            model= getString();
            System.out.print("-> Цвет: ");
            color = getString();
            System.out.print("-> Год: ");
            year = getInt();
            System.out.print("-> Объем двигателя: ");
            engineCapacity = getDouble();
            
            System.out.print("Номер автомобиля (AA 1234 AA): ");
            String N = getString();
            arrN = N.trim().split("\\s+");
            if(arrN.length != 3)
            {
                System.out.println("-->Не верный ввод номера<--");
                continue;
            }
            model = model.trim();
            color = color.trim();
            if(model.isEmpty() && color.isEmpty())
                System.out.println("\nНе все поля заполнены\n");
            else    
                break;
                
        }
        
        return new Car(model, color, year, engineCapacity, new NumberCar(arrN[0], arrN[1], arrN[2]));
    }
    public static NumberCar inputNumber()
    {
        String[] arrN;
        while(true)
        {
            System.out.print("\nНомер автомобиля (AA 1234 AA): ");
            String N = getString();
            arrN = N.trim().split("\\s+");
            if(arrN.length != 3)
                System.out.println("-->Не верный ввод номера<--");
            else
                break;
        }
        return new NumberCar(arrN[0], arrN[1], arrN[2]);
    }
    public static void CarEdit()
    {
        
    }
public static String getString()
{        
        String  S   = "";
        try
        {
            LineNumberReader    LNR = new LineNumberReader(new InputStreamReader(System.in, "CP1251"));
            S   = LNR.readLine();
        }
        catch (Exception ioe) 
        {
            S   = "";
        }
        return  S;
}
public static int getInt()
{
        try
        {
            return Integer.parseInt(getString());
        }
        catch (Exception ie) 
        {
            return 0;
        }
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
