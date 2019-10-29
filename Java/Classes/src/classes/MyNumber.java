/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package classes;

/**
 *
 * @author PC
 */
public class MyNumber {
    private int number;
    
    public MyNumber(int n)
    {
        number = n;
    }
    
    @Override
    public String toString()
    {
        return "number = " + number;
    }
}
