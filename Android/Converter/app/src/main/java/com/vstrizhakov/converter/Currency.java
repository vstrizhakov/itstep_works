package com.vstrizhakov.converter;

public class Currency
{
	private String _abbreviation;
	private String _name;
	private String _symbol;
	
	public Currency(String abbreviation, String name, String symbol)
	{
		_abbreviation = abbreviation;
		_name = name;
		_symbol = symbol;
	}
	
	public String getAbbreviation()
	{
		return _abbreviation;
	}
	
	public String getName()
	{
		return  _name;
	}
	
	public String getSymbol()
	{
		return _symbol;
	}
	
	@Override
	public String toString()
	{
		return _symbol + " " + _abbreviation + " - " + _name;
	}
}
