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
public class Subscriber {
    private String name;
    
    public Subscriber(String name)
    {
        this.name = name;
    }
    
    public void readLetter(Letter letter)
    {
        System.out.println("Получатель " + name + " получил письмо: ");
        letter.showLetter();
    }
}
