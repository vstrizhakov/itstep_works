package com.vstrizhakov.crocodile.Helpers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.vstrizhakov.crocodile.Api.Models.Error;
import com.vstrizhakov.crocodile.Api.Notification;

import java.lang.reflect.Type;

public class GsonHelper
{
	final static private Gson _gson = new GsonBuilder().setDateFormat("yyyy-MM-dd'T'HH:mm:ss").create();
	
	static public Object deserializeNotification(Notification notification, Type type)
	{
		return _gson.fromJson(notification.getJsonData(), notification.isError() ? Error.class : type);
	}
	
	static public String serializeObject(Object object)
	{
		return _gson.toJson(object);
	}
}
