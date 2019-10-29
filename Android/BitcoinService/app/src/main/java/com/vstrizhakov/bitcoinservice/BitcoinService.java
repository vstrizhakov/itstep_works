package com.vstrizhakov.bitcoinservice;

import android.annotation.TargetApi;
import android.app.Notification;
import android.app.PendingIntent;
import android.app.Service;
import android.appwidget.AppWidgetManager;
import android.content.Intent;
import android.net.ConnectivityManager;
import android.net.Network;
import android.os.Build;
import android.os.IBinder;
import android.support.annotation.RequiresApi;
import android.support.v4.app.NotificationCompat;
import android.util.Log;
import android.widget.RemoteViews;

import java.lang.annotation.Target;
import java.util.Calendar;

@TargetApi(21)
public class BitcoinService extends Service implements ConnectivityManager.OnNetworkActiveListener
{
	final static private int NOTIFICATION_ID = 444;
	
	private BitcoinServiceThread _thread;
	private int[] appWidgetIds;
	
	public class BitcoinServiceThread extends Thread
	{
		private Network _network;
		
		public BitcoinServiceThread(Network network)
		{
			_network = network;
		}
		
		@Override
		public void run()
		{
			try
			{
				String bitcoin = MyNetworkManager.getResponseStringByUrl(_network, "https://blockchain.info/tobtc?currency=USD&value=1");
				double usd = 1 / Double.parseDouble(bitcoin);
				
				AppWidgetManager widgetManager = AppWidgetManager.getInstance(BitcoinService.this);
				int[] allWidgetIds = null;
				synchronized (BitcoinService.this)
				{
					allWidgetIds = BitcoinService.this.appWidgetIds;
				}
				if (allWidgetIds != null)
				{
					for (int widgetId : allWidgetIds)
					{
						RemoteViews view = new RemoteViews(BitcoinService.this.getApplicationContext().getPackageName(), R.layout.bitcoin_app_widget);
						
						view.setTextViewText(R.id.tvBitcoinRate, "$" + String.valueOf(usd));
						view.setTextViewText(R.id.tvBitcoinUpdatedTime, getCurrentTime());
						
						widgetManager.updateAppWidget(widgetId, view);
					}
				}
			}
			catch (Exception ex)
			{
				Log.d("===", "run: " + ex.getMessage());
			}
			BitcoinService.this._thread = null;
			BitcoinService.this.stopSelf();
		}
		
		private String getCurrentTime()
		{
			Calendar calendar = Calendar.getInstance();
			int hours = calendar.get(Calendar.HOUR_OF_DAY);
			int mins = calendar.get(Calendar.MINUTE);
			int secs = calendar.get(Calendar.SECOND);
			return hours + ":" + mins + ":" + secs;
		}
	}
	
	@Override
	public IBinder onBind(Intent intent)
	{
		return null;
	}
	
	@Override
	public void onCreate()
	{
		super.onCreate();
		
		if (Build.VERSION.SDK_INT >= 26)
		{
			NotificationCompat.Builder builder = new NotificationCompat.Builder(this, MainActivity.CHANNEL_ID);
			builder.setSmallIcon(android.R.drawable.ic_notification_overlay)
					.setContentTitle("Service notification")
					.setContentText("The foreground service is running");
			
			Intent resultIntent = new Intent(this, MainActivity.class);
			PendingIntent pendingIntent = PendingIntent.getActivity(this, 0, resultIntent, PendingIntent.FLAG_UPDATE_CURRENT);
			builder.setContentIntent(pendingIntent);
			
			Notification notification = builder.build();
			startForeground(BitcoinService.NOTIFICATION_ID, notification);
		}
		
		if (Build.VERSION.SDK_INT >= 23)
		{
			Network network = MyNetworkManager.getNetwork(this);
			if (network == null)
			{
				MyNetworkManager.registerNetworkAvailableListener(this, this);
			}
			else
			{
				_thread = new BitcoinServiceThread(network);
				_thread.start();
			}
		}
		else
		{
			_thread = new BitcoinServiceThread(null);
			_thread.start();
		}
	}
	
	@RequiresApi(23)
	@Override
	public void onNetworkActive()
	{
		Network network = MyNetworkManager.getNetwork(this);
		if (network != null)
		{
			if (_thread == null)
			{
				_thread = new BitcoinServiceThread(network);
				_thread.start();
			}
			MyNetworkManager.unregisterNetworkAvailableListener(this, this);
		}
	}
	
	@Override
	public int onStartCommand(Intent intent, int flags, int startId)
	{
		synchronized (this)
		{
			appWidgetIds = intent.getIntArrayExtra(AppWidgetManager.EXTRA_APPWIDGET_ID);
		}
		return START_NOT_STICKY;
	}
}
