package com.vstrizhakov.materialdesign;

import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity
{
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		ArrayList<String> arrayList = new ArrayList<>();
		for (int i = 0; i < 150; i++)
		{
			arrayList.add("Hello, World #" + (i + 1));
		}
		ArrayAdapter<String> adapter = new ArrayAdapter<>(
				this,
				android.R.layout.simple_list_item_1	,
				arrayList);
		ListView listView = findViewById(R.id.listView);
		listView.setAdapter(adapter);
		
		findViewById(R.id.fab).setOnClickListener(new View.OnClickListener()
		{
			@Override
			public void onClick(View v)
			{
//				Toast.makeText(MainActivity.this, "Floating Action Button Pressed!", Toast.LENGTH_LONG).show();
//
//				Snackbar.make(findViewById(R.id.llMain), "Hello, World!", Snackbar.LENGTH_LONG).show();
			
				Snackbar.make(findViewById(R.id.llMain), "Android Forever!", Snackbar.LENGTH_INDEFINITE)
						.setAction("OK", new View.OnClickListener()
						{
							@Override
							public void onClick(View view)
							{
								Toast.makeText(MainActivity.this, "OK Pressed", Toast.LENGTH_SHORT).show();
							}
						}).show();
			}
		});
	}
}
