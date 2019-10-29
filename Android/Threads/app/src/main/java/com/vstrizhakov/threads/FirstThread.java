package com.vstrizhakov.threads;

import android.util.Log;

public class FirstThread extends Thread
{
	private String _message;
	
	public FirstThread(String message)
	{
		_message = message;
	}
	
	@Override
	public void run()
	{
		try
		{
			while (true)
			{
				Thread.sleep(750);
				Log.d("===", _message + " (" + Thread.currentThread().getName() + ")");
			}
		}
		catch (InterruptedException ie)
		{
			Log.d("===", "Thread wsa interrupted");
		}
	}
}
