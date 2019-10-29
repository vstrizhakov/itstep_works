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
public class Interfaces {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Owner owner = new Owner("Владимир", "Стрижаков");
        Card card = new Card(owner, 1170.90);
        Bank bank = new Bank();
        bank.addCard(card);
        
        bank.CashOut(owner);
    }
    
}
