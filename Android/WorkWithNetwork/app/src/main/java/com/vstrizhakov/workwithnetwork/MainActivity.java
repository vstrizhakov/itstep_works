package com.vstrizhakov.workwithnetwork;

import android.annotation.TargetApi;
import android.content.Context;
import android.net.ConnectivityManager;
import android.net.Network;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;

import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;

@TargetApi(23)
public class MainActivity extends AppCompatActivity
{
	class NetworkThread extends Thread
	{
		@Override
		public void run()
		{
			ConnectivityManager connectivityManager = (ConnectivityManager)getSystemService(Context.CONNECTIVITY_SERVICE);
			Network activeNetwork = connectivityManager.getActiveNetwork();
			try
			{
				HttpURLConnection connection = (HttpURLConnection)activeNetwork.openConnection(new URL("http://10.3.11.10/hello.php"));
				connection.setDoInput(true);
				
				connection.setDoOutput(true);
				OutputStream out = connection.getOutputStream();
				String outputString = "firstname=Steven&lastname=King";
				byte[] a = outputString.getBytes();
				out.write(a, 0, a.length);
				
				InputStream IS = connection.getInputStream();
				ByteArrayOutputStream BAOS = new ByteArrayOutputStream();
				byte[] bytes = new byte[1024];
				
				while (true)
				{
					int count = IS.read(bytes, 0, bytes.length);
					if (count == -1) break;
					BAOS.write(bytes, 0, count);
				}
				byte[] totalBytes = BAOS.toByteArray();
				BAOS.reset();
				String content = new String(totalBytes, 0, totalBytes.length, "UTF8");
				Log.d("===", content);
				connection.disconnect();
			}
			catch (Exception ex)
			{
				Log.d("===Exception", "run: " + ex.getMessage());
			}
		}
	}
	
	private static NetworkThread _networkThread = null;
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		if (_networkThread == null)
		{
			_networkThread = new NetworkThread();
			_networkThread.start();
		}
	}
}
