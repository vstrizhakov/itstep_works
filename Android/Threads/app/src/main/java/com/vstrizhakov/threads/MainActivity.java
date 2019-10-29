package com.vstrizhakov.threads;

import android.app.Activity;
import android.content.pm.ActivityInfo;
import android.content.res.Configuration;
import android.os.Handler;
import android.os.Message;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.widget.Button;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity
{
	private static FirstThread _firstThread = null;
	private static ThreadExampleTwo _secondThread = null;
	private static PausableThread _thirdThread = null;
	private static Activity _activity;
	private static Handler _handler;
	private static ThreadWithHandlers _firstHandledThread;
	private static ThreadWithHandlers _secondHandledThread;
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		if (_firstThread == null)
		{
			_firstThread = new FirstThread("Ivan loh");
			//_firstThread.start();
		}
		
		if (_secondThread == null)
		{
			_secondThread = new ThreadExampleTwo("SOS");
			//_secondThread.start();
		}
		_secondThread.setTextView((TextView)findViewById(R.id.tvInfo), this);
	
		if (_thirdThread == null)
		{
			_thirdThread = new PausableThread();
			_thirdThread.updateSettings(this, R.id.tvInfo);
			//_thirdThread.start();
		}
		else
		{
			_thirdThread.updateSettings(this, R.id.tvInfo);
		}
		
		_activity = this;
		if (_handler == null)
		{
			_handler = new Handler()
			{
				@Override
				public void handleMessage(Message message)
				{
					Button btn = MainActivity._activity.findViewById((message.what));
					if (btn != null)
					{
						btn.setWidth(message.arg1);
						btn.setHeight(message.arg2);
					}
				}
			};
		}
		
		if (_firstHandledThread == null)
		{
			_firstHandledThread = new ThreadWithHandlers(_handler, R.id.btn1);
			_firstHandledThread.start();
		}
		
		if (_secondHandledThread == null)
		{
			_secondHandledThread = new ThreadWithHandlers(_handler, R.id.btn2);
			_secondHandledThread.start();
		}
	}
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.main_menu, menu);
		return true;
	}
	
	@Override
	public boolean onOptionsItemSelected(MenuItem item)
	{
		switch (item.getItemId())
		{
			case R.id.rotate_menu_item:
			{
				if (getResources().getConfiguration().orientation == Configuration.ORIENTATION_PORTRAIT)
				{
					setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE);
				}
				else if (getResources().getConfiguration().orientation == Configuration.ORIENTATION_LANDSCAPE)
				{
					setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_PORTRAIT);
				}
				break;
			}
		}
		return true;
	}
	
	@Override
	public void onResume()
	{
		super.onResume();
		if (_thirdThread != null)
		{
			_thirdThread.resumeWork();
		}
	}
	
	@Override
	public void onPause()
	{
		super.onPause();
		if (_thirdThread != null)
		{
			_thirdThread.suspendWork();
		}
	}
}
