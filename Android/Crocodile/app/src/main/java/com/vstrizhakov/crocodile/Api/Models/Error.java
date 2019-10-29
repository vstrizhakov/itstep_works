package com.vstrizhakov.crocodile.Api.Models;

import com.google.gson.Gson;

import java.lang.reflect.Type;

public class Error
{
	final static private Gson _gson = new Gson();
	
	public String message;
	
	public Error()
	{
	
	}
	
	public Error(String message)
	{
		this.message = message;
	}
}
