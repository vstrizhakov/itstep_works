/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dz_java_5_1;

/**
 *
 * @author 09220
 */
public class Money {
    private int grn;
    private int kop;
    
    public Money(int grn, int kop) throws Exception 
    {
        if(grn <0 || kop < 0)
            ThrowMoney.NegativeMoneyExeption();
   
        this.grn = grn+kop/100;
        this.kop = kop%100;
    }
    public void setGrn(int g)
    {
        this.grn = g;
    }
    public int getGrn()
    {
        return this.grn;
    }
     public void setKop(int k)
    {
        this.kop = k%100;
        this.grn += k/100;
    }
    public int getKop()
    {
        return this.kop;
    }
    public static Money subMoney(Money M1, Money M2) throws Exception
    {
        int cop =0;
        cop = M1.grn*100+M1.kop-M2.grn*100 - M2.kop;
        if(cop < 0)
            ThrowMoney.BankrotExeption();
    
        return new Money(cop/100, cop%100);
    }
    public static Money sumMoney(Money M1, Money M2) throws Exception
    {
        int cop = M1.grn*100+M1.kop+M2.grn*100 + M2.kop;
        return new Money(cop/100, cop%100);
    }
    @Override
    public String toString()
    {
        return "Сумма : "+this.grn+"."+this.kop+"грн";
    }
}
