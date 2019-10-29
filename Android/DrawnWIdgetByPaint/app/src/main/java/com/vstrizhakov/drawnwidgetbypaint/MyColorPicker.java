package com.vstrizhakov.drawnwidgetbypaint;

import android.animation.ValueAnimator;
import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.RectF;
import android.util.AttributeSet;
import android.util.Log;
import android.view.MotionEvent;
import android.view.View;
import android.view.animation.DecelerateInterpolator;

import java.util.ArrayList;

public class MyColorPicker extends View implements View.OnTouchListener
{
	private int _currentColor = _colors[4];
	private Paint _paint;
	private RectF _rect = new RectF();
	private float _rx, _ry;
	
	
	private static int[] _colors =
			{
				Color.BLACK,
				Color.YELLOW,
				Color.GRAY,
				Color.GREEN,
				Color.RED,
				Color.BLUE,
				Color.MAGENTA,
				Color.CYAN
			};
	
	{
		_paint = new Paint();
		_paint.setAntiAlias(true);
		setOnTouchListener(this);
	}
	
	public interface OnColorPickListener
	{
		void onColorPick(int color);
	}
	
	private ArrayList<OnColorPickListener> _listeners = new ArrayList<>();
	
	public void addOnColorPickListener(OnColorPickListener listener)
	{
		_listeners.add(listener);
	}
	
	public MyColorPicker(Context context)
	{
		super(context);
	}
	
	public MyColorPicker(Context context, AttributeSet attributeSet, int defStyleAttr)
	{
		super(context, attributeSet, defStyleAttr);
	}
	
	public MyColorPicker(Context context, AttributeSet attributeSet)
	{
		super(context, attributeSet);
	}
	
	public int getColor()
	{
		return  _currentColor;
	}
	
	@Override
	public void onDraw(Canvas canvas)
	{
		int width = getWidth() / 4;
		int height = getHeight() / 4;
		
		canvas.drawColor(Color.WHITE);
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				_rect.left = 5 + j * width;
				_rect.top = 5 + i * height;
				_rect.right = (j + 1) * width - 5;
				_rect.bottom = (i + 1) * height - 5;
				if (_currentColor == _colors[i * 4 + j])
				{
					//canvas.drawOval(_rect, _paint);
					_paint.setColor(_colors[i * 4 + j]);
					canvas.drawRoundRect( _rect, _rx,  _ry, _paint);
					_paint.setColor(Color.WHITE);
					_rect.left += 5;
					_rect.top += 5;
					_rect.right -= 5;
					_rect.bottom -= 5;
					canvas.drawRoundRect( _rect, width / 2, width / 2, _paint);
				}
				else
				{
					_paint.setColor(_colors[i * 4 + j]);
					canvas.drawRoundRect( _rect, 5, 5,_paint);
				}
			}
		}
	}
	
	@Override
	public boolean onTouch(View v, MotionEvent event)
	{
		int width = getWidth() / 4;
		int height = getHeight() / 4;
		
		int row = (int)event.getY() / height;
		int col = (int)event.getX() / width;
		if (row * 4 + col >= _colors.length)
		{
			return true;
		}
		int newColor = _colors[row * 4+ col];
		if (newColor == _currentColor)
		{
			return true;
		}
		_currentColor = newColor;
		
		ValueAnimator va1 = new ValueAnimator();
		va1.setDuration(300);
		va1.setInterpolator(new DecelerateInterpolator());
		va1.setFloatValues(0, (width - 10) / 2);
		va1.addUpdateListener(new ValueAnimator.AnimatorUpdateListener()
		{
			@Override
			public void onAnimationUpdate(ValueAnimator animation)
			{
				_rx = (float)animation.getAnimatedValue();
			}
		});
		va1.start();
		
		ValueAnimator va2 = new ValueAnimator();
		va2.setDuration(300);
		va2.setInterpolator(new DecelerateInterpolator());
		va2.setFloatValues(0, (width - 10) / 2);
		va2.addUpdateListener(new ValueAnimator.AnimatorUpdateListener()
		{
			@Override
			public void onAnimationUpdate(ValueAnimator animation)
			{
				_ry = (float)animation.getAnimatedValue();
				postInvalidate();
			}
		});
		va2.start();
		
		for (OnColorPickListener listener : _listeners)
		{
			listener.onColorPick(_currentColor);
		}
		
		return true;
	}
}
