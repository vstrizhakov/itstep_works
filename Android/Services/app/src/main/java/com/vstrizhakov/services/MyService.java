package com.vstrizhakov.services;

import android.app.IntentService;
import android.app.Service;
import android.content.Intent;
import android.os.IBinder;
import android.util.Log;

import java.util.ArrayList;

public class MyService extends Service
{
	private final static String TAG = "===";
	private final static ArrayList<Thread> _threads = new ArrayList<>();
	
	@Override
	public IBinder onBind(Intent intent){
		return  null; // Not bind service
	}
	
	@Override
	public void onCreate()
	{
		super.onCreate();
		Log.d(TAG, "onCreate: ");
	}
	
	@Override
	public void onDestroy()
	{
		super.onDestroy();
		for (Thread thread : _threads)
		{
			thread.interrupt();
		}
		_threads.clear();
		Log.d(TAG, "onDestroy: ");
	}
	
	@Override
	public int onStartCommand(Intent intent, int flags, int startId)
	{
		Log.d(TAG, "onStartCommand: " + startId);
		
		final int sId = startId;
		
		Thread T = new Thread(new Runnable()
		{
			@Override
			public void run()
			{
				try
				{
					for (int i = 0; i < 10; i++)
					{
						Log.d(TAG, "run: (" + sId + ") i = " + i);
						Thread.sleep(1000);
					}
				}
				catch (InterruptedException exception)
				{
				
				}
				stopSelfResult(sId);
				_threads.remove(this);
			}
		});
		T.start();
		_threads.add(T);
		return  Service.START_NOT_STICKY;
	}
}
