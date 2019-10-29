package com.vstrizhakov.framelayoutlll;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity
{
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		CheckBox cb = findViewById(R.id.cbJava);
		cb.setOnCheckedChangeListener(
				new CompoundButton.OnCheckedChangeListener()
				{
					@Override
					public void onCheckedChanged(CompoundButton buttonView, boolean isChecked)
					{
						String msg = (isChecked)
								? "Java выбран" : "Java не выбран";
						Toast.makeText(MainActivity.this, msg, Toast.LENGTH_SHORT).show();
					}
				}
		);
	}
}
