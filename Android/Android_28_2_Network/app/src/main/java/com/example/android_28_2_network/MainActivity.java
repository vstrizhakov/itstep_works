package com.example.android_28_2_network;

import android.annotation.SuppressLint;
import android.annotation.TargetApi;
import android.content.Context;
import android.net.ConnectivityManager;
import android.net.Network;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.widget.TextView;

import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;

public class MainActivity extends AppCompatActivity
{
    private static  Thr T = null;
    private TextView tv_info;
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        this.tv_info = this.findViewById(R.id.tv_info);
        if(T == null)
        {
            MainActivity.T = new Thr();
            MainActivity.T.start();
        }
    }

    class Thr extends Thread
    {
        @TargetApi(23) //для 23 API
        @Override
        public void run()
        {
            ConnectivityManager cm = (ConnectivityManager)MainActivity.this.getSystemService(Context.CONNECTIVITY_SERVICE);
            Network N = cm.getActiveNetwork();
            try
            {
//                //HttpURLConnection cn = (HttpURLConnection) N.openConnection(new URL("http://example.com"));
//                HttpURLConnection cn = (HttpURLConnection) N.openConnection(new URL("http://10.3.11.10/hello.php?firstname=Bill&lastname=Gates"));
//                cn.setDoInput(true); // будет чтение полученного HTTP ответа
//                cn.connect();
//
//                InputStream IS = cn.getInputStream();
//                ByteArrayOutputStream BAOS = new ByteArrayOutputStream();
//                byte[] b = new byte[1024];
//                while (true)
//                {
//                    int cnt = IS.read(b);
//                    if(cnt == -1)
//                        break;
//                    BAOS.write(b,0,cnt);
//                }
//                byte[] a = BAOS.toByteArray();
//                BAOS.reset();
//                final String content = new String(a, "UTF-8");
//                cn.disconnect();
//                Log.d("====", content);


                //=========Отправка данных в HTTP запросе методом POST
                HttpURLConnection cn = (HttpURLConnection)N.openConnection(new URL("http://10.3.11.10/hello.php"));
                cn.setDoInput(true);
                //---запись данных, отправляемых методом POST
                cn.setDoOutput(true);
                OutputStream out = cn.getOutputStream();
                String str = "firstname=Steven&lastname=King";
                byte[] a = str.getBytes("UTF-8");
                out.write(a);
                //---чтение полученного HTTp ответа
                InputStream IS = cn.getInputStream();
                ByteArrayOutputStream BAOS = new ByteArrayOutputStream();
                byte[] b = new byte[1024];
                while (true)
                {
                    int cnt = IS.read(b);
                    if(cnt == -1)
                        break;
                    BAOS.write(b,0,cnt);
                }
                a = BAOS.toByteArray();
                BAOS.reset();
                final String content = new String(a, "UTF-8");
                cn.disconnect();
                Log.d("====", content);
                //===================================

                Runnable runnable = new Runnable()
                {
                    @Override
                    public void run()
                    {
                        MainActivity.this.tv_info.setText(content);
                    }
                };

                runnable.run();
            }
            catch (Exception e){}
        }
    }
}
