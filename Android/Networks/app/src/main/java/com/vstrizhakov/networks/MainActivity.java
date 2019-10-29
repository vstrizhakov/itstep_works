package com.vstrizhakov.networks;

import android.annotation.TargetApi;
import android.content.Context;
import android.net.ConnectivityManager;
import android.net.Network;
import android.net.NetworkInfo;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.TextView;

@TargetApi(21)
public class MainActivity extends AppCompatActivity
{
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		ConnectivityManager connectivityManager = (ConnectivityManager)getSystemService(Context.CONNECTIVITY_SERVICE);
		Network[] allNetworks = connectivityManager.getAllNetworks();
		
		String resultString = "";
		for (Network network : allNetworks)
		{
			NetworkInfo networkInfo = connectivityManager.getNetworkInfo(network);
			resultString += "Тип: " + networkInfo.getTypeName() + "\n";
			resultString += "Состояние: " + networkInfo.getState() + "\n";
			resultString += "Доступность: " + networkInfo.isAvailable() + "\n";
			resultString += "Тип подсети: " + networkInfo.getSubtypeName() + "\n";
			resultString += "Connected: " + networkInfo.isConnected() + "\n";
			resultString += "\n";
		}
		
		TextView tvInfo = findViewById(R.id.tvInfo);
		tvInfo.setText(resultString);
	}
}
