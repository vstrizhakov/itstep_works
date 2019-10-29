package com.example.android_28_1_network;

import android.annotation.TargetApi;
import android.content.Context;
import android.net.ConnectivityManager;
import android.net.Network;
import android.net.NetworkInfo;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.TextView;

@TargetApi(21) //для 21 API
public class MainActivity extends AppCompatActivity
{

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        ConnectivityManager cm = (ConnectivityManager) this.getSystemService(Context.CONNECTIVITY_SERVICE);
        Network[] allNetworks = null;
       // if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.LOLLIPOP)
        //{
        allNetworks = cm.getAllNetworks();
        StringBuilder SB = new StringBuilder();
        for(Network N : allNetworks)
        {
            NetworkInfo NI = cm.getNetworkInfo(N);
            SB.append("Тип: "+NI.getTypeName()+"\n");
            SB.append("Состояние: "+NI.getState()+"\n");
            SB.append("Доступность: "+NI.isAvailable()+"\n");
            SB.append("Тип подсети: "+NI.getSubtypeName()+"\n");
            SB.append("Connected: "+NI.isConnected()+"\n");
            SB.append("\n");
        }
        TextView textView = (TextView)this.findViewById(R.id.tvInfo);
        textView.setText(SB.toString());
       // }


    }
}
