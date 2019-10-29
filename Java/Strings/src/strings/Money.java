/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package strings;

/**
 *
 * @author PC
 */
public class Money {
    private int grn;
    private int kop;
    
    public Money(int grn, int kop)
    {
        this.grn = grn + kop / 100;
        this.kop = kop % 100;
    }
    
    public void setGrn(int g)
    {
        this.grn = g;
    }
    
    public int getGrn()
    {
        return this.grn;
    }
    
    @Override
    public String toString()
    {
        return "Сумма: " + this.grn + "." + this.kop + " грн";
    }
}
