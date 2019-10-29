package com.vstrizhakov.game;

import android.content.Context;
import android.os.Bundle;
import android.util.Log;
import android.view.Gravity;
import android.view.View;
import android.widget.Button;
import android.widget.GridLayout;

import java.util.ArrayList;
import java.util.Random;

public class BarleyBreakGame implements View.OnClickListener, BaseGame
{
	private ArrayList<BarleyBreakButton> _area;
	private GridLayout _gridLayout;
	private Button _refreshButton;
	
	private final static int AREA_WIDTH = 4;
	private final static int AREA_HEIGHT = 4;
	
	public BarleyBreakGame(Context context)
	{
		_gridLayout = new GridLayout(context);
		_gridLayout.setOrientation(GridLayout.HORIZONTAL);
		_gridLayout.setColumnCount(AREA_WIDTH);
		_gridLayout.setRowCount(AREA_HEIGHT + 2);
		
		_area = new ArrayList<>();
		for (int i = 0; i < AREA_HEIGHT; i++)
		{
			for (int j = 0; j < AREA_WIDTH; j++)
			{
				int counter = (i * AREA_HEIGHT) + j + 1;
				if (counter == AREA_WIDTH * AREA_HEIGHT) break;
				
				BarleyBreakButton btn = new BarleyBreakButton(context, new Point(j, i), 1);
				btn.setText(String.valueOf(counter));
				btn.setOnClickListener(this);
				
				_area.add(btn);
				_gridLayout.addView(btn);
			}
		}
		
		_refreshButton = new Button(context);
		_refreshButton.setText("Перемешать");
		_refreshButton.setOnClickListener(new View.OnClickListener()
		{
			@Override
			public void onClick(View v)
			{
				BarleyBreakGame.this.refreshArea();
			}
		});
		GridLayout.LayoutParams lp = new GridLayout.LayoutParams();
		lp.rowSpec = GridLayout.spec(0);
		lp.columnSpec = GridLayout.spec(0, AREA_WIDTH);
		lp.setGravity(Gravity.FILL);
		_refreshButton.setLayoutParams(lp);
		
		_gridLayout.addView(_refreshButton);
	}
	
	@Override
	public GridLayout getGridLayout()
	{
		return _gridLayout;
	}
	
	public void refreshArea()
	{
		Random rand = new Random();
		ArrayList<BarleyBreakButton> prevArea = _area;
		_area = new ArrayList<>();
		for (BarleyBreakButton btn : prevArea)
		{
			while (true)
			{
				int x = rand.nextInt(AREA_WIDTH);
				int y = rand.nextInt(AREA_HEIGHT);
				Point tmpPoint = new Point(x, y);
				if (isPointEmpty(tmpPoint))
				{
					btn.setPoint(tmpPoint);
					_area.add(btn);
					break;
				}
			}
		}
		prevArea.clear();
	}
	
	@Override
	public void onClick(View view)
	{
		BarleyBreakButton clickedButton = (BarleyBreakButton) view;
		Point emptyPoint = getEmptyPointAroundButton(clickedButton);
		if (emptyPoint != null)
		{
			Log.d("----", emptyPoint.toString());
			clickedButton.setPoint(emptyPoint);
		}
	}
	
	private Point getEmptyPointAroundButton(BarleyBreakButton btn)
	{
		Point btnPoint = btn.getPoint();
		if (btnPoint.getX() > 0)
		{
			Point leftPoint = new Point(btnPoint.getX() - 1, btnPoint.getY());
			if (isPointEmpty(leftPoint))
			{
				return leftPoint;
			}
		}
		if (btnPoint.getY() > 0)
		{
			Point topPoint = new Point(btnPoint.getX(), btnPoint.getY() - 1);
			if (isPointEmpty(topPoint))
			{
				return topPoint;
			}
		}
		if (btnPoint.getX() < AREA_WIDTH - 1)
		{
			Point rightPoint = new Point(btnPoint.getX() + 1, btnPoint.getY());
			if (isPointEmpty(rightPoint))
			{
				return rightPoint;
			}
		}
		if (btnPoint.getY() < AREA_HEIGHT - 1)
		{
			Point bottomPoint = new Point(btnPoint.getX(), btnPoint.getY() + 1);
			if (isPointEmpty(bottomPoint))
			{
				return bottomPoint;
			}
		}
		return null;
	}
	
	private boolean isPointEmpty(Point point)
	{
		for (BarleyBreakButton btn : _area)
		{
			if (btn.getPoint().equals(point))
			{
				return false;
			}
		}
		return true;
	}
	
	@Override
	public void save(Bundle state)
	{
		String buttons = "";
		for (BarleyBreakButton btn : _area)
		{
			Point point = btn.getPoint();
			String txt = btn.getText().toString();
			String format = point.serialize() + "|" + txt;
			buttons += "&" + format;
		}
		state.putString("barleyBreakArea", buttons);
	}
	
	@Override
	public void restore(Bundle state)
	{
		String buttons = state.getString("barleyBreakArea", "");
		String[] parts1 = buttons.split("&");
		for (String p : parts1)
		{
			if (p.isEmpty()) continue;
			String[] parts2 = p.split("\\|");
			String pointStr = parts2[0];
			String txt = parts2[1];
			Point point = Point.deserialize(pointStr);
			for (BarleyBreakButton btn : _area)
			{
				if (btn.getText().toString().contentEquals(txt))
				{
					btn.setPoint(point);
					break;
				}
			}
		}
	}
}

class BarleyBreakButton extends android.support.v7.widget.AppCompatButton
{
	private Point _point;
	private int _verticalOffset = 0;
	
	public BarleyBreakButton(Context context, Point point, int verticalOffset)
	{
		super(context);
		
		_point = point;
		_verticalOffset = verticalOffset;
		
		GridLayout.LayoutParams btnLayoutParams = new GridLayout.LayoutParams();
		btnLayoutParams.columnSpec = GridLayout.spec(point.getX());
		btnLayoutParams.rowSpec = GridLayout.spec(point.getY() + _verticalOffset);
		setLayoutParams(btnLayoutParams);
	}
	
	public Point getPoint()
	{
		return _point;
	}
	
	public void setPoint(Point point)
	{
		_point = point;
		
		GridLayout.LayoutParams lp = (GridLayout.LayoutParams) getLayoutParams();
		lp.columnSpec = GridLayout.spec(point.getX());
		lp.rowSpec = GridLayout.spec(point.getY() + _verticalOffset);
		setLayoutParams(lp);
	}
}

class Point
{
	private int _x;
	private int _y;
	
	public Point(int x, int y)
	{
		_x = x;
		_y = y;
	}
	
	public int getX()
	{
		return _x;
	}
	
	public int getY()
	{
		return _y;
	}
	
	@Override
	public String toString()
	{
		return "X: " + _x + ", Y: " + _y;
	}
	
	@Override
	public boolean equals(Object obj)
	{
		if (obj == null) return false;
		if (obj == this) return true;
		if (!(obj instanceof Point)) return false;
		Point point = (Point) obj;
		return point._x == _x && point._y == _y;
	}
	
	public String serialize()
	{
		return _x + ";" + _y;
	}
	
	public static Point deserialize(String str)
	{
		String[] parts = str.split(";");
		int x = Integer.valueOf(parts[0]);
		int y = Integer.valueOf(parts[1]);
		return new Point(x, y);
	}
}
