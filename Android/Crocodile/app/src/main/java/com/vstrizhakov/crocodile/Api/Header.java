package com.vstrizhakov.crocodile.Api;

public class Header
{
	private String _key;
	private String _value;
	
	public Header(String key, String value)
	{
		_key = key;
		_value = value;
	}
	
	public String getKey()
	{
		return _key;
	}
	
	public String getValue()
	{
		return _value;
	}
}
