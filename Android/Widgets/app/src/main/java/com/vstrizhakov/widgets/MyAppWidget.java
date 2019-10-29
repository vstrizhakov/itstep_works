package com.vstrizhakov.widgets;

import android.app.Activity;
import android.appwidget.AppWidgetManager;
import android.appwidget.AppWidgetProvider;
import android.content.Context;
import android.content.SharedPreferences;
import android.graphics.Bitmap;
import android.widget.RemoteViews;

import java.util.Calendar;

public class MyAppWidget extends AppWidgetProvider
{
	@Override
	public void onUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds)
	{
		super.onUpdate(context, appWidgetManager, appWidgetIds);
		
		SharedPreferences preferences = context.getSharedPreferences(ConfigActivity.APP_SHARED_PREFERENCES, Context.MODE_PRIVATE);
		int widgetColorIndex = preferences.getInt(ConfigActivity.PREFERRED_WIDGET_COLOR, 0);
		int widgetColor = ConfigActivity.WidgetColors[widgetColorIndex];
		
		String curTimeString = MyAppWidget.getCurrentTimeString();
		for (int appWidgetId : appWidgetIds)
		{
			RemoteViews views = new RemoteViews(context.getPackageName(), R.layout.my_app_widget);
			views.setTextViewText(R.id.tvLastUpdate, curTimeString);
			views.setTextColor(R.id.tvHelloWorld, widgetColor);
			views.setTextColor(R.id.tvLastUpdateLabel, widgetColor);
			views.setTextColor(R.id.tvLastUpdate, widgetColor);
			views.setImageViewResource(R.id.ivIcon, ConfigActivity.ImageIds[widgetColorIndex]);
			
			appWidgetManager.updateAppWidget(appWidgetId, views);
		}
	}
	
	static private String getCurrentTimeString()
	{
		Calendar calendar = Calendar.getInstance();
		int hour = calendar.get(Calendar.HOUR_OF_DAY);
		int min = calendar.get(Calendar.MINUTE);
		int sec = calendar.get(Calendar.SECOND);
		return hour + ":" + min + ":" + sec;
	}
}
