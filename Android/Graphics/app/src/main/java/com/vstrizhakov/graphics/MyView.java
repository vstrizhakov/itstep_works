package com.vstrizhakov.graphics;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.RectF;
import android.graphics.Typeface;
import android.graphics.drawable.BitmapDrawable;
import android.os.Build;
import android.util.AttributeSet;
import android.view.MotionEvent;
import android.view.View;

public class MyView extends View
{
	private Paint _paint;
	private Bitmap _bitmap;
	private RectF _rect = new RectF();
	
	{
		_paint = new Paint();
		_paint.setAntiAlias(true);
		_paint.setColor(Color.DKGRAY);
		
		_bitmap = BitmapFactory.decodeResource(getResources(), R.drawable.koala);
	
		setOnTouchListener(this);
	}
	
	public MyView(Context context)
	{
		super(context);
	}
	
	public MyView(Context context, AttributeSet attributeSet)
	{
		super(context, attributeSet);
	}
	
	public MyView(Context context, AttributeSet attributeSet, int defStyleAttr)
	{
		super(context, attributeSet, defStyleAttr);
	}
	
	@Override
	public void onDraw(Canvas canvas)
	{
		int width = getWidth();
		int height = getHeight();

		_rect.left = width / 2 + 20;
		_rect.top = 20;
		_rect.right = width - 20;
		_rect.bottom = height / 2 - 20;

		canvas.drawBitmap(_bitmap, null, _rect, _paint);
		
		_paint.setColor(Color.rgb(0x28, 0x35, 0x93));
		if (Build.VERSION.SDK_INT >= 21)
		{
			canvas.drawRoundRect(width / 2 + 20,  height / 2 + 20, width - 20, height - 20, 30, 50, _paint);
		}
		else
		{
			_rect.left = width / 2 + 20;
			_rect.top = 20;
			_rect.right = width - 20;
			_rect.bottom = height / 2 - 20;
			canvas.drawRoundRect(_rect, 30, 50, _paint);
		}
		
		_paint.setColor(Color.rgb(0x6a, 0x18, 0x9a));
		if (Build.VERSION.SDK_INT >= 21)
		{
			canvas.drawOval(20,  height / 2 + 20, width / 2 - 20, height - 20, _paint);
		}
		else
		{
			_rect.left = 20;
			_rect.top = height / 2 + 20;
			_rect.right = width - 20;
			_rect.bottom = height - 20;
			canvas.drawOval(_rect, _paint);
		}
		
		_paint.setColor(Color.rgb(0xFF, 0xFF, 0x00));
		Typeface typeface = Typeface.create(Typeface.MONOSPACE, Typeface.BOLD);
		_paint.setTextSize(70);
		_paint.setTypeface(typeface);
		canvas.drawText("Hello, Android!", 50, 3 * height / 4, _paint);
	}
}
