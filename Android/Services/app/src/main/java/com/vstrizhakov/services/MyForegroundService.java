package com.vstrizhakov.services;

import android.app.Notification;
import android.app.PendingIntent;
import android.app.Service;
import android.content.Intent;
import android.os.IBinder;
import android.support.v4.app.NotificationCompat;

public class MyForegroundService extends Service
{
	final static private String TAG = "===";
	final static private int NOTIFICATION_ID = 321;
	
	private MyTimeServiceThread _thread;
	
	@Override
	public void onCreate()
	{
		super.onCreate();
		
		NotificationCompat.Builder builder = new NotificationCompat.Builder(this, MainActivity.CHANNEL_ID);
		builder.setSmallIcon(android.R.drawable.ic_notification_overlay)
				.setContentTitle("Service notification")
				.setContentText("The foreground service is running");
		
		Intent resultIntent = new Intent(this, MainActivity.class);
		PendingIntent pendingIntent = PendingIntent.getActivity(this, 0, resultIntent, PendingIntent.FLAG_UPDATE_CURRENT);
		builder.setContentIntent(pendingIntent);
		
		Notification notification = builder.build();
		startForeground(NOTIFICATION_ID, notification);
		
		_thread = new MyTimeServiceThread();
		_thread.start();
	}
	
	@Override
	public void onDestroy()
	{
		super.onDestroy();
		_thread.interrupt();
	}
	
	@Override
	public int onStartCommand(Intent intent, int flags, int startId)
	{
		return Service.START_NOT_STICKY;
	}
	
	@Override
	public IBinder onBind(Intent intent)
	{
		return  null;
	}
}
