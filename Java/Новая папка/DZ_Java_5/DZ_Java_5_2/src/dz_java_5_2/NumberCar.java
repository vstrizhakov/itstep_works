/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dz_java_5_2;

/**
 *
 * @author 09220
 */
public class NumberCar implements Comparable<NumberCar>
{
    private String number;
    private String code;
    private String series;
    
    public NumberCar( String code, String number, String series)
    {
        this.number = number;
        this.code = code;
        this.series = series;
    }
    public String getNumber()
    {
        return this.number;
    }
    public String getCode()
    {
        return this.code;
    } 
    public String getSeries()
    {
        return this.series;
    }
    @Override
    public String toString()
    {
        return this.code+" "+this.number+" "+this.series;
    }

    @Override
    public int compareTo(NumberCar o)
    {
        String S = this.toString();
        String S2 = o.toString();
        int N = this.toString().compareTo(o.toString());
        return N;
    }
    @Override
    public boolean equals(Object o) 
    {
        String S = this.toString();
        String S2 = o.toString();

        return S.equals(S2);
    }
    
}
