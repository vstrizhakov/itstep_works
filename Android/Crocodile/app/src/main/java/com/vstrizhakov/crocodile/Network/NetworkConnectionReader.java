package com.vstrizhakov.crocodile.Network;

import android.util.Log;

import com.vstrizhakov.crocodile.Helpers.LogHelper;

import java.io.IOException;
import java.net.Socket;

public class NetworkConnectionReader extends NetworkConnection implements Runnable
{
	private INetworkConnectionListener _listener;
	
	public NetworkConnectionReader()
	{
		super();
	}

	public void setNetworkListener(INetworkConnectionListener listener)
	{
		_listener = listener;
	}
	
	@Override
	public void run()
	{
		try
		{
			while (true)
			{
				Thread.sleep(0);
				byte[] receivedMessage = readMessage();
				notify(receivedMessage);
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
	
	public void notify(byte[] message)
	{
		LogHelper.log(this, "notify: " + message.length);
		if (_listener != null)
		{
			_listener.onNetworkDataReceived(message);
		}
	}
}
