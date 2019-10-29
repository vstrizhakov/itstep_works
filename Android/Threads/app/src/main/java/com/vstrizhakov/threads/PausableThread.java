package com.vstrizhakov.threads;

import android.app.Activity;
import android.util.Log;
import android.widget.TextView;

public class PausableThread extends Thread
{
	private final static String TAG = "===PausableThread";
	private Activity _activity;
	private TextView _textView;
	private boolean _isPause = false;
	
	public synchronized void suspendWork()
	{
		_isPause = true;
	}
	
	public synchronized void resumeWork()
	{
		_isPause = false;
		notify();
	}
	
	private synchronized void checkPause() throws InterruptedException
	{
		while (_isPause)
		{
			wait();
		}
	}
	
	public void updateSettings(Activity activity, int textViewId)
	{
		_activity = activity;
		_textView = _activity.findViewById(textViewId);
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
				checkPause();
				count++;
				final String str = getName() + ", cnt = " + count;
				Log.d(TAG, "run: " + str);
				_activity.runOnUiThread(new Runnable()
				{
					@Override
					public void run()
					{
						_textView.setText(str);
					}
				});
			}
		}
		catch (InterruptedException ie)
		{
		
		}
	}
}
