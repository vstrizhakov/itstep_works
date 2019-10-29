package com.vstrizhakov.drawnwidgetbypaint;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;

public class MainActivity extends AppCompatActivity
{
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		final Toolbar toolbar = findViewById(R.id.toolbar);
		setSupportActionBar(toolbar);
		toolbar.setTitle("My Color Picker");
		
		MyColorPicker picker = findViewById(R.id.mcpOne);
		picker.addOnColorPickListener(new MyColorPicker.OnColorPickListener()
		{
			@Override
			public void onColorPick(int color)
			{
				toolbar.setBackgroundColor(color);
			}
		});
	}
}
