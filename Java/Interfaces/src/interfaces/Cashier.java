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
public class Cashier implements Cashouter
{
    private String _firstName;
    private String _lastName;
    
    public Cashier(String firstname, String lastname)
    {
        _firstName = firstname;
        _lastName = lastname;
    }
    
    public String getFirstName()
    {
        return _firstName;
    }
    
    public String getLastName()
    {
        return _lastName;
    }
    
    public String getFullName()
    {
        return _firstName + " " + _lastName;
    }
    
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
