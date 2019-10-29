package com.vstrizhakov.third;

import android.graphics.Color;
import android.graphics.Point;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.Display;
import android.view.MotionEvent;
import android.view.View;
import android.widget.LinearLayout;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity
{
	private TextView _tvClickInfo;
	private TextView _tvMotionInfo;
	private int _cntClick = 0;
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		_tvClickInfo = findViewById(R.id.tvClickInfo);
		_tvMotionInfo = findViewById(R.id.tvMotionInfo);
		final LinearLayout linearLayout = findViewById(R.id.ll1);
		
		linearLayout.setOnClickListener(new View.OnClickListener()
		{
			@Override
			public void onClick(View v)
			{
				MainActivity.this._cntClick++;
				MainActivity.this._tvClickInfo.setText("Количество кликов: " + MainActivity.this._cntClick);
			}
		});
		
		linearLayout.setOnTouchListener(new View.OnTouchListener()
		{
			private double prevX;
			private double prevY;
			
			private double normalize(double n)
			{
				if (n < -1) n = -1;
				if (n > 1) n = 1;
				return n;
			}
			
			@Override
			public boolean onTouch(View v, MotionEvent event)
			{
				int action = event.getAction();
				double x = event.getX();
				double y = event.getY();
				switch (action)
				{
					case MotionEvent.ACTION_DOWN:
						prevX = x;
						prevY = y;
						break;
					case MotionEvent.ACTION_MOVE:
					{
						Display screensize = getWindowManager().getDefaultDisplay();
						Point size = new Point();
						screensize.getSize(size);
						
						x -= size.x / 2;
						y -= size.y / 2;
						
						double difX = normalize(x / size.x * 2);
						double difY = -normalize(y / size.y * 2);
						
						double xAngle = Math.acos(difX) * (180 / Math.PI);
						double yAngle = Math.asin(difY) * (180 / Math.PI) + 90;
						
						int difXa = (int)Math.abs(xAngle - prevX);
						int difYa = (int)Math.abs(yAngle - prevY);
						
						Log.d("======", "X: " + difXa);
						Log.d("======", "Y: " + difYa);
						
						int i=0;
						
						int min = 2;
						if (difXa > difYa) i = 1;
						else if (difXa < difYa) i = 0;
						else i = 2;
						
						int color = Color.WHITE;
						switch (i)
						{
							case 0:
								color = Color.YELLOW;
								break;
							case 1:
								color = Color.GREEN;
								break;
							case 2:
								color = Color.RED;
								break;
						}
						linearLayout.setBackgroundColor(color);
						prevX = xAngle;
						prevY = yAngle;
					}
					break;
				}
				return false;
			}
		});
	}
}
