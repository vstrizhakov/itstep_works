/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package interfaces;

/**
 *
 * @author PC
 */
public class ATM implements Cashouter
{
    @Override
    public double getBalance(Card card)
    {
        return card.getBalance();
    }
    
    @Override
    public boolean cashOut(Card card, double quantity)
    {
        double balance = card.getBalance();
        if (balance >= quantity)
        {
            card.setBalance(balance - quantity);
            return true;
        }
        else
        {
            return false;
        }
    }
}
