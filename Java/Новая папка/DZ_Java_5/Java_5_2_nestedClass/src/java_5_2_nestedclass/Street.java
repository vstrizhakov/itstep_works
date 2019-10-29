/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package java_5_2_nestedclass;

import java.util.ArrayList;

/**
 *
 * @author 09220
 */
public class Street {
    private String name;
    private ArrayList<House> houses = new ArrayList<>();
    class House
    {
        private String number;
        private ArrayList<Flat> flats = new ArrayList<>();
                
        public House(String number)
        {
            this.number = number;
        }
        public Flat add(int number) throws Exception 
        {
            for(int i=0; i<this.flats.size(); i++)
            {
                if(this.flats.get(i).number == number)
                    throw new Exception("Квартира №"+number+" уже существует"); 
            }
            
            Flat F = new Flat(number);
            this.flats.add(F);
            return F;
        }
        @Override
        public String toString()
        {
            String str ="ул."+Street.this.name+", д."+this.number+"\n";
            for(Flat F:this.flats)
                str += F.toString()+"\n";
            return str;
        }
        class Flat
        {
            private int number;
            public Flat(int number)
            {
                this.number = number;
            }
            @Override
            public String toString()
            {
                return  "ул."+Street.this.name+", д."+House.this.number+", к."+this.number;
            }
        }
    }
    public Street(String str)
    {
        this.name = str;
    }
    public House addHouse(String number) throws Exception
    {
         for(int i=0; i<this.houses.size(); i++)
        {
            if(this.houses.get(i).number == number)
                   throw new Exception("Дом №"+number+" уже существует"); 
        }
        House H = new House(number);
        this.houses.add(H);
        return H;
    }
    @Override
    public String toString()
    {
        String S= "ул. "+this.name+"\n";
        for(House h:this.houses)
            S += h.toString()+"\n";

        return S;
    }
}
