package com.vstrizhakov.alertdialog_;

import android.Manifest;
import android.content.DialogInterface;
import android.graphics.Color;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.LinearLayout;

public class MainActivity extends AppCompatActivity
{
	
	private int clrForMain = Color.rgb(255, 255, 255);
	private int clrTmpMain;
	private LinearLayout llMain;
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		llMain = findViewById(R.id.llMain);
	}
	
	public void btnClickOne(View view)
	{
	
	}
	
	public void btnClickTwo(View view)
	{
		AlertDialog.Builder builder = new AlertDialog.Builder(this, android.R.style.Theme_Holo_Light_Dialog);
		builder.setTitle("Выберите цвет фона");
		builder.setSingleChoiceItems(new String[]{ "Зеленый", "Желтый", "Белый" }, -1,
				new DialogInterface.OnClickListener()
				{
					@Override
					public void onClick(DialogInterface dialog, int which)
					{
						switch (which)
						{
							case 0:
								MainActivity.this.clrTmpMain = Color.rgb(0xff, 0x00, 0x00);
								break;
							case 1:
								MainActivity.this.clrTmpMain = Color.rgb(0xff, 0xff, 0x00);
								break;
							case 2:
								MainActivity.this.clrTmpMain = Color.rgb(0x00, 0xff, 0x00);
								break;
							case 3:
								MainActivity.this.clrTmpMain = Color.rgb(0xff, 0xff, 0xff);
								break;
						}
					}
				});
		builder.setPositiveButton("OK", new DialogInterface.OnClickListener()
		{
			@Override
			public void onClick(DialogInterface dialog, int which)
			{
				MainActivity.this.clrForMain = MainActivity.this.clrTmpMain;
				MainActivity.this.llMain.setBackgroundColor(MainActivity.this.clrForMain);
			}
		});
		builder.setNegativeButton("Cancel", new DialogInterface.OnClickListener()
		{
			@Override
			public void onClick(DialogInterface dialog, int which)
			{
				MainActivity.this.llMain.setBackgroundColor(MainActivity.this.clrForMain);
			}
		});
		AlertDialog dialog = builder.create();
		dialog.show();
	}
}
