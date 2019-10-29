/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package classes;

import java.util.ArrayList;
import java.util.TreeSet;

/**
 *
 * @author PC
 */
public class Street {
    private String name;
    
    private TreeSet<House> houses = new TreeSet<>();
    
    public Street(String name)
    {
        this.name = name;
    }
        
    public House getHouse(String number)
    {
        for (House house : houses)
        {
            if (house.number.contentEquals(house.number))
            {
                return house;
            }
        }
        return null;
    }
    
    class House implements Comparable<House>
    {
        private String number;
        
        private TreeSet<Apartment> _apartments = new TreeSet<>();
    
        public House(String number)
        {
            this.number = number;
        }
        
        @Override
        public String toString()
        {
            return Street.this.name + ", д." + number;
        }
        
        @Override
        public int compareTo(House h)
        {
            return number.compareTo(h.number);
        }
        
        public void prinInfo()
        {
            System.out.println("Улица " + Street.this.name + ", Дом #" + number + " (" + _apartments.size() + " квартир)");
            for (Apartment a : _apartments)
            {
                System.out.println("Квартира #" + a._number);
            }
        }
        
        class Apartment implements Comparable<Apartment>
        {
            private int _number;
            
            public Apartment(int number)
            {
                _number = number;
            }
            
            @Override
            public String toString()
            {
                return Street.this.name + ", д. " + House.this.number + ", кв. " + number;
            }
            
            @Override
            public int compareTo(Apartment a)
            {
                return (_number == a._number) ? 0 : _number - a._number;
            }
        }
        
        public Apartment addApartment(int number)
        {
            Apartment apartment = new Apartment(number);
            _apartments.add(apartment);
            return apartment;
        }
    }
    
    public House addHouse(String number)
    {
        House H = new House(number);
        houses.add(H);
        return H;
    }
    
    @Override
    public String toString()
    {
        String S = "ул." + name + "\n";
        for (House H : houses)
        {
            S += H.toString() + "\n";
        }
        return S;
    }
}
