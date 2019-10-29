/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package java_6_2_collection;
/**
 *
 * @author 09220
 */
public class MyPoint implements Comparable<MyPoint>{
    private int x;
    private int y;
    public MyPoint(int x, int y)
    {
        this.x= x;
        this.y=y;
        System.out.println("My Point Ctor #1");
    }
    @Override
    public String toString()
    {
        return "x = "+this.x+", y = "+this.y;
    }

    @Override
    public int compareTo(MyPoint o) //>0, =0, <0
    {
        return (int)(Math.sqrt(this.x*this.x+this.y*this.y) - Math.sqrt(o.x*o.x+o.y*o.y));
    }
}
