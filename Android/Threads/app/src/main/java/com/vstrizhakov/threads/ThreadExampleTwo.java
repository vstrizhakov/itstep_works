package com.vstrizhakov.threads;

import android.util.Log;
import android.widget.TextView;

public class ThreadExampleTwo extends Thread
{
	private final static String TAG = "===ThreadExampleTwo";
	private String _message;
	private TextView _tvInfo;
	private MainActivity _activity;
	
	public ThreadExampleTwo(String message)
	{
		_message = message;
	}
	
	public void setTextView(TextView tvInfo, MainActivity activity)
	{
		_tvInfo = tvInfo;
		_activity = activity;
	}
	
	@Override
	public void run()
	{
		try
		{
			int count = 0;
			while (true)
			{
				Thread.sleep(750);
				count++;
				final String str = _message + " #" + count + " (" + Thread.currentThread().getName() + ")";
				Log.d(TAG, "run: " + str);
				_activity.runOnUiThread(new Runnable()
				{
					@Override
					public void run()
					{
						_tvInfo.setText(str);
					}
				});
			}
		}
		catch (InterruptedException ie)
		{
			Log.d(TAG, "run: Thread was interrupted");
		}
	}
}
