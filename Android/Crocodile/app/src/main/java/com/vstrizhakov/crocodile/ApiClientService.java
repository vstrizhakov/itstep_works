package com.vstrizhakov.crocodile;

import android.app.Service;
import android.content.Intent;
import android.os.IBinder;
import android.os.RemoteException;
import android.support.annotation.Nullable;
import android.util.Log;

import com.vstrizhakov.crocodile.Api.ApiClient;
import com.vstrizhakov.crocodile.Api.Notification;
import com.vstrizhakov.crocodile.Api.Package;
import com.vstrizhakov.crocodile.Api.Request;
import com.vstrizhakov.crocodile.Helpers.LogHelper;
import com.vstrizhakov.crocodile.Network.INetworkConnectionListener;

import java.io.UnsupportedEncodingException;
import java.net.UnknownHostException;
import java.nio.charset.StandardCharsets;

public class ApiClientService extends Service implements INetworkConnectionListener
{
	//region Constants
	
	final static public String NAME = "ApiClientService";
	final static public String NOTIFICATION_EXTRA = "Notification";
	
	//endregion
	
	//region Private Fields
	
	private ApiClient _apiClient;
	
	//endregion
	
	//region Life Cycle
	
	public ApiClientService()
	{
	
	}
	
	@Override
	public void onCreate()
	{
		super.onCreate();

		LogHelper.log(this, "onCreate");

		_apiClient = ApiClient.getInstance();
		_apiClient.setNetworkListener(this);

		String host = "91.195.90.132";
		int port = 12722;

//		String host = "192.168.0.109";
//		int port = 25565;

		_apiClient.initialize(host, port);
		_apiClient.start();
		LogHelper.log(this, "onCreate: created on " + host + ":" + port);
	}
	
	@Nullable
	@Override
	public IBinder onBind(Intent intent)
	{
		return new IServiceUpdater.Stub()
		{
			@Override
			public void Update(String message)
			{
				_apiClient.sendMessage(message);
			}
		};
	}
	
	@Override
	public int onStartCommand(Intent intent, int flags, int startId)
	{
		LogHelper.log(this, "onStartCommand");
		return START_STICKY;
	}
	
	@Override
	public void onDestroy()
	{
		super.onDestroy();
		LogHelper.log(this, "onDestroy");
		_apiClient.interrupt();
	}
	
	//endregion
	
	//region Callbacks
	
	@Override
	public void onNetworkDataReceived(byte[] data)
	{
		try
		{
			String receivedString = new String(data, StandardCharsets.UTF_8);
			LogHelper.log(this, "onNetworkDataReceived: message received: " + receivedString);
			Package pkg = Package.fromString(receivedString);
			if (pkg.getType().contentEquals(Constants.Protocol.Type.NOTIFICATION))
			{
				Notification notification = Notification.fromPackage(pkg);
				Intent messageIntent = new Intent(ApiClientService.NAME);
				messageIntent.putExtra(ApiClientService.NOTIFICATION_EXTRA, notification.toString());
				sendBroadcast(messageIntent);
			}
			else
			{
				throw new AssertionError("Package type isn't notification");
			}
		}
		catch (Exception exception)
		{
			LogHelper.log(this, "onNetworkDataReceived: " + exception.getMessage());
		}
	}
	
	@Override
	public void onNetworkConnectionLost()
	{
		LogHelper.log(this, "onConnectionLost: ");
	}
	
	//endregion
}
