/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package java_14_1_cellrenderer;

/**
 *
 * @author 09220
 */
public class Persona
{
    private String lastname;
    private String firstname;
    private int age;
    private boolean gender;

    public Persona(String lastname, String firstname, int age, boolean gender)
    {
        this.lastname = lastname;
        this.firstname = firstname;
        this.age = age;
        this.gender = gender;
    }

    @Override
    public String toString()
    {
       return this.lastname+" "+this.firstname+", "+this.age+", "+ (this.gender?"мужской":"женский");
    }

    public int getAge()
    {
        return age;
    }

    public String getFirstname()
    {
        return firstname;
    }

    public String getLastname()
    {
        return lastname;
    }
    public boolean getgender()
    {
        return gender;
    }
    public void setAge(int age)
    {
        this.age = age;
    }

    public void setLastname(String lastname)
    {
        this.lastname = lastname;
    }

    public void setGender(boolean gender)
    {
        this.gender = gender;
    }

    public void setFirstname(String firstname)
    {
        this.firstname = firstname;
    }
    
}
