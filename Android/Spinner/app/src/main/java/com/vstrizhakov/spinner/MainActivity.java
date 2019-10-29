package com.vstrizhakov.spinner;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.SimpleAdapter;
import android.widget.Spinner;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class MainActivity extends AppCompatActivity
{
	public String[] monthes =
			{
				"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь",
			};
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		Spinner spinner = findViewById(R.id.month_spinner);
		ArrayAdapter<String> adapter =
				new ArrayAdapter<>(this, R.layout.my_spinner_item, monthes);
		adapter.setDropDownViewResource(R.layout.my_dropdown_spinner_item);
		spinner.setAdapter(adapter);
		
		spinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener()
		{
			@Override
			public void onItemSelected(AdapterView<?> parent, View view, int position, long id)
			{
				Toast.makeText(MainActivity.this, monthes[position], Toast.LENGTH_SHORT).show();
			}
			
			@Override
			public void onNothingSelected(AdapterView<?> parent)
			{
			
			}
		});
		
		Product[] products =
				{
						new Product("Snickers", 12.5, 45),
						new Product("Mars", 11.7, 50),
						new Product("CocaCola", 15.9, 1000),
						new Product("Snickers", 16.2, 55),
				};
		Spinner spnProducts = findViewById(R.id.spnSpinner);
		
		ArrayList<Map<String, Object>> prodList = new ArrayList<>();
		for (int i = 0; i < products.length; i++)
		{
			HashMap<String, Object> prodItem = new HashMap<>();
			prodItem.put("Name", products[i].name);
			prodItem.put("Price", products[i].price);
			prodItem.put("Weight", products[i].weight);
			prodList.add(prodItem);
		}
		
		final SimpleAdapter prodAdapter = new SimpleAdapter(this,
				prodList,
				R.layout.my_spinner_item2,
				new String[] {"Name", "Price", "Weight"},
				new int[] { R.id.tvName, R.id.tvPrice, R.id.tvWeight});
		prodAdapter.setDropDownViewResource(R.layout.my_spinner_item2);
		spnProducts.setAdapter(prodAdapter);
		spnProducts.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener()
		{
			@Override
			public void onItemSelected(AdapterView<?> parent, View view, int position, long id)
			{
				HashMap<String, Object> prodItem =
						(HashMap<String, Object>)parent.getAdapter().getItem(position);
				String msg = "Name: " + prodItem.get("Name") + "\n";
				msg += "Price: " + prodItem.get("Price") + "\n";
				msg += "Weight: " + prodItem.get("Weight") + "\n";
				Toast.makeText(MainActivity.this, msg, Toast.LENGTH_LONG).show();
			}
			
			@Override
			public void onNothingSelected(AdapterView<?> parent)
			{
			
			}
		});
	}
}
