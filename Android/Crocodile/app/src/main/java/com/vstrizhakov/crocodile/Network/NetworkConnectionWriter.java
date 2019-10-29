package com.vstrizhakov.crocodile.Network;

import android.util.Log;

import java.io.IOException;
import java.net.Socket;
import java.util.ArrayList;
import java.util.concurrent.Semaphore;

public class NetworkConnectionWriter extends NetworkConnection implements Runnable
{
	private INetworkConnectionListener _listener;
	private ArrayList<byte[]> _messages;
	private Semaphore _semaphore;
	private boolean _isLocked;
	
	public NetworkConnectionWriter()
	{
		super();
		_messages = new ArrayList<>();
		_semaphore = new Semaphore(1, true);
		try
		{
			_semaphore.acquire();
		}
		catch (Exception ex){}
	}

	public void setNetworkListener(INetworkConnectionListener listener)
	{
		_listener = listener;
	}

	public void sendMessage(byte[] message)
	{
		_messages.add(message);
		if (_isLocked)
		{
			_semaphore.release();
		}
	}
	
	@Override
	public void run()
	{
		try
		{
			while (true)
			{
				if (_messages.size() == 0)
				{
					_isLocked = true;
					_semaphore.acquire();
					_isLocked = false;
				}
				
				byte[] messageToSend = _messages.get(0);
				_messages.remove(messageToSend);
				writeMessage(messageToSend);
			}
		}
		catch (InterruptedException interruptedException)
		{
			Log.d("ApiClient", "run: interrupted " );
		}
		catch (IOException ioExcepetion)
		{
			if (_listener != null)
			{
				_listener.onNetworkConnectionLost();
			}
		}
		close();
	}
}
