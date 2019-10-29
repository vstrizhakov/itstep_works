package com.example.android_14_1_lifeforfragment;

import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

public class TestFragment extends Fragment
{
    private final static String TAG = "===== TestFragment";
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        Log.d(TAG, "---- onCreate - создание набора виджетов Фрагмента");
        return  inflater.inflate(R.layout.test_fragment, container, false);
    }
    @Override
    public  void onAttach(Context context)
    {
        super.onAttach(context);
        Log.d(TAG, "---- onAttach - фрагмент прикрепляется к Активности");
    }
    @Override
    public  void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        Log.d(TAG, "---- onCreate - Инициализация Фрагмента");
    }
    @Override
    public  void onActivityCreated(Bundle savedInstanceState)
    {
        super.onActivityCreated(savedInstanceState);
        Log.d(TAG, "---- onActivityCreated - Активность");
    }
    @Override
    public  void onViewStateRestored(Bundle savedInstanceState)
    {
        super.onViewStateRestored(savedInstanceState);
        Log.d(TAG, "---- onViewStateRestored - Состояние виджетов");
    }
    @Override
    public  void onStart()
    {
        super.onStart();
        Log.d(TAG, "---- onStart - Старт");
    }
    @Override
    public  void onResume()
    {
        super.onResume();
        Log.d(TAG, "---- onResume");
    }
    @Override
    public  void onPause()
    {
        super.onPause();
        Log.d(TAG, "---- onPause");
    }
    @Override
    public  void onStop()
    {
        super.onStop();
        Log.d(TAG, "---- onStop");
    }
    @Override
    public  void onDestroy()
    {
        super.onDestroy();
        Log.d(TAG, "---- onDestroy");
    }
    @Override
    public  void onDestroyView()
    {
        super.onDestroyView();
        Log.d(TAG, "---- onDestroyView");
    }
    @Override
    public  void onDetach()
    {
        super.onDetach();
        Log.d(TAG, "---- onDetach");
    }

}
