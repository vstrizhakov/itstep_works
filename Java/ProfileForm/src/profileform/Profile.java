/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package profileform;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.Date;

/**
 *
 * @author PC
 */
public class Profile implements Serializable
{
    private String _firstName;
    private String _lastName;
    private boolean _sex;
    private Date _birthday;
    private ArrayList<String> _interests;

    public Profile(String firstname, String lastname, boolean sex, Date birthday, ArrayList<String> interests)
    {
        _firstName = firstname;
        _lastName = lastname;
        _sex = sex;
        _birthday = birthday;
        _interests = interests;
    }

    public String getFirstName()
    {
        return _firstName;
    }

    public String getLastName()
    {
        return _lastName;
    }

    public boolean getSex()
    {
        return _sex;
    }

    public Date getBirthday()
    {
        return _birthday;
    }

    public ArrayList<String> getInterests()
    {
        return _interests;
    }
    
    public void addInterest(String str)
    {
        _interests.add(str);
    }
    
    public void removeInterest(String str)
    {
        _interests.remove(str);
    }
    
    public void setFirstName(String str)
    {
        _firstName = str;
    }
    
    public void setLastName(String str)
    {
        _lastName = str;
    }
    
    public void setBirthday(Date date)
    {
        _birthday = date;
    }
    
    public void setSex(boolean bool)
    {
        _sex = bool;
    }
}
