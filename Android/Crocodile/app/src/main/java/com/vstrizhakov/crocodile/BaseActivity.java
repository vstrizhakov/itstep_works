package com.vstrizhakov.crocodile;

import android.Manifest;
import android.content.BroadcastReceiver;
import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.ServiceConnection;
import android.os.Bundle;
import android.os.IBinder;
import android.os.RemoteException;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AppCompatActivity;
import android.view.View;

import com.vstrizhakov.crocodile.Api.Notification;
import com.vstrizhakov.crocodile.Api.Package;
import com.vstrizhakov.crocodile.Api.Request;
import com.vstrizhakov.crocodile.Helpers.LogHelper;
import com.vstrizhakov.crocodile.Network.INotificationListener;

import java.util.ArrayList;
import java.util.HashMap;

public abstract class BaseActivity extends AppCompatActivity
{
	private View _decorView;
	
	protected BroadcastReceiver _receiver;
	protected ServiceConnection _serviceConnection;
	
	private HashMap<String, ArrayList<INotificationListener>> _listeners;
	protected IServiceUpdater _serviceUpdater = null;
	public BaseActivity()
	{
		_listeners = new HashMap<>();
		_serviceConnection = new ServiceConnection()
		{
			@Override
			public void onServiceConnected(ComponentName name, IBinder service)
			{
				LogHelper.log(this, "onServiceConnected");
				_serviceUpdater = IServiceUpdater.Stub.asInterface(service);
				BaseActivity.this.onServiceConnected();
			}

			@Override
			public void onServiceDisconnected(ComponentName name)
			{
				_serviceUpdater = null;
				BaseActivity.this.onServiceDisconnected();
				LogHelper.log(this, "onServiceDisconnected");
			}
		};
	}

	protected void onServiceConnected()
	{

	}

	protected void onServiceDisconnected()
	{

	}
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);

		_decorView = getWindow().getDecorView();
		_decorView.setBackground(ContextCompat.getDrawable(getApplicationContext(), R.drawable.background_empty));

		ActivityCompat.requestPermissions(this,
                                          new String[]
                                                  {
                                                          Manifest.permission.WRITE_EXTERNAL_STORAGE,
                                                          Manifest.permission.READ_EXTERNAL_STORAGE,
                                                  },
                                          1);
	}

	@Override
	public void onRequestPermissionsResult(int requestCode, String[] permissions, int[] grantResults)
	{
		_receiver = new BroadcastReceiver()
		{
			@Override
			public void onReceive(Context context, Intent intent)
			{
				if (intent.getAction().contentEquals(ApiClientService.NAME))
				{
					String notificationExtraString = intent.getStringExtra(ApiClientService.NOTIFICATION_EXTRA);
					Notification notification = null;
					try
					{
						notification = Notification.fromPackage(Package.fromString(notificationExtraString));
					}
					catch (Exception ex) { }
					if (notification != null)
					{
						notifyAboutNotification(notification);
					}
				}
			}
		};
		IntentFilter filter = new IntentFilter();
		filter.addAction(ApiClientService.NAME);
		registerReceiver(_receiver, filter);
		bindService(new Intent(this, ApiClientService.class), _serviceConnection, BIND_AUTO_CREATE);
	}
	
	@Override
	protected void onDestroy()
	{
		super.onDestroy();
		if (_receiver != null)
		{
			unregisterReceiver(_receiver);
		}
		if (_serviceConnection != null)
		{
			unbindService(_serviceConnection);
		}
	}
	
	@Override
	protected void onResume()
	{
		super.onResume();
		setFullscreenMode();
	}
	
	private void notifyAboutNotification(Notification notification)
	{
		if (_listeners.containsKey(notification.getAction()))
		{
			ArrayList<INotificationListener> listenersToNotify = _listeners.get(notification.getAction());
			for (INotificationListener listener : listenersToNotify)
			{
				listener.onPackageReceived(notification);
			}
		}
	}
	
	public void addOnPackageReceivedListener(String name, INotificationListener listener)
	{
		if (!_listeners.containsKey(name))
		{
			_listeners.put(name, new ArrayList<INotificationListener>());
		}
		ArrayList<INotificationListener> listenersByName = _listeners.get(name);
		if (!listenersByName.contains(listener))
		{
			listenersByName.add(listener);
		}
	}
	
	public void removeOnPackageReceivedListener(String name, INotificationListener listener)
	{
		if (_listeners.containsKey(name))
		{
			_listeners.get(name).remove(listener);
		}
	}
	
	public void sendMessage(Request request)
	{
		try
		{
			if (_serviceUpdater != null)
			{
				_serviceUpdater.Update(request.toString());
			}
		}
		catch (RemoteException ex) { }
	}

	private void setFullscreenMode()
	{
		if (_decorView != null)
		{
			_decorView.setSystemUiVisibility(View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY
			                                 | View.SYSTEM_UI_FLAG_FULLSCREEN
			                                 | View.SYSTEM_UI_FLAG_HIDE_NAVIGATION
			                                 | View.SYSTEM_UI_FLAG_LAYOUT_STABLE
			                                 | View.SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN
			                                 | View.SYSTEM_UI_FLAG_LAYOUT_HIDE_NAVIGATION);
		}
	}
}
