package com.vstrizhakov.bitcoinservice;

import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.content.Context;
import android.os.Build;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

public class MainActivity extends AppCompatActivity
{
	final static public String CHANNEL_ID = "BitcoinServiceId";
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		if (Build.VERSION.SDK_INT >= 26)
		{
			NotificationManager notificationManager = (NotificationManager)getSystemService(Context.NOTIFICATION_SERVICE);
			String name = "Bitcoin Cost Notification Channel";
			String description = "Bitcoin Cost Notification Channel";
			int importance = NotificationManager.IMPORTANCE_MIN;
			
			NotificationChannel channel = new NotificationChannel(MainActivity.CHANNEL_ID, name, importance);
			channel.setDescription(description);
			notificationManager.createNotificationChannel(channel);
		}
	}
}
