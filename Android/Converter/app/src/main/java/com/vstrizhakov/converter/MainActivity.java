package com.vstrizhakov.converter;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Spinner;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity
{
	private ArrayList<CurrencyPair> _pairs;
	private CurrencyPair _currentPair;
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		Currency uah = new Currency("UAH", "Гривна", "₴");
		Currency usd = new Currency("USD", "Доллар США", "$");
		Currency eur = new Currency("EUR", "Евро", "€");
		
		final Currency[] _currencies =
				{
					uah, usd, eur
				};
		
		CurrencyPair[] startPairs =
				{
						new CurrencyPair(usd, uah, 27.3),
						new CurrencyPair(eur, uah, 30.83),
						new CurrencyPair(usd, eur, 0.88)
				};
		
		_pairs = new ArrayList<>();
		for (CurrencyPair pair : startPairs)
		{
			_pairs.add(pair);
			double reverseExchangeRate = 0.99 / pair.getExchangeRate();
			CurrencyPair reversePair = new CurrencyPair(pair.getToCurrency(), pair.getFromCurrency(), reverseExchangeRate);
			_pairs.add(reversePair);
		}
		
		Spinner fromSpinner = findViewById(R.id.fromCurrencySpinner);
		Spinner toSpinner = findViewById(R.id.inCurrencySpinner);
		ArrayAdapter<Currency> adapter = new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, _currencies);
		fromSpinner.setAdapter(adapter);
		toSpinner.setAdapter(adapter);
		AdapterView.OnItemSelectedListener selectedListener = new AdapterView.OnItemSelectedListener()
		{
			@Override
			public void onItemSelected(AdapterView<?> parent, View view, int position, long id)
			{
				boolean isFrom = (parent.getId() == R.id.fromCurrencySpinner);
				Spinner oppositeSpinner = findViewById( isFrom ? R.id.inCurrencySpinner : R.id.fromCurrencySpinner);
				Currency selectedCurrency = (Currency)parent.getAdapter().getItem(position);
				Currency oppositeCurrency = (Currency)oppositeSpinner.getSelectedItem();
				if (selectedCurrency.getAbbreviation().contentEquals(oppositeCurrency.getAbbreviation()))
				{
					for (CurrencyPair pair : _pairs)
					{
						Currency currency = (!isFrom) ? pair.getFromCurrency() : pair.getToCurrency();
						if (currency.getAbbreviation().contentEquals(selectedCurrency.getAbbreviation()))
						{
							oppositeCurrency = pair.getToCurrency();
							break;
						}
					}
					if (oppositeCurrency != null)
					{
						ArrayAdapter<Currency> adapter = (ArrayAdapter<Currency>)oppositeSpinner.getAdapter();
						int count = adapter.getCount();
						for (int i = 0; i < count; i++)
						{
							Currency currency = adapter.getItem(i);
							if (currency != null)
							{
								if (currency.getAbbreviation().contentEquals(oppositeCurrency.getAbbreviation()))
								{
									oppositeSpinner.setSelection(i);
									break;
								}
							}
						}
					}
				}
			}
			
			@Override
			public void onNothingSelected(AdapterView<?> parent)
			{
			
			}
		};
		fromSpinner.setOnItemSelectedListener(selectedListener);
		toSpinner.setOnItemSelectedListener(selectedListener);
	}
}
