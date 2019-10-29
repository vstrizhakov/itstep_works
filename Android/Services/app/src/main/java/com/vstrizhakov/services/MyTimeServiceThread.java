package com.vstrizhakov.services;

import android.util.Log;

import java.util.Calendar;

public class MyTimeServiceThread extends Thread
{
	@Override
	public void run()
	{
		try
		{
			while (true)
			{
				String currentTime = getCurrentTime();
				Log.d("===", "run: " + currentTime);
				Thread.sleep(500);
			}
		}
		catch (InterruptedException ex)
		{
		
		}
	}
	
	public String getCurrentTime()
	{
		Calendar calendar = Calendar.getInstance();
		int hours = calendar.get(Calendar.HOUR_OF_DAY);
		int mins = calendar.get(Calendar.MINUTE);
		int secs = calendar.get(Calendar.SECOND);
		return hours + ":" + mins + ":" + secs;
	}
}
