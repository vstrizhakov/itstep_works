package com.vstrizhakov.bitcoinservice;

import android.app.AlertDialog;
import android.content.Context;
import android.net.ConnectivityManager;
import android.net.Network;
import android.net.NetworkInfo;
import android.os.Build;
import android.support.annotation.RequiresApi;

import java.io.ByteArrayOutputStream;
import java.net.HttpURLConnection;
import java.net.URL;

public class MyNetworkManager
{
	@RequiresApi(23)
	public static Network getNetwork(Context context)
	{
		ConnectivityManager connectivityManager = (ConnectivityManager)context.getSystemService(Context.CONNECTIVITY_SERVICE);
		Network network = connectivityManager.getActiveNetwork();
		return network;
	}
	
	@RequiresApi(21)
	public static void registerNetworkAvailableListener(Context context, ConnectivityManager.OnNetworkActiveListener listener)
	{
		ConnectivityManager connectivityManager = (ConnectivityManager)context.getSystemService(Context.CONNECTIVITY_SERVICE);
		connectivityManager.addDefaultNetworkActiveListener(listener);
	}
	
	@RequiresApi(21)
	public static void unregisterNetworkAvailableListener(Context context, ConnectivityManager.OnNetworkActiveListener listener)
	{
		ConnectivityManager connectivityManager = (ConnectivityManager)context.getSystemService(Context.CONNECTIVITY_SERVICE);
		connectivityManager.removeDefaultNetworkActiveListener(listener);
	}
	
	public static byte[] getResponseByteArrayByUrl(Network network, String urlString) throws Exception
	{
		HttpURLConnection connection;
		URL url = new URL(urlString);
		if (Build.VERSION.SDK_INT >= 21 && network != null)
		{
			connection = (HttpURLConnection)network.openConnection(url);
		}
		else
		{
			connection = (HttpURLConnection)url.openConnection();
		}
		
		connection.setDoInput(true);
		connection.connect();
		
		ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
		byte[] buf = new byte[2048];
		
		while (true)
		{
			int count = connection.getInputStream().read(buf, 0, buf.length);
			if (count == -1)
			{
				break;
			}
			byteArrayOutputStream.write(buf, 0, count);
		}
		connection.disconnect();
		return byteArrayOutputStream.toByteArray();
	}
	
	public static String getResponseStringByUrl(Network network, String urlString) throws Exception
	{
		byte[] bytes = MyNetworkManager.getResponseByteArrayByUrl(network, urlString);
		return  new String(bytes, 0, bytes.length, "UTF8");
	}
}
