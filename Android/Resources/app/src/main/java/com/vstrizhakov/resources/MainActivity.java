package com.vstrizhakov.resources;

import android.content.res.Resources;
import android.graphics.Bitmap;
import android.graphics.drawable.BitmapDrawable;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.ImageView;

public class MainActivity extends AppCompatActivity
{
	private boolean _isAllDisable = false;
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		Resources resources = getResources();
		BitmapDrawable drawable = (BitmapDrawable)resources.getDrawable(R.drawable.abc);
		Bitmap bmp = drawable.getBitmap();
		ImageView ivTwo = findViewById(R.id.ivTwo);
		ivTwo.setImageBitmap(bmp);
	}
	
	public void btnClick(View view)
	{
		Button btn1 = findViewById(R.id.btn1);
		EditText edt1 = findViewById(R.id.edt1);
		EditText edt2 = findViewById(R.id.edt2);
		CheckBox cb1 = findViewById(R.id.cb1);
		CheckBox cb2 = findViewById(R.id.cb2);
		
		_isAllDisable = !_isAllDisable;
		btn1.setEnabled(_isAllDisable);
		edt1.setEnabled(_isAllDisable);
		edt2.setEnabled(_isAllDisable);
		cb1.setEnabled(_isAllDisable);
		cb2.setEnabled(_isAllDisable);
	}
}
