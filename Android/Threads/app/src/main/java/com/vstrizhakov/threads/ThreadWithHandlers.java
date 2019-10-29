package com.vstrizhakov.threads;

import android.os.Handler;
import android.os.Message;


public class ThreadWithHandlers extends Thread
{
	private Handler _handler;
	private int _what;
	
	public ThreadWithHandlers(Handler handler, int what)
	{
		_handler = handler;
		_what = what;
	}
	
	@Override
	public void run()
	{
		int width = 200;
		int height = 100;
		boolean isForward = true;
		try
		{
			while (true)
			{
				Thread.sleep(20);
				if (isForward)
				{
					width++;
					height++;
					if (width > 400)
					{
						isForward = false;
					}
				}
				else
				{
					width--;
					height--;
					if (width < 200)
					{
						isForward = true;
					}
				}
				Message message = Message.obtain();
				message.arg1 = width;
				message.arg2 = height;
				message.what = _what;
				_handler.sendMessage(message);
				
			}
		}
		catch (InterruptedException ie)
		{
		
		}
	}
}
