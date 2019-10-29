package com.vstrizhakov.services;

import android.app.Activity;
import android.app.PendingIntent;
import android.app.Service;
import android.content.Intent;
import android.os.IBinder;
import android.support.annotation.Nullable;
import android.util.Log;

public class MyTimeService extends Service
{
	final private static String TAG = "===";
	
	final static public String KEY_CURRENT_TIME = "keyCurrentTime";
	
	private MyTimeServiceThread _thread;
	
	@Nullable
	@Override
	public IBinder onBind(Intent intent)
	{
		return null;
	}
	
	public void onCreate()
	{
		super.onCreate();
		
		_thread = new MyTimeServiceThread();
		_thread.start();
		
		Log.d(TAG, "onCreate: ");
	}
	
	public void onDestroy()
	{
		super.onDestroy();
		Log.d(TAG, "onDestroy: ");
		
		_thread.interrupt();
	}
	
	public int onStartCommand(Intent intent, int flags, int startId)
	{
		Log.d(TAG, "onStartCommand: ");
		
		PendingIntent pendingIntent = intent.getParcelableExtra(MainActivity.KEY_PENDING_INTENT);
		Intent newIntent = new Intent().putExtra(KEY_CURRENT_TIME, _thread.getCurrentTime());
		try
		{
			pendingIntent.send(this, Activity.RESULT_OK, newIntent);
		}
		catch (PendingIntent.CanceledException ex)
		{
		
		}
		return Service.START_NOT_STICKY;
	}
}
