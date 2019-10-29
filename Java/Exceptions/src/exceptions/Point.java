/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package exceptions;

/**
 *
 * @author PC
 */
public class Point implements Comparable<Point> {
    private int x;
    private int y;
    
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
        System.out.println("Point ctor #1");
    }
    
    @Override
    public String toString()
    {
        return "x = " + x + ", y = " + y;
    }
    
    @Override
    public int compareTo(Point p)
    {
        return (int)Math.sqrt(x * x + y * y) - (int)Math.sqrt(p.x * p.x + p.y * p.y);
    }
}
