package com.vstrizhakov.bitcoinservice;

import android.appwidget.AppWidgetManager;
import android.appwidget.AppWidgetProvider;
import android.content.Context;
import android.content.Intent;
import android.os.Build;

public class BitcoinAppWidget extends AppWidgetProvider
{
	@Override
	public void onUpdate(Context context, AppWidgetManager widgetManager, int[] appWidgetIds)
	{
		super.onUpdate(context, widgetManager, appWidgetIds);
		
		Intent intent = new Intent(context.getApplicationContext(), BitcoinService.class);
		intent.putExtra(AppWidgetManager.EXTRA_APPWIDGET_ID, appWidgetIds);
		
		if (Build.VERSION.SDK_INT < 26)
		{
			context.startService(intent);
		}
		else
		{
			context.startForegroundService(intent);
		}
	}
}
