package com.vstrizhakov.anotherlayoutsincode;

import android.graphics.Color;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Gravity;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.GridLayout;

public class MainActivity extends AppCompatActivity
{
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		GridLayout GL = new GridLayout(this);
		GL.setOrientation(GridLayout.HORIZONTAL);
		GL.setBackgroundColor(Color.rgb(0xD0, 0xF0, 0xD0));
		GL.setColumnCount(3);
		GL.setRowCount(4);
		
//		GridLayout.LayoutParams LP = new GridLayout.LayoutParams();
//		LP.width = ViewGroup.LayoutParams.MATCH_PARENT;
//		LP.height = ViewGroup.LayoutParams.MATCH_PARENT;
//		LP.setGravity(Gravity.CENTER);
//		GL.setLayoutParams(LP);
		
		for (int i = 1; i <= 7; i++)
		{
			Button btn = new Button(this);
			btn.setText("Button " + i);
			GL.addView(btn);
		}
		
		Button bb = new Button(this);
		bb.setText("Button 8");
		
		GridLayout.Spec rowSpec = GridLayout.spec(3);
		GridLayout.Spec colSpec = GridLayout.spec(0);
		
		GridLayout.LayoutParams lp = new GridLayout.LayoutParams(rowSpec, colSpec);
		GL.addView(bb, lp);
		
		for (int i = 0; i <= 10; i++)
		{
			Button btn = new Button(this);
			btn.setText("Button " + i);
			GL.addView(btn);
		}
		
		setContentView(GL);
		
	}
}
