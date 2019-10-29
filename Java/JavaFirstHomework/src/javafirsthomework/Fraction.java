/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javafirsthomework;

/**
 *
 * @author PC
 */
public class Fraction {
    private int numerator = 0;
    private int denominator = 1;
    
    public final void setNumerator(int n)
    {
        numerator = n;
    }
    
    public final void setDenominator(int n)
    {
        if (n == 0)
        {
            return;
        }
        denominator = n;
    }
    
    public int getNumerator()
    {
        return numerator;
    }
    
    public int getDenominator()
    {
        return denominator;
    }
    
    /***
     * 
     * @param numerator Числитель
     * @param denominator Знаменатель
     */
    public Fraction(int numerator, int denominator)
    {
        setNumerator(numerator);
        setDenominator(denominator);
    }
    
    public Fraction(String str) throws Exception
    {
        String[] ab = str.split("/");
        setNumerator(Integer.parseInt(ab[0]));
        setDenominator(Integer.parseInt(ab[1]));
    }
    
    public Fraction(double numerator, double denominator)
    {
        setNumerator((int)(numerator * 100));
        setDenominator((int)(denominator * 100));
    }
    
    public Fraction Clone()
    {
        return new Fraction(numerator, denominator);
    }
    
    public void Reduce()
    {
        int commonDivider = 1;
        int min = numerator;
        if (numerator > denominator)
        {
            min = denominator;
        }
        for (int i = 1; i < min; i++)
        {
            if (numerator % i == 0 && denominator % i == 0)
            {
                commonDivider = i;
            }
        }
        this.numerator /= commonDivider;
        this.denominator /= commonDivider;
    }
}
