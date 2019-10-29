package com.vstrizhakov.collapsigtoolbarlayout;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity
{
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		String str = "";
		for (int i = 0; i < 1000; i++)
		{
			str += "je;oasdijoiwr Hello , world" + i + " spof ";
		}
		TextView tvOne = findViewById(R.id.tvOne);
		tvOne.setText(str);
		
		Toolbar toolbar = findViewById(R.id.toolbar);
		toolbar.setTitle("Title zpofgw");
	}
}
