package com.vstrizhakov.converter;

public class CurrencyPair
{
	private Currency _fromCurrency;
	private Currency _toCurrency;
	private double _exchangeRate;
	
	public CurrencyPair(Currency fromCurrency, Currency toCurrency, double exchangeRate)
	{
		_fromCurrency = fromCurrency;
		_toCurrency = toCurrency;
		_exchangeRate = exchangeRate;
	}
	
	public Currency getFromCurrency()
	{
		return  _fromCurrency;
	}
	
	public Currency getToCurrency()
	{
		return _toCurrency;
	}
	
	public double getExchangeRate()
	{
		return _exchangeRate;
	}
}
