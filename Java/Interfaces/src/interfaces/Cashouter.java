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
public interface Cashouter
{
	public double getBalance(Card card);
	public boolean cashOut(Card card, double quantity);
}