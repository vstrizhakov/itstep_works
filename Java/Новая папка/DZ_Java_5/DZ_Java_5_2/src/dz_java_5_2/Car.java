/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dz_java_5_2;

/**
 *
 * @author User
 */
public class Car implements Comparable<Car>
{
    public String model;
    public String color;
    public int year;
    public double engineCapacity;
    private NumberCar number;
    public Car(String model, String color, int year, double engineCapacity, NumberCar number)
    {
        this.model = model;
        this.color = color;
        this.year = year;
        this.engineCapacity = engineCapacity;
        this.number = number;
    }
    @Override
    public int compareTo(Car o) //>0, =0, <0
    {
        double n= this.engineCapacity-o.engineCapacity;
        
        if(n>0)
            n=1;
        else if(n<0)
            n=-1;      
        
        return (int)n;
    }
    @Override
    public String toString()
    {
        return "Номер: "+this.number+"\nМодель: "+this.model+"\nЦвет: "+this.color+"\nГод: "+this.year+"\nОбъем двигателя: "+this.engineCapacity+"л.";
    }
    public NumberCar getNumber()
    {
        return this.number;
    }
}
