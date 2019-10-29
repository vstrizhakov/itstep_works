/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package java_12_1_jlist;

/**
 *
 * @author 09220
 */
public class MyPoint
{
    private int x;
    private int y;
    public MyPoint(int x, int y)
    {
        this.x=x;
        this.y=y;
    }
    @Override
    public String toString()
    {
        return "x = "+this.x+", y = " +this.y;
    }
    public int getY()
    {
        return y;
    }
    public int getX()
    {
        return x;
    }
    public void setX(int x)
    {
        this.x = x;
    }
    public void setY(int y)
    {
        this.y = y;
    }
    
}
