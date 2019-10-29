package com.vstrizhakov.incodelayoutmanagers;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.TableLayout;
import android.widget.TableRow;

public class MainActivity extends AppCompatActivity
{
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
//		LinearLayout mainLL = findViewById(R.id.llMain);
//
//		// LinearLayout
//		LinearLayout LL = new LinearLayout(this);
//		LL.setOrientation(LinearLayout.VERTICAL);
//		mainLL.addView(LL);
//
//		for (int i = 0; i < 3; i++)
//		{
//			Button btn = new Button(this);
//			btn.setText("Button " + (i + 1));
//			LL.addView(btn);
//		}
//
//		TableLayout TL = new TableLayout(this);
//		TL.setStretchAllColumns(true);
//		mainLL.addView(TL);
//
//		TableRow TR1 = new TableRow(this);
//		TL.addView(TR1);
//		for (int i = 0; i < 3; i++)
//		{
//			Button btn = new Button(this);
//			btn.setText("Button1 " + (i + 1));
//			TR1.addView(btn);
//		}
//
//		TableRow TR2 = new TableRow(this);
//		TL.addView(TR2);
//		for (int i = 0; i < 3; i++)
//		{
//			Button btn = new Button(this);
//			btn.setText("Button2 " + (i + 1));
//			TR2.addView(btn);
//		}
	}
}
