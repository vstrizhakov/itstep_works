package com.vstrizhakov.crocodile.Api.Models;

public class UserCredentials
{
	public String nickname;
	public String password;
	
	public UserCredentials()
	{
	
	}
	
	public UserCredentials(String nickname, String password)
	{
		this.nickname = nickname;
		this.password = password;
	}
}
