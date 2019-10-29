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
public class Letter {
    protected String title;
    protected String text;
    
    public Letter(String title, String text)
    {
        this.title = title;
        this.text = text;
    }
    
    public void showLetter()
    {
        System.out.println("Title: " + title);
        System.out.println("Text\n=======");
        System.out.println(text);
    }
}
