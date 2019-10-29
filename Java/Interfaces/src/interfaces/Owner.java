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
public class Owner
{
	private String _firstName;
	private String _lastName;

	public Owner(String firstname, String lastname)
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
}
