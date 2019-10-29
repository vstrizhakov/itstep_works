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
public class Card
{
	private Owner _owner;
	private double _balance;
        
        public Card(Owner owner, double startBalance)
        {
            _owner = owner;
            _balance = startBalance;
        }

	public double getBalance()
	{
		return _balance;
	}

	public void setBalance(double balance)
	{
		_balance = balance;	
	}

	public Owner getOwner()
	{
		return _owner;
	}
}