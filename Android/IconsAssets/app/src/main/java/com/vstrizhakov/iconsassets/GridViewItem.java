package com.vstrizhakov.iconsassets;

import android.graphics.Bitmap;

public class GridViewItem
{
	public Bitmap _bmp;
	
	public String _title;
	
	public GridViewItem(Bitmap bmp, String title)
	{
		_bmp = bmp;
		_title = title;
	}
	
	@Override
	public String toString()
	{
		return _title;
	}
}
