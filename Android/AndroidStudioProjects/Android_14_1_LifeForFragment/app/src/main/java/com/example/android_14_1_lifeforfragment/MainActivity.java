package com.example.android_14_1_lifeforfragment;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;

public class MainActivity extends AppCompatActivity
{
    private final static String TAG = "##=== MainActivity";
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Log.d(TAG, "onCreate");
    }
    @Override
    protected  void onStart()
    {
        super.onStart();
        Log.d(TAG, "onStart - Активность становится видимой для пользователя");
    }
    @Override
    protected void  onResume()
    {
        super.onResume();
        Log.d(TAG, "onResume - Активность выходит на передний план");
    }
    @Override
    protected void  onStop()
    {
        super.onStop();
        Log.d(TAG, "onStop - Активность перестает быть видимой");
    }
    @Override
    protected void  onDestroy()
    {
        super.onDestroy();
        Log.d(TAG, "onDestroy - Активность уничтожается");
    }

}
