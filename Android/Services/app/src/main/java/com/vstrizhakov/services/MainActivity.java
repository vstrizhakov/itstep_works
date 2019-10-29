package com.vstrizhakov.services;

import android.annotation.TargetApi;
import android.app.Activity;
import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.os.Build;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Toast;

@TargetApi(26)
public class MainActivity extends AppCompatActivity
{
	final static private String TAG = "===";
	
	final static public int TIME_REQUEST_CODE = 777;
	final static public	 String KEY_PENDING_INTENT = "keyPendingIntent";
	final static public String CHANNEL_ID = "MyNoteId";
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		NotificationManager notificationManager = (NotificationManager)getSystemService(Context.NOTIFICATION_SERVICE);
		
		if (Build.VERSION.SDK_INT >= 26)
		{
			String name = "MyNotificationChannel";
			String description = "My Channel Description";
			int importance = NotificationManager.IMPORTANCE_DEFAULT;
			
			NotificationChannel channel = new NotificationChannel(CHANNEL_ID, name, importance);
			notificationManager.createNotificationChannel(channel);
		}
	}
	
	public void btnStartService(View v)
	{
		startService(new Intent(this, MyService.class));
	}
	
	public void btnStopService(View v)
	{
		stopService(new Intent(this, MyService.class));
	}
	
	public void btnStartTimeService(View v)
	{
		Intent intent = new Intent(this, MyTimeService.class);
		PendingIntent pendingIntent = createPendingResult(TIME_REQUEST_CODE, new Intent(), 0);
		intent.putExtra(KEY_PENDING_INTENT, pendingIntent);
		startService(intent);
	}
	
	public void btnStopTimeService(View v)
	{
		stopService(new Intent(this, MyTimeService.class));
	}
	
	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data)
	{
		if (resultCode == Activity.RESULT_OK
			&& requestCode == TIME_REQUEST_CODE)
		{
			String currentTime = data.getStringExtra(MyTimeService.KEY_CURRENT_TIME);
			String resultString = "Current time: " + currentTime;
			Log.d(TAG, "onActivityResult: " + resultString);
			Toast.makeText(this, resultString, Toast.LENGTH_LONG).show();
		}
	}
	
	public void btnStopForegroundService(View view)
	{
		stopService(new Intent(this, MyForegroundService.class));
	}
	
	public void btnStartForegroundService(View view)
	{
		startForegroundService(new Intent(this, MyForegroundService.class));
	}
}
