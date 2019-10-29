package com.vstrizhakov.crocodile.Api;

import android.util.Log;

import com.google.gson.Gson;
import com.vstrizhakov.crocodile.Constants;
import com.vstrizhakov.crocodile.Helpers.LogHelper;
import com.vstrizhakov.crocodile.Network.INetworkConnectionListener;
import com.vstrizhakov.crocodile.Network.INotificationListener;
import com.vstrizhakov.crocodile.Network.NetworkConnectionReader;
import com.vstrizhakov.crocodile.Network.NetworkConnectionWriter;

import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.InetAddress;
import java.net.InetSocketAddress;
import java.net.Socket;
import java.net.UnknownHostException;
import java.nio.charset.StandardCharsets;
import java.util.ArrayList;
import java.util.HashMap;

public class ApiClient extends Thread /* implements INetworkConnectionListener */
{
	static private ApiClient _instance;
	
	static public ApiClient getInstance()
	{
		if (_instance == null)
		{
			_instance = new ApiClient();
		}
		return _instance;
	}

	private String _host;
	private int _port;
	private NetworkConnectionWriter _writer;
	private NetworkConnectionReader _reader;
	private Thread _writerThread;
	private Thread _readerThread;
	private INetworkConnectionListener _networkListener;
	private Socket _socket;
	
	private ApiClient()
	{
		_socket = new Socket();
		_reader = new NetworkConnectionReader();
		_writer = new NetworkConnectionWriter();
	}

	public void setNetworkListener(INetworkConnectionListener listener)
	{
		_networkListener = listener;
		_reader.setNetworkListener(_networkListener);
		_writer.setNetworkListener(_networkListener);
	}

	public void initialize(String host, int port)
	{
		_host = host;
		_port = port;
	}

	public boolean tryConnect()
	{
		LogHelper.log(this, "tryConnect: trying to connect to the server " + _host + ":" + _port);
		try
		{
			InetAddress[] addresses = InetAddress.getAllByName(_host);
			if (addresses.length <= 0)
			{
				throw new UnknownHostException(_host);
			}

			_socket.connect(new InetSocketAddress(addresses[0], _port), 5000);
		}
		catch (UnknownHostException unknownHostException)
		{
			LogHelper.log(this, "tryConnect: unresolved host - " + unknownHostException.getMessage());
		}
		catch (IOException ioexception)
		{
			LogHelper.log(this, "tryConnect: IO-error " + ioexception.getClass() + " " + ioexception.getMessage());
		}
		return _socket.isConnected();
	}

	public void run()
	{
		boolean isConnected = tryConnect();
		if (isConnected)
		{
			try
			{
				_reader.initialize(_socket);
				_writer.initialize(_socket);
			}
			catch (IOException IOException)
			{
				LogHelper.log(this, "ApiClient constructor: IO-error: " + IOException.getMessage());
			}

			_readerThread = new Thread(_reader);
			_readerThread.start();

			_writerThread = new Thread(_writer);
			_writerThread.start();
		}
		else
		{
			LogHelper.log(this, "run: socket isn't connected to the server");
		}
	}
	
	public void sendMessage(String message)
	{
		LogHelper.log(this, "sendMessage (to the server): " + message);
		byte[] messageBytes = message.getBytes(StandardCharsets.UTF_8);
		_writer.sendMessage(messageBytes);
	}
	
//	@Override
//	public void onNetworkDataReceived(byte[] data)
//	{
//		try
//		{
//			String receivedString = new String(data, StandardCharsets.UTF_8);
//			Package pkg = Package.fromString(receivedString);
//			if (pkg.getType().contentEquals(Constants.Protocol.Type.NOTIFICATION))
//			{
//				Notification notification = Notification.fromPackage(pkg);
//				notify(notification);
//			}
//			else
//			{
//				throw new AssertionError("Package type isn't notification");
//			}
//		}
//		catch (UnsupportedEncodingException encodingException)
//		{
//
//		}
//		catch (Exception exception)
//		{
//			Log.d(TAG, "onNetworkDataReceived: " + exception.getMessage());
//		}
//	}
//
//	@Override
//	public void onNetworkConnectionLost()
//	{
//		Log.d("ApiClient", "onConnectionLost: ");
//	}
}
