package com.vstrizhakov.fragment____;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;

public class MainActivity extends AppCompatActivity
{
	private final static String TAG = "===";
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
	}
	
	public void btnAddClick(View view)
	{
		Fragment fragment = null;
		switch (view.getId())
		{
			case R.id.btnFirstFragment:
				fragment = new FirstFragment();
				break;
			case R.id.btnCalcFragment:
				fragment = new CalcFragment();
				break;
			default:
				break;
		}
		
		FragmentManager fragmentManager = getSupportFragmentManager();
		FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
		fragmentTransaction.replace(R.id.fragmentContainer, fragment);
		fragmentTransaction.addToBackStack(null);
		fragmentTransaction.commit();
	}
	
	public void onStart()
	{
		super.onStart();
		Log.d(TAG, "MainActivity: onStart");
	}
	
	@Override
	public void onResume()
	{
		super.onResume();
		Log.d(TAG, "MainActivity: onResume");
	}
	
	@Override
	public void onPause()
	{
		super.onPause();
		Log.d(TAG, "MainActivity: onPause");
	}
	
	@Override
	public void onStop()
	{
		super.onStop();
		Log.d(TAG, "MainActivity: onStop");
	}
	
	@Override
	public void onDestroy()
	{
		super.onDestroy();
		Log.d(TAG, "MainActivity: onDestroy");
	}
	
	@Override
	public void onBackPressed()
	{
		FragmentManager fragmentManager = getSupportFragmentManager();
		if (fragmentManager.getBackStackEntryCount() == 0)
		{
			super.onBackPressed();
		}
		else
		{
			fragmentManager.popBackStack();
		}
	}
}
