package com.vstrizhakov.widgets;

import android.app.Activity;
import android.appwidget.AppWidgetManager;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.RadioButton;

public class ConfigActivity extends AppCompatActivity
{
	final private static String TAG = "===";
	final public static String APP_SHARED_PREFERENCES = "AppSharedPreferences";
	final public static String PREFERRED_WIDGET_COLOR = "PreferredWidgetColor";
	final public static int[] WidgetColors =
			{
					Color.rgb(0x00, 0x33, 0x66),
					Color.rgb(0x00, 0x89, 0x7b),
					Color.rgb(0xfb, 0x8c, 0x00),
					Color.rgb(0xd8, 0x60, 0x60),
			};
	final public static int[] ImageIds =
			{
					R.drawable.emoticon_tongue_outline,
					R.drawable.teal,
					R.drawable.orange,
					R.drawable.pink
			};
	
	private int _widgetId;
	private RadioButton[] _radioButtons;
	private int _selectedRadioButtonIndex = 0;
	private Intent _resultValue;
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_config);
		
		Intent intent = getIntent();
		Bundle extras = intent.getExtras();
		_widgetId = AppWidgetManager.INVALID_APPWIDGET_ID;
		if (extras != null)
		{
			_widgetId = extras.getInt(AppWidgetManager.EXTRA_APPWIDGET_ID, AppWidgetManager.INVALID_APPWIDGET_ID);
			Log.d(TAG, "onCreate: " + _widgetId);
		}
		
		if (_widgetId == AppWidgetManager.INVALID_APPWIDGET_ID)
		{
			finish();
		}
		
		_radioButtons = new RadioButton[4];
		_radioButtons[0] = findViewById(R.id.radio_indigo);
		_radioButtons[1] = findViewById(R.id.radio_orange);
		_radioButtons[2] = findViewById(R.id.radio_pink);
		_radioButtons[3] = findViewById(R.id.radio_teal);
		
		_resultValue = new Intent();
		_resultValue.putExtra(AppWidgetManager.EXTRA_APPWIDGET_ID, _widgetId);
		
		setResult(Activity.RESULT_CANCELED, _resultValue);
		
		
	}
	
	public void btnCancel(View view)
	{
		finish();
	}
	
	public void btnApply(View view)
	{
		SharedPreferences preferences = getSharedPreferences(APP_SHARED_PREFERENCES, Context.MODE_PRIVATE);
		SharedPreferences.Editor editor = preferences.edit();
		editor.putInt(PREFERRED_WIDGET_COLOR, _selectedRadioButtonIndex);
		editor.commit();
		
		setResult(Activity.RESULT_OK, _resultValue);
		finish();
	}
	
	public void checkChanged(View view)
	{
		for (int i = 0; i < _radioButtons.length; i++)
		{
			RadioButton radio = _radioButtons[i];
			if (radio != view)
			{
				radio.setChecked(false);
			}
			else
			{
				_selectedRadioButtonIndex = i;
			}
		}
	}
}
