package com.vstrizhakov.contentdialogs;

import android.support.v4.app.DialogFragment;
import android.support.v4.app.FragmentManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;

public class MainActivity extends AppCompatActivity
{
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
	}
	
	public void btnClick(View view)
	{
		FragmentManager FM = getSupportFragmentManager();
		DialogFragmentOne dialog = new DialogFragmentOne();
		Bundle bundleARgs = new Bundle();
		bundleARgs.putInt(DialogFragmentOne.DIALOGONE_LASTNAME, R.id.tvLastName);
		bundleARgs.putInt(DialogFragmentOne.DIALOGONE_FIRSTNAME, R.id.tvFirstName);
		dialog.setArguments(bundleARgs);
		dialog.show(FM, "DialogOne");
	}
	
	public void btnClickTwo(View view)
	{
		FragmentManager fragmentManager = getSupportFragmentManager();
		DialogFragmentTwo dialog = new DialogFragmentTwo();
		Bundle bundleArgs = new Bundle();
		bundleArgs.putInt(DialogFragmentTwo.DIALOGTWO_HEIGHT, R.id.tvHeight);
		bundleArgs.putInt(DialogFragmentTwo.DIALOGTWO_WEIGHT, R.id.tvWeight);
		dialog.setArguments(bundleArgs);
		dialog.show(fragmentManager, "DialogTwo");
	}
}
