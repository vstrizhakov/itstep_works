package com.vstrizhakov.fragment____;

import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

public class TestFragment extends Fragment
{
	private final static String TAG = "===";
	
	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
	{
		Log.d(TAG, "TestFragment: onCreateView");
		return inflater.inflate(R.layout.test_fragment, container, false);
	}
	
	@Override
	public void onAttach(Context context)
	{
		super.onAttach(context);
		Log.d(TAG, "TestFragment: onAttach");
	}
	
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		Log.d(TAG, "TestFragment: onCreate");
	}
	
	@Override
	public void onActivityCreated(Bundle savedInstanceState)
	{
		super.onActivityCreated(savedInstanceState);
		Log.d(TAG, "TestFragment: onActivityCreated");
	}
	
	@Override
	public void onViewStateRestored(Bundle savedInstanceState)
	{
		super.onViewStateRestored(savedInstanceState);
		Log.d(TAG, "TestFragment: onViewStateRestored");
	}
	
	@Override
	public void onStart()
	{
		super.onStart();
		Log.d(TAG, "TestFragment: onStart");
	}
	
	@Override
	public void onResume()
	{
		super.onResume();
		Log.d(TAG, "TestFragment: onResume");
	}
	
	@Override
	public void onPause()
	{
		super.onPause();
		Log.d(TAG, "TestFragment: onPause");
	}
	
	@Override
	public void onStop()
	{
		super.onStop();
		Log.d(TAG, "TestFragment: onStop");
	}
	
	@Override
	public void onDestroy()
	{
		super.onDestroy();
		Log.d(TAG, "TestFragment: onDestroy");
	}
	
	@Override
	public void onDestroyView()
	{
		super.onDestroyView();
		Log.d(TAG, "TestFragment: onDestroyView");
	}
	
	@Override
	public void onDetach()
	{
		super.onDetach();
		Log.d(TAG, "TestFragment: onDetach");
	}
}
